using System;

public interface IUnitAnimator
{
    event Action OnThrow;

    void Initialize();
    void Disable();
    void PlayAnimation(UnitAnimationState animationState);
}