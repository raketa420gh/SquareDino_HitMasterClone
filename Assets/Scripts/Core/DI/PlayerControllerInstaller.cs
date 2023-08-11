using UnityEngine;
using Zenject;

public class PlayerControllerInstaller : MonoInstaller
{
    [SerializeField] private PlayerController _instance;
    
    public override void InstallBindings() => 
        Bind();

    private void Bind()
    {
        BindPlayerController();
    }

    private void BindPlayerController()
    {
        Container
            .Bind<IPlayerController>()
            .FromInstance(_instance)
            .AsSingle()
            .NonLazy();
    }
}