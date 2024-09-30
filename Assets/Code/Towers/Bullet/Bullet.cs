using UnityEngine;
using Lean.Pool;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public Rigidbody2D rb;

    private float damage;

    public void Seek(Transform target)
    {
        this.target = target;
    }

    public void HitTarget()
    {
        Damage(target);
        LeanPool.Despawn(gameObject);
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

    public void DestroyThisGameObject()
    {
        LeanPool.Despawn(gameObject);
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
