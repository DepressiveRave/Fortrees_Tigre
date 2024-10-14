using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class UIUnlockLevels : MonoBehaviour
{
    [Inject] ChoseBiom choseBiom;
    private int levelUnLock;
    [SerializeField] Button[] buttons;

    void Start()
    {
        levelUnLock = PlayerPrefs.GetInt("levels_" + choseBiom.ToString(), 1);

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }

        int maxUnlockableLevels = Mathf.Min(levelUnLock, buttons.Length);

        for (int i = 0; i < maxUnlockableLevels; i++)
        {
            buttons[i].interactable = true;
        }
    }

}
