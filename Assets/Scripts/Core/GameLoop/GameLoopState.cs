public class GameLoopState : BaseState
{
    private GameLoop _gameLoop;

    protected GameLoopState(GameLoop gameLoop)
    {
        _gameLoop = gameLoop;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();
    }

    public override void Exit()
    {
        base.Exit();
    }
}