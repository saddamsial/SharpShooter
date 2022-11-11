using DG.Tweening;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Zenject;

public class DefeatView : MonoBehaviour
{
    [Header("RectTransforms")]
    [SerializeField] private RectTransform[] rectTransformsToAnimate;

    [Header("Texts")]
    [SerializeField] private TextMeshProUGUI leveIndexText;

    [Header("Buttons")]
    [SerializeField] private Button restartButton;
    [SerializeField] private Button homeButton;

    [Inject] private GameController gameController;

    void Start()
    {
        //leveIndexText.text = $"Level {GameController.GameModel.currentlevelIndex + 1}";
        StartCoroutine(StartAnimation());

        restartButton.onClick.AddListener(ResetButtonPressed);
        homeButton.onClick.AddListener(HomeButtonPressed);
    }

    private IEnumerator StartAnimation()
    {
        foreach (var rectTransform in rectTransformsToAnimate)
        {
            rectTransform.transform.localScale = Vector3.one / 99;
        }
        yield return new WaitForSeconds(1f);

        foreach (var rectTransform in rectTransformsToAnimate)
        {
            Tween scaleTween = rectTransform.transform.DOScale(Vector3.one, 1f);
            scaleTween.SetEase(Ease.OutBack);
            yield return new WaitForSeconds(0.5f);
        }
    }
    private void ResetButtonPressed()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
    private void HomeButtonPressed()
    {
        //gameController.CreateLevel();
        //Destroy(gameObject);

        SceneManager.LoadScene(0);
    }
}