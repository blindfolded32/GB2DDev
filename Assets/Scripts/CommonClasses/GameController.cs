using System.Collections.Generic;
using Data;
using InputControllers;
using Player;
using Tools;
using UI.BackGround;
using UnityEngine;

namespace CommonClasses
{
    public class GameController : global::BaseController
    {
        public GameController(ProfilePlayer profilePlayer, IReadOnlyList<AbilityItemConfig> configs, InventoryModel inventoryModel, Transform iuTransform)
        {
            var leftMoveDiff = new SubscriptionProperty<float>();
            var rightMoveDiff = new SubscriptionProperty<float>();
        
            var tapeBackgroundController = new TapeBackgroundController(leftMoveDiff, rightMoveDiff);
            AddController(tapeBackgroundController);
        
            var inputGameController = new InputGameController(leftMoveDiff, rightMoveDiff, profilePlayer.CurrentCar);
            AddController(inputGameController);
            
            var carController = new CarController();
            AddController(carController);

          //  var abilityRepository = new AbilityRepository(configs);
          var abilityRepository = new AbilityRepository(configs, profilePlayer.CurrentCar.AbilityListener);
          var abilityViewPrefab = ResourceLoader.LoadPrefab(new ResourcePath() { PathResource = "Prefabs/AbilitiesGroupView" });
          var abilityGroupView = GameObject.Instantiate(abilityViewPrefab, iuTransform).GetComponent<AbilityGroupView>();
          
            var abilitiesController = new AbilitiesController(carController, inventoryModel, abilityRepository,
                abilityGroupView);
                //  new AbilitiesCollectionViewStub());
            
            AddController(abilitiesController);

        }
    }
}

