using System;
using CommonClasses;
using Model.Shop;
using Player;
using UnityEngine;

namespace UI.GoldBalance
{
    public class GoldController : BaseController
    {

        private ProfilePlayer _profilePlayer;
        private GoldView _view;
        private IShop _shop;
        
        public event Action<int> OnGoldChange;
        public Action<GoldView> OnViewLoaded;
        public Action OnFailedPurchase;
        public Action OnSuccessfulPurchase;

        public GoldController(ProfilePlayer profile, IShop shop)
        {
            _profilePlayer = profile;
            _profilePlayer.PurchaseGold(this);
            _shop = shop;
            OnViewLoaded += ViewLoaded;
        }
        private void ViewLoaded(GoldView view)
        {
            _view = view;
            OnViewLoaded -= ViewLoaded;

            OnFailedPurchase += FailedPurchasee;
            OnSuccessfulPurchase += SuccessfullPurchase;

            _shop.OnSuccessPurchase.SubscribeOnChange(OnSuccessfulPurchase);
            _shop.OnFailedPurchase.SubscribeOnChange(OnFailedPurchase);
        }

        public void FailedPurchasee()
        {
            Debug.Log("Failed purchase");
        }
        private void SuccessfullPurchase()
        {
            OnGoldChange?.Invoke(10);
            _view.Init(10);
        }
        protected override void OnDispose()
        {
            _shop.OnFailedPurchase.UnSubscriptionOnChange(OnSuccessfulPurchase);
            _shop.OnFailedPurchase.UnSubscriptionOnChange(OnFailedPurchase);
            OnFailedPurchase -= FailedPurchasee;
            OnSuccessfulPurchase -= SuccessfullPurchase;
            GameObject.Destroy(_view);
            base.OnDispose();
        }

    }
}