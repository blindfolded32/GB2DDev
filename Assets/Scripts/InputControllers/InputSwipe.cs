using CommonClasses;
using Tools;
using UnityEngine;

namespace InputControllers
{
    public class InputSwipe : BaseInputView
    {
        [SerializeField] private Swipe _swipe;
        [SerializeField] private int _planeDistance = 3;
        [SerializeField] private float _duration = 1;

        private bool _isOnMoving;
        private float _lerpProgress;
        private float _currentPosition;
        private float _targetPosition;

        public override void Init(SubscriptionProperty<float> leftMove, SubscriptionProperty<float> rightMove,
            float speed)
        {
            base.Init(leftMove, rightMove, speed);
            var canvas = GetComponent<Canvas>();
            canvas.worldCamera = Camera.main;
            canvas.planeDistance = _planeDistance;
            _swipe = GetComponentInChildren<Swipe>();
        }

        private void OnEnable()
        {
            _swipe.OnSwipe += Move;
        }

        private void OnDisable()
        {
            _swipe.OnSwipe -= Move;
        }
        private void Move(float distance)
        {
            if (distance > 0)
            {
                OnRightMove(_speed);
            }
            else
            {
                OnLeftMove(_speed);
            }
        }
    }
} 