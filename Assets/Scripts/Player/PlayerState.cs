public class PlayerState : BaseState
{
    protected IPlayer _player;

    protected PlayerState(IPlayer player)
    {
        _player = player;
    }
}