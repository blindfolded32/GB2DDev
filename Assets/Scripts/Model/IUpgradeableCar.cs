public interface IUpgradeableCar
{
    float Speed { get; set; }
    void Restore();
    void AbilityListener(float speed);
}