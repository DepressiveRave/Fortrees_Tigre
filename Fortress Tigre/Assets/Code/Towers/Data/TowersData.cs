using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewTowerData", menuName = "Towers Stats/Data")]
public class TowersData : ScriptableObject
{
    public float fireRate;
    public float damage;
    public Sprite TowerSprite;
}
