using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class UiSetStars : MonoBehaviour
{
    [SerializeField] Image _StarCounterImage;
    [Inject] GetStarsData _GetStarsData;
    [Inject] ChoseBiom choseBiom;
    [Inject] HeartSystem heartSystem;
    [Inject] SetLevelNumber _GetLevelNumber;
    [Inject] Stars stars;

    public void ChangeStarsCount()
    {
        int maxStars = 3; // Maximum stars that can be collected from a level
        int newStarsCount = heartSystem.health - 1;
        int savedStarsCount = PlayerPrefs.GetInt("Level_" + choseBiom.biomsList.ToString() + "_" + _GetLevelNumber.LevelNumber, -1);

        // Check if savedStarsCount is not the maximum and if newStarsCount is greater than savedStarsCount
        if (savedStarsCount < maxStars && newStarsCount > savedStarsCount)
        {
            // Clamp newStarsCount to ensure it doesn't exceed maxStars
            newStarsCount = Mathf.Min(newStarsCount, maxStars);
            PlayerPrefs.SetInt("Level_" + choseBiom.biomsList.ToString() + "_" + _GetLevelNumber.LevelNumber, newStarsCount);
            stars.AddStars(newStarsCount);
        }

        _StarCounterImage.sprite = _GetStarsData.starsData.GetStarsCount(newStarsCount);
    }
}
