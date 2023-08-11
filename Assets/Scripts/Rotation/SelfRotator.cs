using UnityEngine;

[RequireComponent(typeof(Rotatable))]
[RequireComponent(typeof(Rotator))]

public class SelfRotator : MonoBehaviour
{
    [SerializeField] private float _speed = 25f;
    private Rotatable _rotatable;
    private Rotator _rotator;

    private void Awake()
    {
        _rotatable = GetComponent<Rotatable>();
        _rotator = GetComponent<Rotator>();
        
        _rotator.SetRotateSettings(_rotatable, Vector3.up, _speed);
    }
}