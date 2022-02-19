using System;
using System.Collections.Generic;
using Features.AbilitiesFeature;
using Item;
using UnityEngine;

namespace Data
{
    public class AbilityGroupView : MonoBehaviour, IAbilityCollectionView
    {
        [SerializeField] private AbilitiesView _view;
        [SerializeField] private Transform _layout;

        private List<AbilitiesView> _currentViews = new List<AbilitiesView>();

        public event EventHandler<IReadOnlyList<IItem>> UseRequested;
        public void Display(IReadOnlyList<IItem> abilityItems)
        {
            foreach (IReadOnlyList<IItem> ability in abilityItems)
            {
                var view = Instantiate<AbilitiesView>(_view, _layout);
               // view.OnClick += AbilityHandler;
                view.Display(ability);
                _currentViews.Add(view);
            }
        }

      /*  private void AbilityHandler(IItem obj)
        {
            UseRequested?.Invoke(this, obj);
        }*/

        public void Show()
        {
            throw new NotImplementedException();
        }

        public void Hide()
        {
            throw new NotImplementedException();
        }
    }
}