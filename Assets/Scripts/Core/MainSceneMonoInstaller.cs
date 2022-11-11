using UnityEngine;
using Zenject;

public class MainSceneMonoInstaller : MonoInstaller
{
    //[SerializeField] private CoinsFlyAnimation coinsFlyAnimation;
    [SerializeField] private LevelView levelView;
    [SerializeField] private GameController gameController;
    [SerializeField] private BaseView baseView;

    public override void InstallBindings()
    {
        //Container.Bind<CoinsFlyAnimation>().FromInstance(coinsFlyAnimation).AsSingle();
        Container.Bind<LevelView>().FromInstance(levelView).AsSingle();
        Container.Bind<GameController>().FromInstance(gameController).AsSingle();
        Container.Bind<BaseView>().FromInstance(baseView).AsSingle();
    }
}
