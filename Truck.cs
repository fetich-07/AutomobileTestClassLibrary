namespace AutomobileTestClassLibrary
{
    public class Truck : Automobile
    {
        private readonly double _loadCapacity;

        public Truck(double loadCapacity)
        {
            _loadCapacity = loadCapacity;
        }

        private double _cargo;
        public double Cargo
        {
            get
            {
                return _cargo;
            }
            set
            {
                if (value > _loadCapacity)
                    throw new ArgumentException($"The cargo weight should not exceed {_loadCapacity}");
                _cargo = value;
            }
        }

        public override double GetPowerReserveWithFullTank()
        {
            var powerReserve = base.GetPowerReserveWithFullTank();
            //проеверяем, есть ли груз
            if (_cargo == 0)
                return powerReserve;
            //если да, то запас хода уменьшается на 4%
            var lostPercentage = (_cargo / 200) * 4;
            return powerReserve * (1 - lostPercentage / 100);
        }

        public override double GetPowerReserveWithRemainingFuel()
        {
            var powerReserve = base.GetPowerReserveWithRemainingFuel();
            //проеверяем, есть ли груз
            if (_cargo == 0)
                return powerReserve;
            //если да, то запас хода уменьшается на 4%
            var lostPercentage = (_cargo / 200) * 4;
            return powerReserve * (1 - lostPercentage / 100);
        }
    }
}
