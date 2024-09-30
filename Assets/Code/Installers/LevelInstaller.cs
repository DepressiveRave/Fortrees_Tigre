using UnityEngine;
using Zenject;

public class LevelInstaller : MonoInstaller
{
    [SerializeField] SetLevelNumber _SetLevelNumber;
    public override void InstallBindings()
    {
        Container.Bind<SetLevelNumber>().FromInstance(_SetLevelNumber).NonLazy();
    }
}