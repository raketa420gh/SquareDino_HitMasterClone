using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameLoopInitializeState : GameLoopState
{
    private readonly GameLoop _gameLoop;
    private readonly IUnitFactory _unitFactory;
    private readonly IProjectileFactory _projectileFactory;
    private readonly IWaypointsContainer _waypointsContainer;
    private readonly IUIContainer _uiContainer;
    private IPlayerController _playerController;
    private readonly ICameraController _cameraController;
    private readonly BulletsPool _bulletsPool;
    private IUIController _uiController;

    public GameLoopInitializeState(GameLoop gameLoop, IUnitFactory unitFactory, IProjectileFactory projectileFactory,
        IWaypointsContainer waypointsContainer, IUIContainer uiContainer, IUIController uiController, 
        IPlayerController playerController, ICameraController cameraController, BulletsPool bulletsPool) : base(gameLoop)
    {
        _gameLoop = gameLoop;
        _unitFactory = unitFactory;
        _projectileFactory = projectileFactory;
        _waypointsContainer = waypointsContainer;
        _uiContainer = uiContainer;
        _uiController = uiController;
        _playerController = playerController;
        _cameraController = cameraController;
        _bulletsPool = bulletsPool;
    }

    public override void Enter()
    {
        InitializePool();
        InitializePlayer(SpawnPlayer());
        InitializeEnemies();
        InitializeUIController(_uiContainer);

        _uiController.ShowPanel(UIPanelType.Start);
    }

    public override void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _gameLoop.SetPlayState();
        }
    }

    public override void Exit()
    {
        _uiController.HidePanel(UIPanelType.Start);
    }

    private List<IUnit> SpawnEnemiesToWaypoints()
    {
        var allWaypoints = _waypointsContainer.GetWaypoints();
        var allSpawnedEnemies = new List<IUnit>();

        foreach (var waypoint in allWaypoints)
        {
            var enemyPoints = waypoint.GetEnemyPoints();
            var spawnedEnemies = enemyPoints
                .Select(enemyPoint => _unitFactory.CreateUnit(UnitType.Enemy, enemyPoint.Position)).ToList();

            allSpawnedEnemies.AddRange(spawnedEnemies);
            waypoint.SetWaypointEnemies(spawnedEnemies.ToArray());
        }

        return allSpawnedEnemies;
    }

    private IPlayer SpawnPlayer()
    {
        var playerUnit = _unitFactory.CreateUnit(UnitType.Player, Vector3.zero);
        var player = playerUnit.WorldObject.GetComponent<IPlayer>();

        return player ?? null;
    }

    private void InitializeUIController(IUIContainer container)
    {
        _uiController.SetContainer(container);
    }

    private void InitializePool()
    {
        _bulletsPool.CreatePool();
    }

    private void InitializePlayer(IPlayer player)
    {
        _playerController.Initialize(player, _waypointsContainer, _projectileFactory, _bulletsPool);
        _cameraController.SetFollowCamera(player.Unit.WorldObject.transform);
    }

    private void InitializeEnemies()
    {
        var spawnedEnemies = SpawnEnemiesToWaypoints();

        var allWaypoints = _waypointsContainer.GetWaypoints();

        foreach (var waypoint in allWaypoints)
        {
            waypoint.HideEnemies();
        }
    }
}