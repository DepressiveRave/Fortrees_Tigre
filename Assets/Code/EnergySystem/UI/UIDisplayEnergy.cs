using TMPro;
using UnityEngine;
using Zenject;

public class UIDisplayEnergy : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI EnergyCountText;
    [Inject] private Energy energy;
    private void Awake()
    {
        UpdateValue(energy.energy);
    }

    private void OnEnable()
    {
        energy.OnEnergyChange += UpdateValue;
    }

    private void OnDisable()
    {
        energy.OnEnergyChange -= UpdateValue;
    }

    private void UpdateValue(int value)
    {
        if (energy == null) return;
        EnergyCountText.text = value.ToString();
    }
}
