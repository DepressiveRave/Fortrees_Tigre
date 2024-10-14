using UnityEngine;
using Zenject;

public class StarsSystemInstaller : MonoInstaller
{
    [SerializeField] ChoseBiom choseBiom;
    [SerializeField] GetStarsData getStarsData;
    public override void InstallBindings()
    {
        Container.Bind<ChoseBiom>().FromInstance(choseBiom).Lazy();
        Container.Bind<GetStarsData>().FromInstance(getStarsData).Lazy();
    }
}