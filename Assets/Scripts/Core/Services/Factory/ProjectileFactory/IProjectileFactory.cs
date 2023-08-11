using UnityEngine;

public interface IProjectileFactory
{
    IProjectile CreateBullet(Vector3 position, Vector3 direction);
}