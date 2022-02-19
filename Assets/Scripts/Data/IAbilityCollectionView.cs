using System;
using System.Collections.Generic;
using Item;

namespace Data
{
    public interface IAbilityCollectionView
    {
        event EventHandler<IItem> UseRequested;
        void Display(IReadOnlyList<IItem> abilityItems);
    }
}