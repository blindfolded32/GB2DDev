using System;
using System.Diagnostics.CodeAnalysis;
using Data;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Player
{
    public class SpeedAbility : IAbility
    {
        private readonly Sprite _viewPrefab;
        private readonly float _boostSpeed;

        public Action<float> OnSpeedBoost;

        public SpeedAbility(
            [NotNull] GameObject viewPrefab,
            float boostSpeed)
        {
            _viewPrefab = viewPrefab.GetComponent<Sprite>();
            if (_viewPrefab == null) throw new InvalidOperationException($"{nameof(SpeedAbility)} view requires {nameof(Sprite)} component!");
            _boostSpeed = boostSpeed;
        }

        public void Apply(IAbilityActivator activator)
        {
            var firePrefab = Object.Instantiate(_viewPrefab);
            OnSpeedBoost?.Invoke(_boostSpeed);
        }
    }
}