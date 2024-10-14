using UnityEngine;

public class FireDebuff : TimedBuff
{
    private readonly Enemy target;
    public FireDebuff(ScriptableBuff buff, GameObject obj) : base(buff, obj)
    {
        //Getting MovementComponent, replace with your own implementation
        target = obj.GetComponent<Enemy>();
    }
    protected override void ApplyEffect() { }
    public override void End() { }
    protected override void ApplyTick()
    {
        FireDebuffData FireDebuff = (FireDebuffData)Buff;
        TickRate = FireDebuff.interval;
        target.TakeDamage(FireDebuff.damage);
    }
}
