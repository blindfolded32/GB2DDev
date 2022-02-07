using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Profile
{
    public class Swipe : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        public event Action<float> OnSwipe;

        private Vector2 _startPoint;

        public void OnBeginDrag(PointerEventData eventData)
        {
            _startPoint = eventData.position;
        }

        public void OnDrag(PointerEventData eventData)
        {

        }

        public void OnEndDrag(PointerEventData eventData)
        {
            var delta = _startPoint.x - eventData.position.x;
            OnSwipe?.Invoke(delta);
        }
    }
}