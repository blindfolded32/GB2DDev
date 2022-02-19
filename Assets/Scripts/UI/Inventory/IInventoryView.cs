using System.Collections.Generic;
using Item;
using UnityEngine.Events;

namespace UI.Inventory
{
    public interface IInventoryView
    {
        void LoadShedUI(UnityAction<IItem, bool> toggleHandler, IReadOnlyDictionary<IItem, bool> items, ResourcePath itemPrefabPath);
            void Display(IReadOnlyList<IItem> items);
            void Show();
            void Hide();
            void OnDispose();
       
    }
}