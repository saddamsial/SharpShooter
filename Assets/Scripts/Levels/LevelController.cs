using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LevelController : MonoBehaviour
{
    public List<AnimalsController> currentLevelAnimals = new List<AnimalsController>();

    public int scoreToWin = 100;
    public int currentScore = 0;

    [Inject] private GameController gameController;

    void Start()
    {
        
    }

    public void CheckResult()
    {
        if(currentLevelAnimals.Count == 0)
        {
            if (currentScore >= scoreToWin)
            {
                gameController.Victory();
            }
            else gameController.Defeat();

            gameController.isPlayingLevel = false;
        }
    }
}
