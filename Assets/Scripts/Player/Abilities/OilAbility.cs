using System;
using System.Diagnostics.CodeAnalysis;

using Features.AbilitiesFeature;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Player
{
    public class OilAbility : IAbility
    {
        private readonly SpriteRenderer _viewPrefab;
     

        public OilAbility(
            [NotNull] GameObject viewPrefab)
        {
            _viewPrefab = viewPrefab.GetComponent<SpriteRenderer>();
            if (_viewPrefab == null) throw new InvalidOperationException($"{nameof(OilAbility)} view requires {nameof(SpriteRenderer)} component!");
           
        }

        public void Apply(IAbilityActivator activator)
        {
            var OilSpill = Object.Instantiate(_viewPrefab);
     
        }
    }
}