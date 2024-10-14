using UnityEngine;

public class SlowdownDebuff : TimedBuff
{
    private readonly Enemy target;

    public SlowdownDebuff(ScriptableBuff buff, GameObject obj) : base(buff, obj)
    {
        //Getting MovementComponent, replace with your own implementation
        target = obj.GetComponent<Enemy>();
    }

    protected override void ApplyEffect()
    {
        SlowdownDebuffData speedDeBuff = (SlowdownDebuffData)Buff;
        target.SetSpeed(target.enemyData.SpeedValue - (speedDeBuff.SpeedDecreasePercent * target.enemyData.SpeedValue / 100));
    }

    public override void End()
    {
        if (!target.GetIsDead())
            target.SetSpeed(target.enemyData.SpeedValue);
        else
            target.SetSpeed(0);
    }

    protected override void ApplyTick()
    {
        if (target.GetIsDead())
        {
            target.SetSpeed(0);
        }
    }
}
