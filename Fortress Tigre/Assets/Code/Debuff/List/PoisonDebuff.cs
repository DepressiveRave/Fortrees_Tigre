using UnityEngine;

public class PoisonDebuff : TimedBuff
{
    private readonly Enemy target;
    public PoisonDebuff(ScriptableBuff buff, GameObject obj) : base(buff, obj)
    {
        //Getting MovementComponent, replace with your own implementation
        target = obj.GetComponent<Enemy>();
    }
    protected override void ApplyEffect() { }
    public override void End() { }
    protected override void ApplyTick()
    {
        PoisonDebuffData PoisonDeBuff = (PoisonDebuffData)Buff;
        TickRate = PoisonDeBuff.interval;
        target.TakeDamage(PoisonDeBuff.damage);
        //Debug.Log("Poison Debuff: " + PoisonDeBuff.damage);
    }
}
