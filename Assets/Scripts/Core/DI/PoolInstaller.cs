using UnityEngine;
using Zenject;

public class PoolInstaller : MonoInstaller
{
    [SerializeField] private BulletsPool _bulletPoolInstance;

    public override void InstallBindings() => 
        Bind();

    private void Bind()
    {
        BindBulletsPool();
    }

    private void BindBulletsPool()
    {
        Container
            .Bind<BulletsPool>()
            .FromInstance(_bulletPoolInstance)
            .AsSingle()
            .NonLazy();
    }
}