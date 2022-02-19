using System;
using System.Collections.Generic;
<<<<<<< HEAD:Assets/Scripts/Data/IAbilityCollectionView.cs
using Item;

namespace Data
=======
using UI;

public interface IAbilityCollectionView: IView
>>>>>>> upstream/Lesson4:Assets/Scripts/Features/AbilitiesFeature/IAbilityCollectionView.cs
{
    public interface IAbilityCollectionView
    {
        event EventHandler<IItem> UseRequested;
        void Display(IReadOnlyList<IItem> abilityItems);
    }
}