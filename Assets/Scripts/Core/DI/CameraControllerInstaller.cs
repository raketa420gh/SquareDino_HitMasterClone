using UnityEngine;
using Zenject;

public class CameraControllerInstaller : MonoInstaller
{
    [SerializeField] private CameraController _instance;

    public override void InstallBindings() => 
        Bind();

    private void Bind()
    {
        BindCameraController();
    }

    private void BindCameraController()
    {
        Container
            .Bind<ICameraController>()
            .FromInstance(_instance)
            .AsSingle()
            .NonLazy();
    }
}