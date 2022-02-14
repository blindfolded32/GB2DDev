using System.Collections.Generic;
using Data;
using Inventory;
using Model;
using Model.Analytic;
using Model.Shop;
using Player;
using Tools.Ads;
using UI.GoldBalance;
using UI.Menu;
using UnityEngine;

namespace CommonClasses
{
    public class MainController : BaseController
    {
        private GoldController _goldController;
        private readonly ShopTools _shopTools;
        private readonly IAnalyticTools _analyticsTools;
        private readonly IAdsShower _ads;
        
        private MainMenuController _mainMenuController;
        private GameController _gameController;
        private readonly Transform _placeForUi;
        private readonly ProfilePlayer _profilePlayer;
        
        private ShedController _shedController;
        private readonly List<ItemConfig> _itemsConfig;
        private readonly IReadOnlyList<UpgradeItemConfig> _upgradeItems;
        private readonly IReadOnlyList<AbilityItemConfig> _abilityItems;
        private InventoryController _inventoryController;
        
        public MainController(Transform placeForUi, ProfilePlayer profilePlayer, IAnalyticTools analyticsTools, 
            IAdsShower ads, ShopTools shopTools, List<ItemConfig> itemsConfig, IReadOnlyList<UpgradeItemConfig> upgradeItems,
            IReadOnlyList<AbilityItemConfig> abilityItems)
        {
            _profilePlayer = profilePlayer;
            _analyticsTools = analyticsTools;
            _shopTools = shopTools;
            _goldController = new GoldController(profilePlayer, _shopTools);
            _ads = ads;
            _placeForUi = placeForUi;
            OnChangeGameState(_profilePlayer.CurrentState.Value);
            profilePlayer.CurrentState.SubscribeOnChange(OnChangeGameState);
            
            _itemsConfig = itemsConfig;
            _upgradeItems = upgradeItems;
            _abilityItems = abilityItems;
        }
        protected override void OnDispose()
        {
            _mainMenuController?.Dispose();
            _gameController?.Dispose();
            _profilePlayer.CurrentState.UnSubscriptionOnChange(OnChangeGameState);
            _goldController?.Dispose();
            base.OnDispose();

        }

        private void OnChangeGameState(GameState state)
        {
            switch (state)
            {
                case GameState.Start:
                    _mainMenuController = new MainMenuController(_placeForUi, _profilePlayer, _analyticsTools, 
                        _goldController.OnViewLoaded, _shopTools.OnButtonRegister, _ads);
                    _analyticsTools.SendMessage("Launched");
                    _shedController = new ShedController(_upgradeItems, _itemsConfig, _profilePlayer.CurrentCar);
                    _shedController.Enter();
                    _shedController.Exit();
                    _inventoryController?.Dispose();
                    _gameController?.Dispose();
                    break;
                case GameState.Game:
                    
                    _analyticsTools.SendMessage("Started");
                    var inventoryModel = new InventoryModel();
                    _inventoryController = new InventoryController(_itemsConfig, inventoryModel);
                    _inventoryController.ShowInventory();
                    _gameController = new GameController(_profilePlayer,_abilityItems, inventoryModel);
                    _mainMenuController?.Dispose();
                    break;
                default:
                    AllClear();
                    break;
            }
        }
        
        private void AllClear()
        {
            _inventoryController?.Dispose();
            _mainMenuController?.Dispose();
            _gameController?.Dispose();
        }
    }
}
