using UnityEngine;
using Zenject;

public class EnergyInstaller : MonoInstaller
{
    [SerializeField] Energy energy;
    public override void InstallBindings()
    {
        Container.Bind<Energy>().FromInstance(energy).NonLazy();
    }
}