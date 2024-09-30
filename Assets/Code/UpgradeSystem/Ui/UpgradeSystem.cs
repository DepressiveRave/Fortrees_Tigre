using TMPro;
using UnityEngine;
using Zenject;

public abstract class UpgradeSystem : MonoBehaviour
{
    public int basePrice;
    public CategoryList UpgradeCategoruName;
    protected int currentPrice;
    [Inject] protected Stars stars;

    public abstract void BuyUpgrade(int ID);

    protected void IncreasePrice(int ID)
    {
        currentPrice = LoadCurrentPrice(ID);
        currentPrice += basePrice; // Увеличение цены на базовую стоимость
    }

    protected bool CanAffordUpgrade(int ID)
    {
        currentPrice = LoadCurrentPrice(ID);
        return stars.stars >= currentPrice; // Проверяем, достаточно ли у игрока монет для покупки
    }

    protected void UpdatePriceText(int ID, TextMeshProUGUI priceText)
    {
        currentPrice = LoadCurrentPrice(ID);
        priceText.text = currentPrice.ToString();
    }

    protected void UpdatePriceTextMax(int ID, TextMeshProUGUI priceText)
    {
        priceText.text = "MAX";
    }

    protected void SaveCurrentPrice(int value, int ID)
    {
        PlayerPrefs.SetInt("CurrentPrice_ID_" + UpgradeCategoruName.ToString() + ID.ToString(), value);
        PlayerPrefs.Save();
    }

    protected int LoadCurrentPrice(int ID)
    {
        return PlayerPrefs.GetInt("CurrentPrice_ID_" + UpgradeCategoruName.ToString() + ID.ToString(), basePrice); // basePrice - значення за замовчуванням, якщо ключ не знайдено
    }

    [ContextMenu("AddStars")]
    public void AddStars()
    {
        stars.AddStars(3);
    }
}
