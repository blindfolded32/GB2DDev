using System.Collections.Generic;
using Item;
using UI;

namespace Features.InventoryFeature
{
    public interface IInventoryView:IView
    {
        void Display(IReadOnlyList<IItem> items);
    }
}
