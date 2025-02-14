﻿using System.Collections.Generic;
using Data;
using Features.AbilitiesFeature;
using Features.InventoryFeature;
using Input;
using Player;
using Tools;
using UI.BackGround;
using UnityEngine;

namespace CommonClasses
{
    public class GameController : BaseController
    {
        public GameController(ProfilePlayer profilePlayer, IReadOnlyList<AbilityItemConfig> configs, InventoryModel inventoryModel, Transform uiRoot)
        {
            var leftMoveDiff = new SubscriptionProperty<float>();
            var rightMoveDiff = new SubscriptionProperty<float>();
        
            var tapeBackgroundController = new TapeBackgroundController(leftMoveDiff, rightMoveDiff);
            AddController(tapeBackgroundController);
        
            var inputGameController = new InputGameController(leftMoveDiff, rightMoveDiff, profilePlayer.CurrentCar);
            AddController(inputGameController);
            
            var carController = new CarController();
            AddController(carController);

            var abilityRepository = new AbilityRepository(configs);
            var abilityView =
                ResourceLoader.LoadAndInstantiateView<AbilitiesView>(
                    new ResourcePath() { PathResource = "Prefabs/AbilitiesView" }, uiRoot);

            var abilitiesController = new AbilitiesController(carController, inventoryModel, abilityRepository,
                abilityView);
            AddController(abilitiesController);

        }
    }
}

