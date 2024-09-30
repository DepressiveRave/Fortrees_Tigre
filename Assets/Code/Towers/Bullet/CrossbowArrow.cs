using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CrossbowArrow : Bullet
{
    public float speed = 5f;

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
        }
    }
}
