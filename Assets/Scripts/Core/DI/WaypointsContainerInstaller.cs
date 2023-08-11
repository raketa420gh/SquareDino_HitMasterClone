using UnityEngine;
using Zenject;

public class WaypointsContainerInstaller : MonoInstaller
{
    [SerializeField] private WaypointsContainer _instance;
    
    public override void InstallBindings() => 
        Bind();

    private void Bind()
    {
        Container
            .Bind<IWaypointsContainer>()
            .To<WaypointsContainer>()
            .FromInstance(_instance)
            .AsSingle()
            .NonLazy();
    }
}