using UnityEngine;

public class GameLoopPlayState : GameLoopState
{
    private readonly GameLoop _gameLoop;
    private readonly IPlayerController _playerController;
    private float _timer;

    public GameLoopPlayState(GameLoop gameLoop, IPlayerController playerController) : base(gameLoop)
    {
        _gameLoop = gameLoop;
        _playerController = playerController;
    }

    public override void Enter()
    {
        _playerController.ChangeState(PlayerStateType.MoveToNextWaypoint);
    }

    public override void Update()
    {
        
    }

    public override void Exit()
    {
    }
}