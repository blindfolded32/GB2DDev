using System.Collections.Generic;
using Item;
using UI;

public interface IInventoryView:IView
{
    void Display(IReadOnlyList<IItem> items);
}
