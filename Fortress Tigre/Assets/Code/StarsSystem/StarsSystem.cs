using UnityEngine.UI;
using UnityEngine;
using Zenject;
public class StarsSystem : MonoBehaviour
{
    [SerializeField] Image StarsImage;
    [SerializeField] int LevelNumber;
    [Inject] GetStarsData _GetStarsData;
    [Inject] ChoseBiom BionName;
    private int StarsCount;
    void Start()
    {
        StarsCount = PlayerPrefs.GetInt("Level_" + BionName.biomsList.ToString() + "_" + LevelNumber, 0);
        StarsImage.sprite = _GetStarsData.starsData.GetStarsCount(StarsCount);
    }
}
