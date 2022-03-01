﻿using System;
using System.Collections.Generic;
using Item;
using UnityEngine;

namespace Features.AbilitiesFeature
{
    [RequireComponent(typeof(CanvasGroup))]
    public class AbilitiesView : MonoBehaviour, IAbilityCollectionView
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private Transform _layout;
        [SerializeField] private AbilityItemView _viewPrefab;

        private List<AbilityItemView> _currentViews = new List<AbilityItemView>();

        public void Show()
        {
            _canvasGroup.alpha = 1;
        }

        public void Hide()
        {
            _canvasGroup.alpha = 0;
        }

        public event EventHandler<IItem> UseRequested;

        public void Display(IReadOnlyList<IItem> abilityItems, IAbilityRepository<int, IAbility> abilityRepository)
        {
            foreach (var abilityItem in abilityItems)
            {
                if(abilityRepository.Content.ContainsKey(abilityItem.Id))
                {
                    var view = Instantiate<AbilityItemView>(_viewPrefab, _layout);
                    view.Init(abilityItem);
                    view.OnClick += OnRequested;
                    view.SetText(abilityItem.Info.Title);
                    _currentViews.Add(view);
                }
            }
        }

        private void OnRequested(IItem obj)
        {
            UseRequested?.Invoke(this, obj);
        }
    }
}