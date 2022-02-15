using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "Item", menuName = "Item")]
    public class ItemConfig : ScriptableObject
    {
        [SerializeField]
        private int _id;

        [SerializeField]
        private string _title;
    
        [SerializeField]
        public Sprite _itemIcon;

        public int Id => _id;

        public string Title => _title;

        public Sprite ItemIcon => _itemIcon;
    }
}
