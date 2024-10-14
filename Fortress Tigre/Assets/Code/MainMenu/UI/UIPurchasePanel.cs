using UnityEngine;
using DG.Tweening;

public class UIPurchasePanel : MonoBehaviour
{
    [SerializeField] RectTransform _UIPurchasePanel;
    [SerializeField] CanvasGroup _background;
    [SerializeField] float OpenTargetY;
    [SerializeField] float CloseTargetY;

    private void Awake()
    {
        _background.alpha = 0;
        _background.gameObject.SetActive(false);
    }

    public void OpenPanel()
    {
        SoundPlayer.Instance.PlaySound("Click");
        _background.gameObject.SetActive(true);
        _UIPurchasePanel.DOAnchorPosY(OpenTargetY, 0.5f);
        _background.DOFade(1f, 0.5f);
    }

    public void ClosePanel()
    {
        SoundPlayer.Instance.PlaySound("Click");
        _UIPurchasePanel.DOAnchorPosY(CloseTargetY, 0.5f);
        _background.DOFade(0f, 0.5f).OnComplete(() =>
        {
            _background.gameObject.SetActive(false);
        });
    }
}
