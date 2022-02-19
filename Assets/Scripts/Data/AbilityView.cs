using System;
using Item;
using UnityEngine;
using UnityEngine.UI;

namespace Data
{
    public class AbilityView : MonoBehaviour
    {
            [SerializeField] private Button _button;
        private Image _imageComponent;
        private Sprite _abilitySprite;
        private IItem _item;


        public event Action<IItem> OnClick;

        private void Awake()
        {
            _button.onClick.AddListener(Click);
            _imageComponent = _button.GetComponent<Image>();
        }

        private void OnDestroy()
        {
            OnClick = null;
            _button.onClick.RemoveAllListeners();
        }

        public void Init(IItem item)
        {
            _item = item;
            _abilitySprite = item.ItemIcon;
            _imageComponent.sprite = _abilitySprite;
        }
        private void Click()
        {
            OnClick?.Invoke(_item);
        }

    }
}