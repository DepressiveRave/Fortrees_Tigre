using UnityEngine;

[CreateAssetMenu(menuName = "Debuff/Fire")]
public class FireDebuffData : ScriptableBuff
{
    public float interval;
    public float damage;
    public override TimedBuff InitializeBuff(GameObject obj)
    {
        return new FireDebuff(this, obj);
    }
}
