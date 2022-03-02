using Data;

namespace Features.AbilitiesFeature
{
    public interface IAbility
    {
        void Apply(IAbilityActivator activator);
        AbilityItemConfig Config { get; }
    }
}