using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class PopUpView : MonoBehaviour
{
    [SerializeField] private GameObject screen;
    [SerializeField] private Button closeButton;
    [SerializeField] private TextMeshProUGUI text;

    void Start()
    {
        closeButton.onClick.AddListener(CloseButtonPressed);
    }

    private void CloseButtonPressed()
    {
        //base.CloseScreen(screen, gameObject);
    }
}
