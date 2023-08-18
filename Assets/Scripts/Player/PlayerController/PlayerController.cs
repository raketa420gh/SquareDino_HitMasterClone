using System;
using UnityEngine;

public class PlayerController : MonoBehaviour, IPlayerController
{
    public event Action OnAllWaypointsCleared;
    
    private IWaypointsContainer _waypointsContainer;
    private IProjectileFactory _projectileFactory;
    private IPlayer _player;
    private PlayerStateMachine _stateMachine;
    private Waypoint[] _waypoints;
    private Vector3 _throwDirection;
    private int _currentCompletedWaypointIndex;
    private int _currentEnemiesCount;
    private Waypoint _currentWaypoint;
    private Vector3 _hitPosition;
    private BulletsPool _bulletsPool;
    private Camera _camera;

    public IPlayer Player => _player;

    private void Update()
    {
        _stateMachine.CurrentState.Update();
    }

    public void Initialize(IPlayer player, IWaypointsContainer waypointsContainer, IProjectileFactory projectileFactory,
        BulletsPool bulletsPool)
    {
        _player = player;
        _waypointsContainer = waypointsContainer;
        _projectileFactory = projectileFactory;
        _bulletsPool = bulletsPool;
        _camera = Camera.main;

        _player.Unit.OnThrow += OnPlayerThrowEvent;
        
        InitializeStateMachine(PlayerStateType.Idle);
    }

    public void Disable()
    {
        _player.Unit.OnThrow -= OnPlayerThrowEvent;
    }

    public void ChangeState(PlayerStateType stateType)
    {
        _stateMachine.SetState(stateType);
    }

    public void AttackThrow(Vector3 hitPosition)
    {
        _hitPosition = hitPosition;
        _player.Unit.PlayAnimation(UnitAnimationState.Attack);
    }

    public Waypoint GetNextWaypoint()
    {
        _waypoints = _waypointsContainer.GetWaypoints();
        var currentWaypointIndex = GetCurrentReachedWaypointIndex();
        var nextWaypoint = _waypoints[currentWaypointIndex];

        return nextWaypoint;
    }

    public void ReachWaypoint()
    {
        _currentWaypoint = _waypoints[_currentCompletedWaypointIndex];
        _currentWaypoint.ShowEnemies();
        SetCurrentEnemiesCount(_currentWaypoint.SpawnedEnemies.Length);

        foreach (var enemy in _currentWaypoint.SpawnedEnemies)
            enemy.OnDie += OnEnemyDie;

        ChangeState(PlayerStateType.Attack);
    }

    private void InitializeStateMachine(PlayerStateType startStateType)
    {
        _stateMachine = new PlayerStateMachine(startStateType, _player, this, _projectileFactory, _camera);
    }

    private int GetCurrentReachedWaypointIndex()
    {
        return _currentCompletedWaypointIndex;
    }

    private void SetCurrentEnemiesCount(int count)
    {
        _currentEnemiesCount = count;
    }

    private void OnEnemyDie()
    {
        _currentEnemiesCount--;

        if (_currentEnemiesCount == 0)
        {
            foreach (var enemy in _currentWaypoint.SpawnedEnemies)
                enemy.OnDie -= OnEnemyDie;

            _currentCompletedWaypointIndex++;

            if (_currentCompletedWaypointIndex == _waypoints.Length)
            {
                OnAllWaypointsCleared?.Invoke();
                _stateMachine.SetState(PlayerStateType.Idle);
                return;
            }

            _stateMachine.SetState(PlayerStateType.MoveToNextWaypoint);
        }
    }

    private void OnPlayerThrowEvent()
    {
        var muzzlePosition = _player.Unit.MuzzlePoint.position;
        var aimingDirection = _hitPosition - muzzlePosition;
        _throwDirection = aimingDirection.normalized;
        var bullet = _bulletsPool.Pool.GetFreeElement();
        bullet.transform.position = muzzlePosition;
        bullet.SetDirection(_throwDirection);
    }
}