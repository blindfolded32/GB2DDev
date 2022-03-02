using System;
using System.Diagnostics.CodeAnalysis;
using Data;
using Features.AbilitiesFeature;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Player
{
    public class SpeedAbility : IAbility
    {
        private readonly SpriteRenderer _viewPrefab;
        private readonly float _boostSpeed;

        public Action<float> OnSpeedBoost;

        public SpeedAbility(
            [NotNull] GameObject viewPrefab,
            float boostSpeed)
        {
            _viewPrefab = viewPrefab.GetComponent<SpriteRenderer>();
            if (_viewPrefab == null) throw new InvalidOperationException($"{nameof(SpeedAbility)} view requires {nameof(SpriteRenderer)} component!");
            _boostSpeed = boostSpeed;
        }

        public void Apply(IAbilityActivator activator)
        {
            var firePrefab = Object.Instantiate(_viewPrefab);
            OnSpeedBoost?.Invoke(_boostSpeed);
        }

        public AbilityItemConfig Config { get; }
    }
}