using CommonClasses;
using Model.Analytic;
using Tools;
using Tools.Ads;
using UI.GoldBalance;

namespace Player
{
    public class ProfilePlayer
    {
        public SubscriptionProperty<int> CurrentGold { get; }
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
            CurrentGold = new SubscriptionProperty<int>();
            CurrentGold.Value = 10;
        }
        public void PurchaseGold(GoldController goldController)
        {
            goldController.OnGoldChange += GoldCount;
        }

        private void GoldCount(int count)
        {
            CurrentGold.Value += count;
        }
        
    }
}

