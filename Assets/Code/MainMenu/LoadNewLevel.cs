using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewLevel : MonoBehaviour
{
    [SerializeField] string SceneName;
    public void LoadScene()
    {
        SoundPlayer.Instance.PlaySound("Click");
        SceneManager.LoadScene(SceneName);
    }
}
