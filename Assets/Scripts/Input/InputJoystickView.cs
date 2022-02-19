using JoostenProductions;
using Tools;

//using UnityStandardAssets.CrossPlatformInput;

namespace Input
{
    internal class InputJoystickView : BaseInputView
    {
        public override void Init(SubscriptionProperty<float> leftMove, SubscriptionProperty<float> rightMove, float speed)
        {
            base.Init(leftMove, rightMove, speed);
            UpdateManager.SubscribeToUpdate(Move);
        }

        private void OnDestroy()
        {
            UpdateManager.UnsubscribeFromUpdate(Move);
        }

        private void Move()
        {
            /*float moveStep = 10 * Time.deltaTime * CrossPlatformInputManager.GetAxis("Horizontal");
        if (moveStep > 0)
            OnRightMove(moveStep);
        else if (moveStep < 0)
            OnLeftMove(moveStep);*/
        }
    }
}