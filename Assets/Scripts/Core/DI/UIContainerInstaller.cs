using UnityEngine;
using Zenject;

public class UIContainerInstaller : MonoInstaller
{
    [SerializeField] private UIContainer _instance;
    
    public override void InstallBindings() => 
        Bind();

    private void Bind()
    {
        Container
            .Bind<IUIContainer>()
            .To<UIContainer>()
            .FromInstance(_instance)
            .AsSingle()
            .NonLazy();
    }
}