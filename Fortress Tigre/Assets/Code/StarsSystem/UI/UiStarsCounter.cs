using TMPro;
using UnityEngine;
using Zenject;
public class UiStarsCounter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI starsCounterText;
    [Inject] Stars stars;
    private void Awake()
    {
        starsCounterText.text = PlayerPrefs.GetInt("Stars").ToString(); ;
    }

    private void OnEnable()
    {
        stars.OnStarsChange += ChangeStarsCount;
    }

    private void OnDisable()
    {
        stars.OnStarsChange -= ChangeStarsCount;
    }

    private void ChangeStarsCount(int stars)
    {
        starsCounterText.text = stars.ToString();
    }
}
