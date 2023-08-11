using Zenject;

public class UIControllerInstaller : MonoInstaller
{
    public override void InstallBindings() => 
        Bind();

    private void Bind()
    {
        BindUIController();
    }

    private void BindUIController()
    {
        Container
            .Bind<IUIController>()
            .To<UIController>()
            .AsSingle()
            .NonLazy();
    }
}