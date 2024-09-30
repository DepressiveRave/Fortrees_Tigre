using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(Button))]
public class UISkill : MonoBehaviour
{
    [Inject] Energy energy;
    [Inject] SkillController skillController;
    private Button SkillButton;
    [SerializeField] TextMeshProUGUI PriceText;

    private void Awake()
    {
        SkillButton = GetComponent<Button>();
        PriceText.text = skillController.EnergyPrice.ToString();
    }

    private void OnEnable()
    {
        energy.OnEnergyChange += ChangeButton;
    }

    private void OnDisable()
    {
        energy.OnEnergyChange -= ChangeButton;
    }

    private void ChangeButton(int energy)
    {
        if (energy < skillController.EnergyPrice)
        {
            SkillButton.interactable = false;
        }
        else
        {
            SkillButton.interactable = true;
        }
    }
}
