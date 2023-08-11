public class PlayerIdleState : PlayerState
{
    private readonly IPlayer _player;

    public PlayerIdleState(IPlayer player) : base(player)
    {
        _player = player;
    }

    public override void Enter()
    {
        _player.Unit.PlayAnimation(UnitAnimationState.Idle);
    }
}