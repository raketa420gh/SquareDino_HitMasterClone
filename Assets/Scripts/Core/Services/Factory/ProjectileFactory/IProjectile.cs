using UnityEngine;

public interface IProjectile
{
    float FlySpeed { get; }

    void SetDirection(Vector3 direction);
}