using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private Vector3 _axis = Vector3.zero;
    [SerializeField] [Range(0, 1000)] private float _speed;
    [SerializeField] private Rotatable _rotatable;

    private void Update()
    {
        _rotatable.Rotate(_axis, _speed);
    }

    public void SetRotateSettings(Rotatable rotatable, Vector3 axis, float speed)
    {
        _rotatable = rotatable;
        _axis = axis;
        _speed = speed;
    }
}