using DG.Tweening;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using Zenject;
using UnityEngine.UI;

public class LevelView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI levelIndexText;
    [SerializeField] private TextMeshProUGUI currentScore;

    [Inject] private GameController gameController;
    

    private void Start()
    {

    }

    public void UpdateView()
    {
        //filledImage.fillAmount += (float)(1f / levelSpawner.itemsAmount);

        //float to = filledImage.fillAmount + (float)(1f / levelSpawner.itemsAmount);
        //DOTween.To(() => filledImage.fillAmount, x => filledImage.fillAmount = x, to, 1);

        levelIndexText.text = $"Level {GameController.GameModel.currentlevelIndex + 1}";
        currentScore.text = $"Score {gameController.currentLevel.currentScore}/{gameController.currentLevel.scoreToWin}";
    }
}
