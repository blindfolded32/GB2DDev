using System.Collections.Generic;
using CommonClasses;
using Model.Analytic;
using Model.Shop;
using Player;
using Tools.Ads;
using UnityEngine;

public class Root : MonoBehaviour, IAnalyticTools
{
    [SerializeField] private Transform _placeForUi;
    [SerializeField] private List<ShopProduct> _products;
    [SerializeField] private UnityAdsTools _ads;

    private MainController _mainController;
    private IAnalyticTools _analyticsTools;

    private void Awake()
    {
       var _shopTools = new ShopTools(_products);
        var profilePlayer = new ProfilePlayer(15f);
        _analyticsTools = new UnityAnalyticTools();
        profilePlayer.CurrentState.Value = GameState.Start;
        _mainController = new MainController(_placeForUi, profilePlayer, _analyticsTools, _ads,_shopTools);
    }

    protected void OnDestroy()
    {
        _mainController?.Dispose();
    }

    public void SendMessage(string alias, IDictionary<string, object> eventData = null)
    {
        if (eventData == null)
            eventData = new Dictionary<string, object>();
        UnityEngine.Analytics.Analytics.CustomEvent(alias, eventData);
    }
}
