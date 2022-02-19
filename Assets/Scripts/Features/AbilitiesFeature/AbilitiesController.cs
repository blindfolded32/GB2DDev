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
        {}

        private void OnAbilityUseRequested(object sender, IItem e)
        {
            if (_abilityRepository.Content.TryGetValue(e.Id, out var ability))
                ability.Apply(_abilityActivator);
        }
    }
}