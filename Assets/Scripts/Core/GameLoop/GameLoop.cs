using System;
using System.Threading.Tasks;

public class GameLoop
{
    private StateMachine _stateMachine;
    private GameLoopInitializeState _initializeState;
    private GameLoopPlayState _playState;
    private readonly IUnitFactory _unitFactory;
    private readonly IProjectileFactory _projectileFactory;
    private readonly IWaypointsContainer _waypointsContainer;
    private readonly IUIContainer _uiContainer;
    private readonly IUIController _uiController;
    private readonly IPlayerController _playerController;
    private readonly ICameraController _cameraController;
    private readonly ISceneLoader _sceneLoader;
    private readonly BulletsPool _bulletsPool;

    public GameLoop(IUnitFactory unitFactory, IProjectileFactory projectileFactory, IWaypointsContainer waypointsContainer, 
        IUIContainer uiContainer, IUIController uiController, IPlayerController playerController, 
        ICameraController cameraController, ISceneLoader sceneLoader, BulletsPool bulletsPool)
    {
        _sceneLoader = sceneLoader;
        _bulletsPool = bulletsPool;
        _unitFactory = unitFactory;
        _projectileFactory = projectileFactory;
        _waypointsContainer = waypointsContainer;
        _uiContainer = uiContainer;
        _uiController = uiController;
        _playerController = playerController;
        _cameraController = cameraController;
        _sceneLoader = sceneLoader;

        InitializeStateMachine();
    }

    private void InitializeStateMachine()
    {
        _stateMachine = new StateMachine();
        _initializeState = new GameLoopInitializeState(this, _unitFactory, _projectileFactory, _waypointsContainer, 
            _uiContainer, _uiController, _playerController, _cameraController, _bulletsPool);
        _playState = new GameLoopPlayState(this, _playerController);

        _stateMachine.ChangeState(_initializeState);

        _playerController.OnAllWaypointsCleared += OnPlayerClearAllWaypoints;
    }

    public void UpdateCurrentState() => _stateMachine.UpdateCurrentState();

    public void SetPlayState() => _stateMachine.ChangeState(_playState);

    private async void OnPlayerClearAllWaypoints()
    {
        _playerController.OnAllWaypointsCleared -= OnPlayerClearAllWaypoints;
        
        _uiController.ShowPanel(UIPanelType.Finish);

        await Task.Delay((TimeSpan.FromSeconds(3f)));

        _sceneLoader.LoadStartScene();
    }
}