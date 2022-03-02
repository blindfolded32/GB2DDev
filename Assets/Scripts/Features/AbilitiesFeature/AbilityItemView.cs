﻿using System;
using Item;
using UnityEngine;
using UnityEngine.UI;

namespace Features.AbilitiesFeature
{
    public class AbilityItemView:MonoBehaviour
    {
        [SerializeField]
        private Button _button;
        [SerializeField]
        private Text _buttonText;

        public event Action<IItem> OnClick;

        private IItem _item;
        public IItem Item { get => _item; }

        public void Init(IItem item)
        {
            _item = item;
        }
        private void Awake()
        {
            _button.onClick.AddListener(Click);
        }
        private void Click()
        {
            OnClick?.Invoke(_item);
        }
        private void OnDestroy()
        {
            OnClick = null;
            _button.onClick.RemoveAllListeners();
        }
        public void SetText(string text)
        {
            _buttonText.text = text;
        }
    }
}