using UnityEngine;

namespace Item
{
    public interface IItem
    {
        int Id { get; set; }
        ItemInfo Info { get; set; }
        Sprite ItemIcon { get; }
    }
}
