using UnityEngine;
using Lean.Pool;

public class ArcherTower : Towers
{

    [Header("Tower Setting")]
    public GameObject Character;
    public GameObject BulletPrefab;

    [Header("Animation Setting")]
    public static string IS_ATTACK = "isAttack";
    [SerializeField] Animator _animation;

    [Header("Tower Data")]
    [SerializeField] TowersData[] _towersData;

    [Header("Merge System")]
    [SerializeField] DragObject dragObject;


    private void Awake()
    {
        TowerVisual = GetComponent<SpriteRenderer>();
        InvokeRepeating("UpdateTarget", 0f, 0.1f);
        SetTowerDamage(_towersData[PlayerPrefs.GetInt("TowerLevel_" + towersList.ToString())].damage);
        SetFireRate(_towersData[PlayerPrefs.GetInt("TowerLevel_" + towersList.ToString())].fireRate);
        TowerVisual.sprite = _towersData[PlayerPrefs.GetInt("TowerLevel_" + towersList.ToString())].TowerSprite;
    }

    // Update is called once per frame
    void Update()
    {
        if (getTarget() != null)
        {
            if (getTarget().transform.position.x < Character.transform.position.x)
            {
                Character.GetComponent<SpriteRenderer>().flipX = true;
            }
            else
            {
                Character.GetComponent<SpriteRenderer>().flipX = false;
            }

            if (fireCountdown <= 0f)
            {
                Shoot();
                fireCountdown = fireRate;
            }
            fireCountdown -= Time.deltaTime;
        }
    }

    public void Shoot()
    {
        if (!dragObject.IsDrag)
        {
            _animation.SetTrigger(IS_ATTACK);

            GameObject arrowObject = LeanPool.Spawn(BulletPrefab, firePoint.position, Quaternion.identity);
            Arrow arrow = arrowObject.GetComponent<Arrow>();
            arrow.setDamage(GetTowerDamage());

            if (arrow != null)
            {
                arrow.Seek(getTarget());

                // Поворачиваем стрелу к монстру
                Vector3 targetDir = getTarget().position - arrowObject.transform.position;
                float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg;
                arrowObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            }
        }
    }
}
