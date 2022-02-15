using Item;
using UnityEngine.Events;

namespace UI.Inventory
{
    public interface IInventoryItemView
    {
        void Init(UnityAction<IItem, bool> toggleHandler, IItem item, bool isOn);
        void OnDispose();
      
    }
}