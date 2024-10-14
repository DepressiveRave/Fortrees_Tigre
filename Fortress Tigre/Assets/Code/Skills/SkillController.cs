using UnityEngine;
using Zenject;

public class SkillController : MonoBehaviour
{
    [Inject] private SkillSpawn skillSpawn;
    [Inject] private Energy energy;
    public int EnergyPrice;
    private int getID;
    public void GetSkill(int ID)
    {
        if (energy.energy >= EnergyPrice)
        {
            getID = ID;
            skillSpawn.Get();
            energy.TakeEnergy(EnergyPrice);
        }
    }

    public void UseSkill()
    {
        skillSpawn.Use(getID);
    }
}
