using UnityEngine;

public interface IRotatable
{
    public void Rotate(Vector3 direction, float speed);
    public void LookAtOnlyY(Vector3 targetWorldPosition);
}