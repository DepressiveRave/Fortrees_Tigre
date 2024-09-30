using UnityEngine;
using Zenject;

public class SkillInstaller : MonoInstaller
{
    [SerializeField] SkillSpawn skillSpawn;
    [SerializeField] SkillController skillController;
    public override void InstallBindings()
    {
        Container.Bind<SkillSpawn>().FromInstance(skillSpawn).NonLazy();
        Container.Bind<SkillController>().FromInstance(skillController).NonLazy();
    }
}