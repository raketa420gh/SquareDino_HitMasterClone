using System;
using UnityEngine;

public class UnitAnimator : MonoBehaviour, IUnitAnimator
{
    public event Action OnThrow;
    
    [SerializeField] private Animator _animator;
    [SerializeField] private UnitAttackAnimationEvent _attackAnimationEvent;

    public void Initialize()
    {
        _attackAnimationEvent.OnThrow += OnThrowEvent;
    }

    public void Disable()
    {
        _attackAnimationEvent.OnThrow -= OnThrowEvent;
    }

    public void PlayAnimation(UnitAnimationState animationState)
    {
        switch (animationState)
        {
            case UnitAnimationState.Idle:
                SetAnimationTrigger("Idle");
                break;
            case UnitAnimationState.Walk:
                SetAnimationTrigger("Walk");
                break;
            case UnitAnimationState.Run:
                SetAnimationTrigger("Run");
                break;
            case UnitAnimationState.Attack:
                SetAnimationTrigger("Attack");
                break;
        }
    }

    private void SetAnimationTrigger(string triggerName) => 
        _animator.SetTrigger(triggerName);

    private void OnThrowEvent()
    {
        OnThrow?.Invoke();
    }
}