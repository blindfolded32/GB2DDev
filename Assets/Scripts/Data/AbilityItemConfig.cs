﻿using Features.AbilitiesFeature;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "AbilityItem", menuName = "AbilityItem", order = 0)]
    public class AbilityItemConfig : ScriptableObject
    {
        public ItemConfig Item;
        public GameObject View;
        public AbilityType Type;
        public float value;
        public float duration;
        public int Id => Item.Id;
    }
}