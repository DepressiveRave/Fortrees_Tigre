using TMPro;
using UnityEngine;
using Zenject;
using UnityEngine.UI;

public class UIBuyTower : MonoBehaviour
{
    public TextMeshProUGUI priceText;
    [SerializeField] private int basePrice = 10;
    [SerializeField] Button BuyButton;
    private int currentPrice;
    [Inject] private Energy energy;
    [Inject] private TowerMergeSystem towerMergeSystem;

    // Start is called before the first frame update
    void Awake()
    {
        currentPrice = basePrice;
        UpdatePriceText();
    }

    private void Update()
    {
        InteractiableButton(energy.energy);
    }

    public void BuyTower()
    {
        if (towerMergeSystem.AllSlotsOccupied())
        {
            Debug.Log("No empty slot available!");
            return;
        }


        if (CanAffordTower())
        {
            SoundPlayer.Instance.PlaySound("Build");
            // Добавьте код для покупки башни здесь
            towerMergeSystem.PlaceItem();
            Debug.Log("Башня куплена за " + currentPrice + " монет");
            energy.TakeEnergy(currentPrice); // Вычитаем стоимость башни из монет игрока
            IncreasePrice();
            UpdatePriceText();
        }
        else
        {
            Debug.Log("Недостаточно средств для покупки башни");
        }
    }

    private void InteractiableButton(int value)
    {
        if (value < currentPrice)
        {
            BuyButton.interactable = false;
        }
        else
        {
            BuyButton.interactable = true;
        }
    }

    private void IncreasePrice()
    {
        currentPrice += basePrice; // Увеличение цены на базовую стоимость
    }

    private bool CanAffordTower()
    {
        return energy.energy >= currentPrice; // Проверяем, достаточно ли у игрока монет для покупки
    }

    private void UpdatePriceText()
    {
        priceText.text = currentPrice.ToString();
    }
}
