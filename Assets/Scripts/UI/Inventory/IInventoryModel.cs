using System.Collections.Generic;
using Item;

namespace UI.Inventory
{
    public interface IInventoryModel
    {
        IReadOnlyList<IItem> GetEquippedItems();
        IReadOnlyDictionary<IItem, bool> GetAllItems();
        void EquipItem(IItem item);
        void UnEquipItem(IItem item);
    }
}
