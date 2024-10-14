using Lean.Pool;
using UnityEngine;

public class SKill : MonoBehaviour
{
    private Transform target;
    private float damage;

    public void Seek(Transform target)
    {
        this.target = target;
    }

    public void HitTarget()
    {
        Damage(target);
    }

    public void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();

        if (e != null)
        {
            e.TakeDamage(damage);
            Debug.Log(enemy.name + " Damaged: " + damage);
        }
    }

    public Transform getTarget()
    {
        return target;
    }

    public float getDamage()
    {
        return damage;
    }

    public void setDamage(float damage)
    {
        this.damage = damage;
    }
}
