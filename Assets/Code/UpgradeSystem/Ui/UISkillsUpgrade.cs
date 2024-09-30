using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class UpgradeSkills
{
    public SkillsList skillList;
    public TextMeshProUGUI priceText;
    public Button BuyButton;
    public int maxSkillLevel;
    public int SkillLevel;
}

public class UISkillsUpgrade : UpgradeSystem
{
    [SerializeField] UpgradeSkills[] upgradeTower;

    void Awake()
    {
        for (int i = 0; i < upgradeTower.Length; i++)
        {
            currentPrice = LoadCurrentPrice(i); // Завантажуємо значення з PlayerPrefs
            UpdatePriceText(i, upgradeTower[i].priceText);
            upgradeTower[i].SkillLevel = LoadTowerLevel(i);
            MaxUpgrade(i);
        }
    }

    public override void BuyUpgrade(int ID)
    {
        if (CanAffordUpgrade(ID))
        {
            if (upgradeTower[ID].SkillLevel < upgradeTower[ID].maxSkillLevel)
            {
                SoundPlayer.Instance.PlaySound("Click");
                stars.TakeStars(currentPrice);
                upgradeTower[ID].SkillLevel++;
                IncreasePrice(ID);
                SaveCurrentPrice(currentPrice, ID);
                SaveTowerLevel(upgradeTower[ID].SkillLevel, ID);
                UpdatePriceText(ID, upgradeTower[ID].priceText);

                // Проверяем, достигла ли башня максимального уровня
                MaxUpgrade(ID);
            }
            else
            {
                Debug.Log("Навык достиг максимального уровня");
                // Здесь можно добавить дополнительные действия при достижении максимального уровня
            }
        }
        else
        {
            Debug.Log("Недостаточно средств для улучшения навыка");
        }
    }

    private void SaveTowerLevel(int level, int ID)
    {
        PlayerPrefs.SetInt("SkillLevel_" + upgradeTower[ID].skillList.ToString(), level);
    }

    private int LoadTowerLevel(int ID)
    {
        return PlayerPrefs.GetInt("SkillLevel_" + upgradeTower[ID].skillList.ToString(), 0);
    }

    private void MaxUpgrade(int ID)
    {
        if (upgradeTower[ID].SkillLevel >= upgradeTower[ID].maxSkillLevel)
        {
            // Делаем кнопку недоступной
            upgradeTower[ID].BuyButton.interactable = false;
            UpdatePriceTextMax(ID, upgradeTower[ID].priceText);
        }
    }
}
