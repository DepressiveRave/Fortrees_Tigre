using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;
using DG.Tweening;

public class UIFail : MonoBehaviour
{
    [Inject] HeartSystem heartSystem;
    [SerializeField] RectTransform _UiFailPanel;
    [SerializeField] CanvasGroup _background;
    [SerializeField] float OpenTargetY;

    private void Awake()
    {
        _background.alpha = 0;
        _background.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    private void OnEnable()
    {
        heartSystem.OnHealthChange += OpenFailMenu;
    }

    private void OnDisable()
    {
        heartSystem.OnHealthChange -= OpenFailMenu;
    }

    private void OpenFailMenu(int health)
    {
        if (health <= 0)
        {
            SoundPlayer.Instance.PlaySound("Lose");
            _background.gameObject.SetActive(true);
            _UiFailPanel.DOAnchorPosY(OpenTargetY, 0.5f);
            _background.DOFade(1f, 0.5f).OnComplete(() =>
            {
                Time.timeScale = 0;
            });
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
