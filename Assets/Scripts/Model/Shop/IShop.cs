using Tools;
using UnityEngine.Purchasing;

namespace Model.Shop
{
    public interface IShop
    {
        void Buy(string id);
        string GetCost(string productID);
        void RestorePurchase();
        IReadOnlySubscriptionAction OnSuccessPurchase { get; }
        IReadOnlySubscriptionAction OnFailedPurchase { get; }
        
        void AddShopButton(IAPButton button);
    }
}