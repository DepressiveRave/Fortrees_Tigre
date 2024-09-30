using UnityEngine;
using Zenject;

public class StarsInstaller : MonoInstaller
{
    [SerializeField] Stars stars;
    public override void InstallBindings()
    {
        Container.Bind<Stars>().FromInstance(stars).NonLazy();
    }
}