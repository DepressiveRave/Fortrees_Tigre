using UnityEngine;
using Zenject;

public class TowerInstaller : MonoInstaller
{
    [SerializeField] TowerMergeSystem towerMergeSystem;
    public override void InstallBindings()
    {
        Container.Bind<TowerMergeSystem>().FromInstance(towerMergeSystem).NonLazy();
    }
}