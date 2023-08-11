using System;
using UnityEngine;

public class PlayerAttackState : PlayerState
{
    private readonly IPlayer _player;
    private readonly IPlayerController _playerController;
    private readonly IProjectileFactory _projectileFactory;
        
    public PlayerAttackState(IPlayer player, IPlayerController playerController, IProjectileFactory projectileFactory) : base(player)
    {
        _player = player;
        _playerController = playerController;
        _projectileFactory = projectileFactory;
    }

    public override void Enter()
    {
        _player.Unit.PlayAnimation(UnitAnimationState.Idle);
    }

    public override void Update()
    {
        UpdateClick();
    }
    
    private void UpdateClick()
    {
        if (!Input.GetMouseButtonDown(0))
            return;

        Debug.Log($"Click");
        
        var mousePosition = Input.mousePosition;

        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        Debug.DrawLine(ray.origin, ray.direction * Single.PositiveInfinity, Color.red);
        Vector3 hitPoint;

        if (!Physics.Raycast(ray, out RaycastHit hitInfo)) 
            return;
            
        hitPoint = hitInfo.point;
        
        _playerController.AttackThrow(hitPoint);
    }
}