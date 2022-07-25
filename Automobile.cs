namespace AutomobileTestClassLibrary
{
    public abstract class Automobile
    {
        public string? VehicleType { get; set; }
        public double AverageFuelConsumption { get; set; }
        public double FuelTankCapacity { get; set; }
        public double RemainingFuel { get; set; }
        public double Speed { get; set; }

        public virtual double GetPowerReserveWithFullTank()
            => (FuelTankCapacity / AverageFuelConsumption) * 100;

        public virtual double GetPowerReserveWithRemainingFuel()
            => (RemainingFuel / AverageFuelConsumption) * 100;

        public double GetTimeRequiredToCoverDistance(double km)
        {
            if (RemainingFuel > (AverageFuelConsumption * (km / 100)))
                throw new ArgumentOutOfRangeException($"Not enough fuel for this distance. Remaning fuel: {RemainingFuel}");
            return km / Speed;
        }
    }
}
