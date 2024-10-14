using UnityEngine;

public class SlowdownBullet : Bullet
{
    [SerializeField] float speed = 5f;
    // private SlowdownDebuff slowDownDebuff;

    [Header("SlowEffect Setting")]
    [SerializeField] SlowdownDebuffData SlowdownDebuff;

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
            target.AddBuff(new SlowdownDebuff(SlowdownDebuff, getTarget().gameObject));
        }
    }
}
