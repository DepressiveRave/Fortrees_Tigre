using UnityEngine;

[CreateAssetMenu(menuName = "Debuff/Slowdown")]
public class SlowdownDebuffData : ScriptableBuff
{
    public float SpeedDecreasePercent;
    public override TimedBuff InitializeBuff(GameObject obj)
    {
        return new SlowdownDebuff(this, obj);
    }
}
