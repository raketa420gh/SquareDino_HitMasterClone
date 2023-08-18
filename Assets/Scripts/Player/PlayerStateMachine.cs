using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    private readonly PlayerIdleState _idleState;
    private readonly PlayerMoveToNextWaypointState _moveToNextWaypointState;
    private readonly PlayerAttackState _attackState;

    public PlayerStateMachine(PlayerStateType startStateType, IPlayer player, IPlayerController playerController, 
        IProjectileFactory projectileFactory, Camera camera)
    {
        _idleState = new PlayerIdleState(player);
        _moveToNextWaypointState = new PlayerMoveToNextWaypointState(player, playerController);
        _attackState = new PlayerAttackState(player, playerController, projectileFactory, camera);
        
        SetState(startStateType);
    }

    public void SetState(PlayerStateType stateType)
    {
        switch (stateType)
        {
            case PlayerStateType.Idle:
                ChangeState(_idleState);
                break;
            case PlayerStateType.MoveToNextWaypoint:
                ChangeState(_moveToNextWaypointState);
                break;
            case PlayerStateType.Attack:
                ChangeState(_attackState);
                break;
        }
    }
}