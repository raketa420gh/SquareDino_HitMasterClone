using System;
using UnityEngine;

public class UnitAnimator : MonoBehaviour, IUnitAnimator
{
    public event Action OnThrow;
    
    [SerializeField] private Animator _animator;
    [SerializeField] private UnitAttackAnimationEvent _attackAnimationEvent;
    private static readonly int _idleKey = Animator.StringToHash("Idle");
    private static readonly int _walkKey = Animator.StringToHash("Walk");
    private static readonly int _runKey = Animator.StringToHash("Run");
    private static readonly int _attackKey = Animator.StringToHash("Attack");
    
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
                SetAnimationTrigger(_idleKey);
                break;
            case UnitAnimationState.Walk:
                SetAnimationTrigger(_walkKey);
                break;
            case UnitAnimationState.Run:
                SetAnimationTrigger(_runKey);
                break;
            case UnitAnimationState.Attack:
                SetAnimationTrigger(_attackKey);
                break;
        }
    }

    private void SetAnimationTrigger(string triggerName) => 
        _animator.SetTrigger(triggerName);

    private void SetAnimationTrigger(int id) => 
        _animator.SetTrigger(id);

    private void OnThrowEvent()
    {
        OnThrow?.Invoke();
    }
}