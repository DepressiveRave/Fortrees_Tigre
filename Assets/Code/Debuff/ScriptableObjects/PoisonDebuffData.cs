using UnityEngine;

[CreateAssetMenu(menuName = "Debuff/Poison")]
public class PoisonDebuffData : ScriptableBuff
{
    public float interval;
    public float damage;
    public override TimedBuff InitializeBuff(GameObject obj)
    {
        return new PoisonDebuff(this, obj);
    }
}
