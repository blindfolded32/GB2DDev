using CommonClasses;
using Tools;
using UI.GoldBalance;
using UnityEngine;

namespace Player
{
    public class ProfilePlayer
    {
        public SubscriptionProperty<int> CurrentGold { get; }
        public SubscriptionProperty<GameState> CurrentState { get; }
        public Car CurrentCar { get; }
        public ProfilePlayer(float speedCar)
        {
            CurrentState = new SubscriptionProperty<GameState>();
            CurrentCar = new Car(speedCar);
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

