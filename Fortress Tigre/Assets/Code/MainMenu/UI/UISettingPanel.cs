using UnityEngine;
using DG.Tweening;

public class UISettingPanel : MonoBehaviour
{
    [SerializeField] RectTransform _UISettingPanel;
    [SerializeField] CanvasGroup _background;
    [SerializeField] float OpenTargetY;
    [SerializeField] float CloseTargetY;

    private void Start()
    {
        _background.alpha = 0;
        _background.gameObject.SetActive(false);
        _UISettingPanel.localPosition = new Vector3(0, CloseTargetY, 0);
    }

    public void OpenPanel()
    {
        SoundPlayer.Instance.PlaySound("Click");
        _background.gameObject.SetActive(true);
        _UISettingPanel.DOAnchorPosY(OpenTargetY, 0.5f);
        _background.DOFade(1f, 0.5f);
    }

    public void ClosePanel()
    {
        SoundPlayer.Instance.PlaySound("Click");
        _UISettingPanel.DOAnchorPosY(CloseTargetY, 0.5f);
        _background.DOFade(0f, 0.5f).OnComplete(() =>
        {
            _background.gameObject.SetActive(false);
        });
    }
}
