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

        
        public MainController(Transform placeForUi, ProfilePlayer profilePlayer, IAnalyticTools analyticsTools, IAdsShower ads, ShopTools shopTools)
        {
            _profilePlayer = profilePlayer;
            _analyticsTools = analyticsTools;
            _shopTools = shopTools;
            _ads = ads;
            _placeForUi = placeForUi;
            OnChangeGameState(_profilePlayer.CurrentState.Value);
            profilePlayer.CurrentState.SubscribeOnChange(OnChangeGameState);
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
                    _gameController?.Dispose();
                    break;
                case GameState.Game:
                    _gameController = new GameController(_profilePlayer);
                    _analyticsTools.SendMessage("Started");
                    _mainMenuController?.Dispose();
                    break;
                default:
                    _mainMenuController?.Dispose();
                    _gameController?.Dispose();
                    break;
            }
        }
    }
}
