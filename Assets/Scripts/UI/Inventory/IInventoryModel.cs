using System.Collections.Generic;
using Item;

public interface IInventoryModel
{
    bool IsInShed { get; set; }
    IReadOnlyList<IItem> GetEquippedItems();
    IReadOnlyDictionary<IItem, bool> GetAllItems();
    void EquipItem(IItem item);
    void UnEquipItem(IItem item);
}
