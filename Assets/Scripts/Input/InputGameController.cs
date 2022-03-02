using CommonClasses;
using Tools;
using UnityEngine;

namespace Input
{
    
    public class InputGameController : BaseController
    {
        private readonly ResourcePath _viewPath = new ResourcePath {PathResource = "Prefabs/StickControl"};
        private BaseInputView _view;
        public InputGameController(SubscriptionProperty<float> leftMove, SubscriptionProperty<float> rightMove,
             IUpgradeableCar car)
        {
            _view = LoadView();
            _view.Init(leftMove, rightMove, car.Speed);
        }



        private BaseInputView LoadView()
        {
            var objView = Object.Instantiate(ResourceLoader.LoadPrefab(_viewPath));
            AddGameObjects(objView);

            return objView.GetComponent<BaseInputView>();
        }
    }
}

