using DG.Tweening;
using UnityEngine;

public class UIAnimatorController : MonoBehaviour
{
    private static float animationTime = 0.65f;

    public static void OpenScreen(GameObject screen, float targetFade = 1f)
    {
        CanvasGroup canvasGroup = null;
        Transform screenTransform = screen.transform.GetChild(1).transform;

        if (!screen.GetComponent<CanvasGroup>()) canvasGroup = screen.AddComponent<CanvasGroup>();
        else canvasGroup = screen.GetComponent<CanvasGroup>();

        screen.transform.GetChild(0).gameObject.SetActive(true);
        //screen.transform.GetChild(0).GetComponent<Image>().DOFade(targetFade, 0.15f);
        screenTransform.gameObject.SetActive(true);

        canvasGroup.alpha = 0;
        screenTransform.DOScale(0.01f, 0);

        screen.gameObject.SetActive(true);
        var tweenScale = screenTransform.DOScale(1, animationTime);
        var tweenFade = canvasGroup.DOFade(1, animationTime);

        tweenScale.SetEase(Ease.OutBack);
        tweenFade.SetEase(Ease.OutBack);
    }
    public static void CloseScreen(GameObject screen, GameObject canvas)
    {
        var tweenFade = screen.transform.GetChild(1).DOScale(0.01f, animationTime);
        var tweenScale = screen.GetComponent<CanvasGroup>().DOFade(0f, 0.4f).OnComplete(() =>
        {
            screen.SetActive(false);
            Destroy(canvas);
        });
        tweenScale.SetEase(Ease.InBack);
        tweenFade.SetEase(Ease.InBack);
    }
}
