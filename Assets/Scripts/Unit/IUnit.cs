using System;
using UnityEngine;

public interface IUnit
{
    event Action OnThrow;
    event Action OnDie;
    
    UnitType Type { get; }
    UnitData Data { get; }
    GameObject WorldObject { get; }

    Transform MuzzlePoint { get; }

    void Initialize(UnitType type, UnitData data, Vector3 position);
    void MoveTo(Vector3 destination);
    void Stop();
    void PlayAnimation(UnitAnimationState animationState);
    void TakeDamage(int amount);
    void DeactivateHealthBar();
}