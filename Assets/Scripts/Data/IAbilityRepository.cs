using System.Collections.Generic;

namespace Data
{
    public interface IAbilityRepository
    {
        IReadOnlyDictionary<int, IAbility> AbilitiesMap { get; }
    }
}