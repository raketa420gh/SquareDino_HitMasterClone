using UnityEngine;
using Zenject;

public class ProjectileFactory : IProjectileFactory
{
    private IAssetProvider _assetProvider;
    private string _bulletPath = "Prefabs/Bullet";
    
    [Inject]
    public void Construct(IAssetProvider assetProvider) => 
        _assetProvider = assetProvider;
    
    public IProjectile CreateBullet(Vector3 position, Vector3 direction)
    {
        var path = new string(_bulletPath);
        var go = _assetProvider.Instantiate(path, position);
        var bullet = go.GetComponent<IProjectile>();
        bullet.SetDirection(direction);

        return bullet;
    }
}