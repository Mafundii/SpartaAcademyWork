namespace SafariParkApp
{
    public class Vehicle : IMovable
    {
        protected int _capacity;
        protected int _numPassengers;

        public int NumPassengers
        {
            get { return _numPassengers; }
            set { _numPassengers = value < 0 || _numPassengers > _capacity ? throw new ArgumentException() : value; }
        }

        public Vehicle()
        {
            Speed = 10;
        }

        public Vehicle(int capacity)
        {
            _capacity = capacity < 0 ? throw new ArgumentOutOfRangeException() : capacity;
        }

        public Vehicle(int capacity, int speed)
        {
            _capacity = capacity <= 0 ? throw new ArgumentOutOfRangeException() : capacity;
            Speed = speed;
        }

        public int Speed { get; } = 10;

        public int Position { get; set; }

        public virtual string Move()
        {
            Position += Speed;
            return "Moving along";
        }

        public virtual string Move(int times)
        {
            Position += times < 0 ? throw new ArgumentOutOfRangeException() : times * Speed;
            return $"Moving along {times} times";
        }

        //public override string ToString() => base.ToString() + $" capacity: {_capacity} passengers: {_numPassengers} speed: {Speed} position: {Position}";
    }
}