using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PoisonBullet : Bullet
{
    public float speed = 5f;

    [Header("SlowEffect Setting")]
    [SerializeField] PoisonDebuffData PoisonDebuff;


    void Update()
    {
        if (getTarget() == null)
        {
            DestroyThisGameObject();
            return;
        }

        transform.position = Vector3.MoveTowards(transform.position, getTarget().position, speed * Time.deltaTime);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Transform>().Equals(getTarget()))
        {
            HitTarget();
            ApplyDebuff();
        }
    }

    private void ApplyDebuff()
    {
        Enemy target = getTarget().GetComponent<Enemy>();
        if (target != null)
        {
            target.AddBuff(new PoisonDebuff(PoisonDebuff, getTarget().gameObject));
            // _poisonDebuff = new PoisonDebuff(target, Duration, interval, PoisonDamage);
            // target.AddDebuff(_poisonDebuff);
        }
    }
}
