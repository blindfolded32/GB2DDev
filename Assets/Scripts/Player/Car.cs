namespace Player
{
    public class Car : IUpgradeableCar
    {
        public float Speed { get; set; }
        public void Restore()
        {
            throw new System.NotImplementedException();
        }

        public Car(float speed)
        {
            Speed = speed;
        }
    }
}

