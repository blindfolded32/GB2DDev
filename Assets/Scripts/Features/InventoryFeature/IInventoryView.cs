using System;
using System.Collections.Generic;
using Data;
using Item;
using UI;
using UnityEngine;

namespace Features.InventoryFeature
{
    public interface IInventoryView:IView
    {
        void Init(IReadOnlyList<UpgradeItemConfig> upgradeItems);
        void Display(IReadOnlyList<IItem> items);
        Action<List<UpgradeItemConfig>> UpgradeSaved { get; set; }
        GameObject gameObject { get; }
        void SetOnGameSceneFlag(bool isOnScene);
    }
}
