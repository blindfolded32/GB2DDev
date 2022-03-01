﻿using System;
using System.Diagnostics.CodeAnalysis;
using CommonClasses;
using Features.InventoryFeature;
using Item;
using Tools;

namespace Features.AbilitiesFeature
{
    public class AbilitiesController : BaseController
    {
        private readonly IInventoryModel _inventoryModel;
        private readonly IRepository<int, IAbility> _abilityRepository;
        private readonly IAbilityCollectionView _abilityCollectionView;
        private readonly IAbilityActivator _abilityActivator;

        public AbilitiesController(
            [NotNull] IAbilityActivator abilityActivator,
            [NotNull] IInventoryModel inventoryModel,
            [NotNull] IRepository<int, IAbility> abilityRepository,
            [NotNull] IAbilityCollectionView abilityCollectionView)
        {
            _abilityActivator = abilityActivator ?? throw new ArgumentNullException(nameof(abilityActivator));
            _inventoryModel = inventoryModel ?? throw new ArgumentNullException(nameof(inventoryModel));
            _abilityRepository = abilityRepository ?? throw new ArgumentNullException(nameof(abilityRepository));
            _abilityCollectionView =
                abilityCollectionView ?? throw new ArgumentNullException(nameof(abilityCollectionView));
            _abilityCollectionView.UseRequested += OnAbilityUseRequested;
            _abilityCollectionView.Display(_inventoryModel.GetEquippedItems(), _abilityRepository);

            _abilityRepository.CooldownNotification += SetInteractableStatusForAbilityView;
            
        }

        private void OnAbilityUseRequested(object sender, IItem e)
        {
            if (_abilityRepository.Content.TryGetValue(e.Id, out var ability))
                ability.Apply(_abilityActivator);
        }
        
        private void SetInteractableStatusForAbilityView(bool isOnCooldown, IAbility ability)
        {
            var targetAbility = _abilityCollectionView.AbilityViews.FirstOrDefault(abilityView => abilityView.Item.Id == ability.Config.Item.Id);
            targetAbility.SetInteractableState(isOnCooldown);
        }
        
        private void OnAbilityUseRequested(object sender, IItem e)
        {
            if (_abilityRepository.Content.TryGetValue(e.Id, out var ability))
            {
                if (ability.IsOnCooldown.Value) return;
                ability.Apply(_abilityActivator);
            }
        }
    }
}