using UnityEngine;
using Zenject;

public class UnlockLevel : MonoBehaviour
{
    [Inject] ChoseBiom choseBiom;
    [Inject] SetLevelNumber _GetLevelNumber;
    public void UnLockLevel()
    {
        if(_GetLevelNumber.LevelNumber >= PlayerPrefs.GetInt("levels_" + choseBiom.ToString()))
        {
            PlayerPrefs.SetInt("levels_" +  choseBiom.ToString(), _GetLevelNumber.LevelNumber  + 1);
        }
    }
}
