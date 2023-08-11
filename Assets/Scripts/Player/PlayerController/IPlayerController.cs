using System;
using UnityEngine;

public interface IPlayerController
{
    event Action OnAllWaypointsCleared;
    IPlayer Player { get; }
    void Initialize(IPlayer player, IWaypointsContainer waypointsContainer, IProjectileFactory projectileFactory,
        BulletsPool bulletsPool);
    void Disable();
    void ChangeState(PlayerStateType stateType);
    void AttackThrow(Vector3 hitPosition);
    Waypoint GetNextWaypoint();
    void ReachWaypoint();
}