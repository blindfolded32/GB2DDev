﻿using System.Collections.Generic;
using Data;
using Features.AbilitiesFeature;
using Features.InventoryFeature;
using Input;
using Player;
using Tools;
using UI.BackGround;
using UnityEngine;
using UnityEngine.UI;

namespace CommonClasses
{
    public class GameController : BaseController
    {
        private Button _inventoryButton;
        private IInventoryController _inventoryController;

        public GameController(ProfilePlayer profilePlayer, IReadOnlyList<AbilityItemConfig> configs,
            InventoryController inventoryController, Transform uiRoot)
        {
            _inventoryController = inventoryController;

            var leftMoveDiff = new SubscriptionProperty<float>();
            var rightMoveDiff = new SubscriptionProperty<float>();
            var isStay = new SubscriptionProperty<bool>();

            var tapeBackgroundController =
                new TapeBackgroundController(leftMoveDiff, rightMoveDiff, profilePlayer.CurrentCar);
            AddController(tapeBackgroundController);

            var inputGameController =
                new InputGameController(leftMoveDiff, rightMoveDiff, profilePlayer.CurrentCar);
            AddController(inputGameController);

            var carController = new CarController();
            AddController(carController);

            _inventoryButton =
                ResourceLoader.LoadAndInstantiateObject<Button>(
                    new ResourcePath() {PathResource = "Prefabs/InventoryButton"}, uiRoot);
            _inventoryButton.onClick.AddListener(OpenInventory);

            var abilityRepository = new AbilityRepository(configs, profilePlayer);
            var abilityView =
                ResourceLoader.LoadAndInstantiateView<AbilitiesView>(
                    new ResourcePath() {PathResource = "Prefabs/AbilitiesView"}, uiRoot);
            var abilitiesController = new AbilitiesController(carController, inventoryController.Model,
                abilityRepository,
                abilityView);
            AddController(abilitiesController);
        }

        private void OpenInventory()
        {
            _inventoryController.ShowInventory();
        }

        public new void OnDispose()
        {
            _inventoryButton.onClick.RemoveAllListeners();
            base.OnDispose();
        }
    }
}

