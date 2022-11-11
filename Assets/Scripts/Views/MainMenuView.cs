using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MainMenuView : MonoBehaviour
{
    [SerializeField] private Button playButton;

    [SerializeField] private TextMeshProUGUI levelIndex;
    [SerializeField] private TextMeshProUGUI startAmountText;

    void Start()
    {
        playButton.onClick.AddListener(PlayButtonPressed);
        UpdateView();
    }

   public void UpdateView()
    {

    }
    private void PlayButtonPressed()
    {
        SceneManager.LoadScene(1);
    }
}
