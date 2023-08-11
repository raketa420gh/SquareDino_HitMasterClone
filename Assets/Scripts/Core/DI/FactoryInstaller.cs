using Zenject;

public class FactoryInstaller : MonoInstaller
{
    public override void InstallBindings() => 
        Bind();

    private void Bind()
    {
        BindUnitFactory();
        BindProjectileFactory();
    }

    private void BindUnitFactory()
    {
        Container
            .Bind<IUnitFactory>()
            .To<UnitFactory>()
            .AsSingle()
            .NonLazy();
    }

    private void BindProjectileFactory()
    {
        Container
            .Bind<IProjectileFactory>()
            .To<ProjectileFactory>()
            .AsSingle()
            .NonLazy();
    }
}