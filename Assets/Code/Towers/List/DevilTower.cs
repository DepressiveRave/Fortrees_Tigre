using Lean.Pool;
using UnityEngine;

public class DevilTower : Towers
{
    [Header("Tower Setting")]
    private int FirePosIndex;
    [SerializeField] GameObject[] Character;
    public GameObject BulletPrefab;

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
        Character[PlayerPrefs.GetInt("TowerLevel_" + towersList.ToString())].SetActive(true);
        FirePosIndex = PlayerPrefs.GetInt("TowerLevel_" + towersList.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        if (getTarget() != null)
        {
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
            GameObject arrowObject = LeanPool.Spawn(BulletPrefab, Character[FirePosIndex].transform.position, Quaternion.identity);
            DevilBullet arrow = arrowObject.GetComponent<DevilBullet>();
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
