using UnityEngine;
using DG.Tweening;

public class UIPaused : MonoBehaviour
{
    [SerializeField] RectTransform _UiPausedPanel;
    [SerializeField] CanvasGroup _background;
    [SerializeField] float OpenTargetY;
    [SerializeField] float CloseTargetY;

    private void Awake()
    {
        _background.alpha = 0;
        _background.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void OpenPanel()
    {
        SoundPlayer.Instance.PlaySound("Click");
        _background.gameObject.SetActive(true);
        _UiPausedPanel.DOAnchorPosY(OpenTargetY, 0.5f);
        _background.DOFade(1f, 0.5f).OnComplete(() =>
        {
            Time.timeScale = 0;
        });
    }

    public void ClosePanel()
    {
        SoundPlayer.Instance.PlaySound("Click");
        Time.timeScale = 1;
        _UiPausedPanel.DOAnchorPosY(CloseTargetY, 0.5f);
        _background.DOFade(0f, 0.5f).OnComplete(() =>
        {
            _background.gameObject.SetActive(false);
        });
    }
}
