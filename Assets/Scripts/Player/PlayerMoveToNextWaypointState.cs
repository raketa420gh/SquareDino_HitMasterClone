using System;
using UnityEngine;

public class PlayerMoveToNextWaypointState : PlayerState
{
    private readonly IPlayer _player;
    private readonly IPlayerController _playerController;
    private Vector3 _nextWaypointPosition;

    public PlayerMoveToNextWaypointState(IPlayer player, IPlayerController playerController) : base(player)
    {
        _player = player;
        _playerController = playerController;
    }

    public override void Enter()
    {
        var nextWaypoint = _playerController.GetNextWaypoint();
        _nextWaypointPosition = nextWaypoint.Position;
        
        _player.Unit.MoveTo(_nextWaypointPosition);
        _player.Unit.PlayAnimation(UnitAnimationState.Run);
    }

    public override void Update()
    {
        var distanceToNextWaypoint =
            Vector3.Distance(_player.Unit.WorldObject.transform.position, _nextWaypointPosition);

        if (distanceToNextWaypoint < Single.Epsilon)
        {
            _playerController.ReachWaypoint();
        }
    }
}