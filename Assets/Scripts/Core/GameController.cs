using UnityEngine.SceneManagement;
using UnityEngine;
using Zenject;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
    public const int headShotScore = 25;
    public const int regularShotScore = 10;
    public static GameModel GameModel { get; private set; }

    [Inject] private BaseView baseView;

    public bool isPlayingLevel { get; set; }

    public LevelController[] levels;
    public LevelController currentLevel;

    [Inject] DiContainer diContainer;
    [Inject] LevelView levelView;

    private void Awake()
    {
        GameModel = new GameModel();
        LoadGame();
    }
    private void Start()
    {
        Application.targetFrameRate = 120;

        CreateLevel();
    }
    public void Victory()
    {
        if (isPlayingLevel)
        {
            baseView.OpenScreen(ScreenType.Victory);
            isPlayingLevel = false;
            GameModel.currentlevelIndex++;
            SaveGame();
        }
    }
    public void CreateLevel()
    {
        if(GameModel.currentlevelIndex >= levels.Length)
        {
            GameModel.currentlevelIndex = 0;
        }
        if(currentLevel != null)
        {
            Destroy(currentLevel.gameObject);
        }
        currentLevel = diContainer.InstantiatePrefabForComponent<LevelController>(levels[GameModel.currentlevelIndex]);
        levelView.UpdateView();
        isPlayingLevel = true;
    }
    public void Defeat()
    {
        if(isPlayingLevel)
        baseView.OpenScreen(ScreenType.Defeat);
    }
    public static void SaveGame()
    {
        SavingSystem<GameModel>.SaveJsonData(GameModel);
    }
    public static void LoadGame()
    {
        GameModel = SavingSystem<GameModel>.LoadJsonData();
    }
    public static void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }
}
