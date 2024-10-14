using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[Serializable]
public class UpgradeTower
{
    public TowersList towersList;
    public TextMeshProUGUI priceText;
    public Button BuyButton;
    public int maxTowerLevel;
    public int TowerLevel;
}
public class UITowerUpgrade : UpgradeSystem
{
    [SerializeField] UpgradeTower[] upgradeTower;

    void Awake()
    {
        for (int i = 0; i < upgradeTower.Length; i++)
        {
            currentPrice = LoadCurrentPrice(i); // Завантажуємо значення з PlayerPrefs
            UpdatePriceText(i, upgradeTower[i].priceText);
            upgradeTower[i].TowerLevel = LoadTowerLevel(i);
            MaxUpgrade(i);
        }
    }

    public override void BuyUpgrade(int ID)
    {
        if (CanAffordUpgrade(ID))
        {
            if (upgradeTower[ID].TowerLevel < upgradeTower[ID].maxTowerLevel)
            {
                SoundPlayer.Instance.PlaySound("Click");
                stars.TakeStars(currentPrice);
                upgradeTower[ID].TowerLevel++;
                IncreasePrice(ID);
                SaveCurrentPrice(currentPrice, ID);
                SaveTowerLevel(upgradeTower[ID].TowerLevel, ID);
                UpdatePriceText(ID, upgradeTower[ID].priceText);

                // Проверяем, достигла ли башня максимального уровня
                MaxUpgrade(ID);
            }
            else
            {
                Debug.Log("Башня достигла максимального уровня");
                // Здесь можно добавить дополнительные действия при достижении максимального уровня
            }
        }
        else
        {
            Debug.Log("Недостаточно средств для улучшения башни");
        }
    }

    private void SaveTowerLevel(int level, int ID)
    {
        PlayerPrefs.SetInt("TowerLevel_" + upgradeTower[ID].towersList.ToString(), level);
    }

    private int LoadTowerLevel(int ID)
    {
        return PlayerPrefs.GetInt("TowerLevel_" + upgradeTower[ID].towersList.ToString(), 0);
    }

    private void MaxUpgrade(int ID)
    {
        if (upgradeTower[ID].TowerLevel >= upgradeTower[ID].maxTowerLevel)
        {
            // Делаем кнопку недоступной
            upgradeTower[ID].BuyButton.interactable = false;
            UpdatePriceTextMax(ID, upgradeTower[ID].priceText);
        }
    }
}
