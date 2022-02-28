using System.Collections.Generic;
using Item;

namespace Features.InventoryFeature
{
    public interface IInventoryModel
    {
        IReadOnlyList<IItem> GetEquippedItems();
        void EquipItem(IItem item);
        void UnEquipItem(IItem item);
    }
}
