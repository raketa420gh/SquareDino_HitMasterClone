using UnityEngine;
using Zenject;

public class GameBootstrapper : MonoBehaviour
{
    private GameLoop _gameLoop;
    private ISceneLoader _sceneLoader;
    private IUnitFactory _unitFactory;
    private IProjectileFactory _projectileFactory;
    private ICameraController _cameraController;
    private IWaypointsContainer _waypointsContainer;
    private IUIContainer _uiContainer;
    private IUIController _uiController;
    private IPlayerController _playerController;
    private BulletsPool _bulletsPool;

    [Inject]
    public void Construct(ISceneLoader sceneLoader, IUnitFactory unitFactory, IProjectileFactory projectileFactory, 
        ICameraController cameraController, IWaypointsContainer waypointsContainer, IUIContainer uiContainer, 
        IUIController uiController, IPlayerController playerController, BulletsPool bulletsPool)
    {
        _sceneLoader = sceneLoader;
        _unitFactory = unitFactory;
        _projectileFactory = projectileFactory;
        _waypointsContainer = waypointsContainer;
        _uiContainer = uiContainer;
        _uiController = uiController;
        _playerController = playerController;
        _cameraController = cameraController;
        _bulletsPool = bulletsPool;
    }

    private void Start()
    {
        CreateGameLoop();
    }

    private void Update()
    {
        _gameLoop?.UpdateCurrentState();
    }

    private void CreateGameLoop()
    {
        _gameLoop = new GameLoop(_unitFactory, _projectileFactory, _waypointsContainer, _uiContainer, _uiController, 
            _playerController, _cameraController, _sceneLoader, _bulletsPool);
    }
}
