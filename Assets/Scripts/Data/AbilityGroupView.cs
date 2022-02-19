using System;
using System.Collections.Generic;
using Item;
using UnityEngine;

namespace Data
{
    public class AbilityGroupView : MonoBehaviour, IAbilityCollectionView
    {
        [SerializeField] private AbilityView _view;
        [SerializeField] private Transform _layout;

        private List<AbilityView> _currentViews = new List<AbilityView>();

        public event EventHandler<IItem> UseRequested;
        public void Display(IReadOnlyList<IItem> abilityItems)
        {
            foreach (var ability in abilityItems)
            {
                var view = Instantiate<AbilityView>(_view, _layout);
                view.OnClick += AbilityHandler;
                view.Init(ability);
                _currentViews.Add(view);
            }
        }

        private void AbilityHandler(IItem obj)
        {
            UseRequested?.Invoke(this, obj);
        }

    }
}