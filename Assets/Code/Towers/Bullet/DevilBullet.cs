using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevilBullet : Bullet
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
