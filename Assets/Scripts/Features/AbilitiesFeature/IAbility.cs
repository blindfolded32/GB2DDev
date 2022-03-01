using Data;
using Tools;

namespace Features.AbilitiesFeature
{
    public interface IAbility
    {
        void Apply(IAbilityActivator activator);
        SubscriptionPropertyWithClassInfo<bool, IAbility> IsOnCooldown { get; }
        AbilityItemConfig Config { get; }
    }
}