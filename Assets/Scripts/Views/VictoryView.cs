using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Zenject;
using UnityEngine.SceneManagement;

public class VictoryView : MonoBehaviour
{
    [Header("RectTransforms")]
    [SerializeField] private RectTransform[] rectTransformsToAnimate;

    [Header("Texts")]
    [SerializeField] private TextMeshProUGUI leveIndexText;

    [Header("Buttons")]
    [SerializeField] private Button nextLevelButton;

    [Header("Effects")]
    [SerializeField] private ParticleSystem confetti;

    [Inject] private GameController gameController;



    void Start()
    {
        //leveIndexText.text = $"Level {GameController.GameModel.currentlevelIndex + 1}";
        StartCoroutine(StartAnimation());

        nextLevelButton.onClick.AddListener(NextLevelButtonPressed);
        confetti.gameObject.SetActive(true);

    }
    private IEnumerator StartAnimation()
    {
        foreach (var rectTransform in rectTransformsToAnimate)
        {
            rectTransform.transform.localScale = Vector3.one / 999;
        }
        yield return new WaitForSeconds(0.25f);

        foreach (var rectTransform in rectTransformsToAnimate)
        {
            Tween scaleTween = rectTransform.transform.DOScale(Vector3.one, 1f);
            scaleTween.SetEase(Ease.OutBack);
            yield return new WaitForSeconds(0.5f);
        }
    }
    private void NextLevelButtonPressed()
    {
        //gameController.CreateLevel();
        //Destroy(gameObject);

        SceneManager.LoadScene(0);
    }
}
