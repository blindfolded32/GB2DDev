using UnityEngine;

namespace Item
{
    public class Item : IItem
    {
        public int Id { get; set; }
        public ItemInfo Info { get; set; }
        public Sprite ItemIcon { get; set; }
    }
}
