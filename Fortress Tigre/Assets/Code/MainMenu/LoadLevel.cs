using UnityEngine;

public class LoadLevel : MonoBehaviour
{
    public void OpenNewLevel(string LevelName)
    {
        Time.timeScale = 1;
        SoundPlayer.Instance.PlaySound("Click");
        ShowLoadingPanel.LoadLevel(LevelName);
    }
}
