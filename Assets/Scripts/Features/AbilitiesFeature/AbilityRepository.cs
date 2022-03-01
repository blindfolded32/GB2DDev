using System;
using System.Collections.Generic;
using CommonClasses;
using Data;
using Player;
using Tools;
using UnityEngine;

namespace Features.AbilitiesFeature
{
    public class AbilityRepository : BaseController, IRepository<int, IAbility>
    {
        public IReadOnlyDictionary<int, IAbility> Content { get => _abilitiesMap; }
        public Action<bool, IAbility> CooldownNotification { get; set; }

        private Dictionary<int, IAbility> _abilitiesMap = new Dictionary<int, IAbility>();
        private ProfilePlayer _profilePlayer;

        public AbilityRepository(IReadOnlyList<AbilityItemConfig> abilities, ProfilePlayer profilePlayer)
        {
            _profilePlayer = profilePlayer;
            foreach (var config in abilities)
            {
                _abilitiesMap[config.Id] = CreateAbility(config);
                _abilitiesMap[config.Id].IsOnCooldown.SubscribeOnChange(NotifyAboutCooldownState);
            }
        }
        
        private void NotifyAboutCooldownState(bool isOnCooldown, IAbility ability)
        {
            CooldownNotification?.Invoke(isOnCooldown, ability);
        }

        private IAbility CreateAbility(AbilityItemConfig config)
        {
            switch (config.Type)
            {
                case AbilityType.None:
                    return AbilityStub.Default;
                case AbilityType.Gun:
                    return new GunAbility(config.View, config.value);
                case AbilityType.Speed:
                    return new SpeedAbility(config.View, config.value);
                case AbilityType.Oil:
                    return new OilAbility(config.View);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
    public class AbilityStub : IAbility
    {
        public static AbilityStub Default { get; } = new AbilityStub();

        public void Apply(IAbilityActivator activator)
        {
        }

        public SubscriptionPropertyWithClassInfo<bool, IAbility> IsOnCooldown { get; }
        public AbilityItemConfig Config { get; }
    }
}