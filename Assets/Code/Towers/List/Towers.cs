using UnityEngine;
public abstract class Towers : MonoBehaviour
{
    [SerializeField] protected float range = 0f;
    [SerializeField] public TowersList towersList;
    protected SpriteRenderer TowerVisual;
    protected float fireRate = 1f;
    private float damage = 10f;
    [SerializeField] protected Transform firePoint;

    private Transform target;
    private Enemy targetEnemy;
    public string ENEMY_TAG = "Enemy";
    protected float fireCountdown = 0f;

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(ENEMY_TAG);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<Enemy>();
        }
        else
        {
            target = null;
        }

    }

    public float GetRange()
    {
        return range;
    }

    public void SetRange(float range)
    {
        this.range = range;
    }

    public Transform getTarget()
    {
        return target;
    }

    public Enemy getTargetEnemy()
    {
        return targetEnemy;
    }

    public void SetTowerDamage(float damage)
    {
        this.damage = damage;
    }

    public float GetTowerDamage()
    {
        return damage;
    }

    public float GetFireRate()
    {
        return fireRate;
    }

    public void SetFireRate(float fireRate)
    {
        this.fireRate = fireRate;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
