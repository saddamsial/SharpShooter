using UnityEngine;
using Zenject;

public class BaseView : MonoBehaviour
{
    private static DefeatView DefeatView;
    private static VictoryView VictoryView;
    private static PopUpView PopUpView;
    //private static ShopView ShopView;


    [Inject] DiContainer DiContainer;
    [SerializeField] private Camera UICamera;

    void Awake()
    {
        DefeatView = Resources.Load<DefeatView>("Screens/DefeatView");
        VictoryView = Resources.Load<VictoryView>("Screens/VictoryView");
        PopUpView = Resources.Load<PopUpView>("Screens/PopUpView");
        //ShopView = Resources.Load<ShopView>("Screens/ShopView");

        DontDestroyOnLoad(gameObject);
    }
    public GameObject OpenScreen(ScreenType screenType, float targetFade = 1f)
    {
        GameObject screen = null;

        if (screenType == ScreenType.Defeat)
        {
            screen = DiContainer.InstantiatePrefab(DefeatView);
            //screen = Instantiate(DefeatView.gameObject);
        }
        else if (screenType == ScreenType.Victory)
        {
            screen = DiContainer.InstantiatePrefab(VictoryView);
            //screen = Instantiate(VictoryView.gameObject);
        }
        else if (screenType == ScreenType.PopUp)
        {
            screen = DiContainer.InstantiatePrefab(VictoryView);
            //screen = Instantiate(PopUpView.gameObject);
        }

        screen.GetComponent<Canvas>().worldCamera = UICamera;

        UIAnimatorController.OpenScreen(screen.transform.GetChild(0).gameObject, targetFade);

        return screen;
    }
    public void CloseScreen(GameObject screen, GameObject canvas)
    {
        UIAnimatorController.CloseScreen(screen, canvas);
    }
}
