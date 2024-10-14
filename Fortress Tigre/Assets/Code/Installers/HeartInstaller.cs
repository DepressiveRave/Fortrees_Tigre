using UnityEngine;
using Zenject;

public class HeartInstaller : MonoInstaller
{
    [SerializeField] HeartSystem HeartSystem;
    public override void InstallBindings()
    {
        Container.Bind<HeartSystem>().FromInstance(HeartSystem).NonLazy();
    }
}