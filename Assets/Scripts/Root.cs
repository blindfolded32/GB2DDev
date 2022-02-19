using System.Collections.Generic;
using System.Linq;
using CommonClasses;
using Data;
using Model.Analytic;
using Model.Shop;
using Player;
using Tools.Ads;
using UnityEngine;

public class Root : MonoBehaviour
{
    [SerializeField] 
    private Transform _placeForUi;

    [SerializeField] private UnityAdsTools _ads;
    [SerializeField] private List<ItemConfig> _items;
    [SerializeField] private UpgradeItemConfigDataSource _upgradeSource;
    [SerializeField] private List<AbilityItemConfig> _abilityItems;
    [SerializeField] private List<ShopProduct> _products;

    private MainController _mainController;
    private IAnalyticTools _analyticsTools;

    private void Awake()
    {
        var _shopTools = new ShopTools(_products);
        _analyticsTools = new UnityAnalyticTools();
        var profilePlayer = new ProfilePlayer(15f, _ads, _analyticsTools);
        _mainController = new MainController(_placeForUi, profilePlayer,_analyticsTools,_ads, _shopTools,_items, _upgradeSource.ItemConfigs.ToList(), _abilityItems.AsReadOnly());
        profilePlayer.CurrentState.Value = GameState.Start;
    }

    protected void OnDestroy()
    {
        _mainController?.Dispose();
    }
}
