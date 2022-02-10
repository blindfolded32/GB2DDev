using System;
using JoostenProductions;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI.Menu
{
    public class MainMenuView : MonoBehaviour
    {
       public event Action<Touch> UpdateTouch;
        
        [SerializeField] private Button _buttonStart;
        [SerializeField] private GameObject _trail;
        [SerializeField] private Button _RewardButton;

        public void Init(UnityAction startGame)
        {
            _buttonStart.onClick.AddListener(startGame);
            UpdateManager.SubscribeToUpdate(LocalUpdate);
        }
    
        private void LocalUpdate()
        {
            var touchCount = Input.touchCount;
            if (touchCount <= 0) return;
            for (int i = 0; i < touchCount; i++)
            {
                var touch = Input.GetTouch(i);
                UpdateTouch?.Invoke(touch);
            }
        }
        public GameObject CreateTrail(Vector2 position)
        {
            return Instantiate(_trail, position,quaternion.identity);
        }
        protected void OnDestroy()
        {
            _buttonStart.onClick.RemoveAllListeners();
            _RewardButton.onClick.RemoveAllListeners();
        }
        public void DisableRewardButton()
        {
            _RewardButton.interactable = false;
        }
    }
}