using System;
using Item;
using JetBrains.Annotations;
<<<<<<< HEAD:Assets/Scripts/Data/AbilitiesController.cs
using UI.Inventory;
=======
using Tools;
>>>>>>> upstream/Lesson4:Assets/Scripts/Features/AbilitiesFeature/AbilitiesController.cs

namespace Data
{
<<<<<<< HEAD:Assets/Scripts/Data/AbilitiesController.cs
    public class AbilitiesController : BaseController
=======
    private readonly IInventoryModel _inventoryModel;
    private readonly IRepository<int, IAbility> _abilityRepository;
    private readonly IAbilityCollectionView _abilityCollectionView;
    private readonly IAbilityActivator _abilityActivator;

    public AbilitiesController(
        [NotNull] IAbilityActivator abilityActivator,
        [NotNull] IInventoryModel inventoryModel,
        [NotNull] IRepository<int, IAbility> abilityRepository,
        [NotNull] IAbilityCollectionView abilityCollectionView)
>>>>>>> upstream/Lesson4:Assets/Scripts/Features/AbilitiesFeature/AbilitiesController.cs
    {
        private readonly IInventoryModel _inventoryModel;
        private readonly IAbilityRepository _abilityRepository;
        private readonly IAbilityCollectionView _abilityCollectionView;
        private readonly IAbilityActivator _abilityActivator;

<<<<<<< HEAD:Assets/Scripts/Data/AbilitiesController.cs
        public AbilitiesController(
            [NotNull] IAbilityActivator abilityActivator,
            [NotNull] IInventoryModel inventoryModel,
            [NotNull] IAbilityRepository abilityRepository,
            [NotNull] IAbilityCollectionView abilityCollectionView)
        {
            _abilityActivator = abilityActivator ?? throw new ArgumentNullException(nameof(abilityActivator));
            _inventoryModel = inventoryModel ?? throw new ArgumentNullException(nameof(inventoryModel));
            _abilityRepository = abilityRepository ?? throw new ArgumentNullException(nameof(abilityRepository));
            _abilityCollectionView =
                abilityCollectionView ?? throw new ArgumentNullException(nameof(abilityCollectionView));
            _abilityCollectionView.UseRequested += OnAbilityUseRequested;
            _abilityCollectionView.Display(_inventoryModel.GetEquippedItems());
        }

        private void OnAbilityUseRequested(object sender, IItem e)
        {
            if (_abilityRepository.AbilitiesMap.TryGetValue(e.Id, out var ability))
                ability.Apply(_abilityActivator);
        }
=======
    private void OnAbilityUseRequested(object sender, IItem e)
    {
        if (_abilityRepository.Content.TryGetValue(e.Id, out var ability))
            ability.Apply(_abilityActivator);
>>>>>>> upstream/Lesson4:Assets/Scripts/Features/AbilitiesFeature/AbilitiesController.cs
    }
}