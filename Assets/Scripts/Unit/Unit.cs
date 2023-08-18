using System;
using UnityEngine;
// ReSharper disable All

[RequireComponent(typeof(UnitView))]
[RequireComponent(typeof(UnitAnimator))]
[RequireComponent(typeof(NavMeshMovement))]
[RequireComponent(typeof(UnitRagdoll))]
[RequireComponent(typeof(Health))]
[RequireComponent(typeof(UnitLayerSelector))]

public class Unit : MonoBehaviour, IUnit
{
    public event Action OnThrow;
    public event Action OnDie;

    [SerializeField] private Transform _muzzle;
    [SerializeField] private HealthBar _healthBar;
    private UnitType _type = UnitType.Neutral;
    private UnitData _data;
    private IUnitView _view;
    private IUnitAnimator _animator;
    private IMovement _movement;
    private IUnitRagdoll _ragdoll;
    private IHealth _health;
    private UnitLayerSelector _layerSelector;

    public UnitType Type => _type;
    public UnitData Data => _data;
    public GameObject WorldObject => gameObject;
    public Transform MuzzlePoint => _muzzle;

    public void Initialize(UnitType type, UnitData data, Vector3 position)
    {
        _type = type;
        _data = data;
        _view =  GetComponent<IUnitView>();
        _animator = GetComponent<IUnitAnimator>();
        _movement = GetComponent<IMovement>();
        _ragdoll = GetComponent<IUnitRagdoll>();
        _health = GetComponent<IHealth>();
        _healthBar?.Initialize();
        _health.Setup(100);
        _health.OnOver += OnHealthOver;
        _animator.Initialize();
        _animator.OnThrow += OnThrowEvent;
        _layerSelector = GetComponent<UnitLayerSelector>();
        _layerSelector.SetLayer(type);

        _ragdoll.Deactivate();
        transform.position = position;
        _animator.PlayAnimation(UnitAnimationState.Idle);
        
        UpdateView();
    }

    public void MoveTo(Vector3 destination)
    {
        _movement.MoveTo(destination);
    }

    public void PlayAnimation(UnitAnimationState animationState)
    {
        _animator.PlayAnimation(animationState);
    }

    public void TakeDamage(int amount)
    {
        _health.ChangeHealth(-amount);
    }

    public void DeactivateHealthBar()
    {
        _healthBar.gameObject.SetActive(false);
    }

    public void Stop()
    {
        _movement.Stop();
    }

    public void Die()
    {
        _ragdoll.Activate();
        _healthBar.gameObject.SetActive(false);
        
        _view.ResetColor();
        
        _animator.Disable();
        _animator.OnThrow -= OnThrowEvent;
        _health.OnOver -= OnHealthOver;
        OnDie?.Invoke();
    }

    private void UpdateView()
    {
        _view.SetColor(_data.Color);
    }

    private void OnThrowEvent()
    {
        OnThrow?.Invoke();
    }

    private void OnHealthOver()
    {
        Die();
    }
}