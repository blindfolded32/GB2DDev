using System;
using System.Collections.Generic;
using Item;
using UI;

namespace Features.AbilitiesFeature
{
    public interface IAbilityCollectionView: IView

    {
        event EventHandler<IItem> UseRequested;
        void Display(IReadOnlyList<IItem> abilityItems, IAbilityRepository<int, IAbility> abilityRepository);
        List<AbilityItemView> AbilityViews { get; }
    }
}