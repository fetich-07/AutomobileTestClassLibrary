namespace AutomobileTestClassLibrary
{
    public class Car : Automobile
    {
        private readonly int _seatingCapacity;

        public Car(int seatingCapacity)
        {
            _seatingCapacity = seatingCapacity;
        }

        private int _passengersNumber;
        public int PassengersNumber
        {
            get
            {
                return _passengersNumber;
            }
            set
            {
                if (value > 5)
                    throw new ArgumentException($"The number of passengers should not exceed {_seatingCapacity} people");
                _passengersNumber = value;
            }
        }

        public override double GetPowerReserveWithFullTank()
        {
            var powerReserve = base.GetPowerReserveWithFullTank();
            //проеверяем, есть ли пассажиры
            if (_passengersNumber == 0)
                return powerReserve;
            //если да, то запас хода уменьшается на 6%
            var lostPercentage = _passengersNumber * 6;
            return powerReserve * (1 - lostPercentage / 100);
        }

        public override double GetPowerReserveWithRemainingFuel()
        {
            var powerReserve = base.GetPowerReserveWithRemainingFuel();
            //проеверяем, есть ли пассажиры
            if (_passengersNumber == 0)
                return powerReserve;
            //если да, то запас хода уменьшается на 6%
            var lostPercentage = _passengersNumber * 6;
            return powerReserve * (1 - lostPercentage / 100);
        }
    }
}
