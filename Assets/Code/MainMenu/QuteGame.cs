using UnityEngine;

public class QuteGame : MonoBehaviour
{
    public void Qute()
    {
        SoundPlayer.Instance.PlaySound("Click");
        Application.Quit();
    }
}
