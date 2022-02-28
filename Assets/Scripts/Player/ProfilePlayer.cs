using CommonClasses;
using Model.Analytic;
using Tools;
using Tools.Ads;

namespace Player
{
    public class ProfilePlayer
    {
        public SubscriptionProperty<GameState> CurrentState { get; }
        public IAdsShower AdsShower { get; }
        public IAnalyticTools AnalyticTools { get; }
        public IUpgradeableCar CurrentCar { get; }

        public ProfilePlayer(float speedCar, IAdsShower adsShower, IAnalyticTools analyticTools)
        {
            CurrentState = new SubscriptionProperty<GameState>();
            CurrentCar = new Car(speedCar);
            AdsShower = adsShower;
            AnalyticTools = analyticTools;
        }
    }
}

