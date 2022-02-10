using Model;
using Player;
using Tools;

//using Tools.Rx;
//using UI.BackGround;

namespace CommonClasses
{
    public class GameController : BaseController
    {
        public GameController(ProfilePlayer profilePlayer)
        {
            var leftMoveDiff = new SubscriptionProperty<float>();
            var rightMoveDiff = new SubscriptionProperty<float>();
        
            var tapeBackgroundController = new TapeBackgroundController(leftMoveDiff, rightMoveDiff);
            AddController(tapeBackgroundController);
        
            var inputGameController = new InputGameController(leftMoveDiff, rightMoveDiff, profilePlayer.CurrentCar);
            AddController(inputGameController);
            
            var carController = new CarController();
            AddController(carController);
        }
    }
}

