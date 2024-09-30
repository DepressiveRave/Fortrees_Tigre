using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;


public class UiWin : MonoBehaviour
{
    [SerializeField] RectTransform _UiWinPanel;
    [SerializeField] CanvasGroup _background;
    [SerializeField] float OpenTargetY;
    public bool IsWin;

    private void Awake()
    {
        IsWin = false;
        _background.alpha = 0;
        _background.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void OpenWinMenu()
    {
        SoundPlayer.Instance.PlaySound("Win");
        IsWin = true;
        _background.gameObject.SetActive(true);
        _UiWinPanel.DOAnchorPosY(OpenTargetY, 0.5f);
        _background.DOFade(1f, 0.5f).OnComplete(() =>
        {
            Time.timeScale = 0;
        });
    }

    public void NextLevel(string LevelName)
    {
        SceneManager.LoadScene(LevelName);
    }
}
