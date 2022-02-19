using System;
using System.Diagnostics.CodeAnalysis;
using Data;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Player
{
    public class OilAbility : IAbility
    {
        private readonly Sprite _viewPrefab;
     

        public OilAbility(
            [NotNull] GameObject viewPrefab)
        {
            _viewPrefab = viewPrefab.GetComponent<Sprite>();
            if (_viewPrefab == null) throw new InvalidOperationException($"{nameof(OilAbility)} view requires {nameof(Sprite)} component!");
           
        }

        public void Apply(IAbilityActivator activator)
        {
            var OilSpill = Object.Instantiate(_viewPrefab);
     
        }
    }
}