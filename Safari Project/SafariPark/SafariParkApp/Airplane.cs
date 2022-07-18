using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SafariParkApp
{
    public class Airplane : Vehicle
    {
        private string _airline;

        public Airplane(int capacity) : base(capacity)
        {

        }
        public Airplane(int capacity, int speed, string airline) : base(capacity, speed)
        {
            _airline = airline;
        }
        public int Altitude { get; set; }


        public void Ascend(int distance)
        {

            Altitude += distance < 0 ? throw new ArgumentOutOfRangeException() : distance;
        }

        public void Descend(int distance)
        {
            Altitude -= distance < 0 ? throw new ArgumentOutOfRangeException() : distance;
        }

        public override string Move()
        {
            Position += Speed;
            return $"{base.Move()} at an altitude of {Altitude} metres";
        }

        public override string Move(int times)
        {
            Position = times < 0 ? throw new ArgumentOutOfRangeException() : times;
            return $"{base.Move(times)} at an altitude of {Altitude} metres";
        }

        //public override string ToString() => $"Thank you for flying {_airline}: {base.ToString()} capacity: {_capacity} passengers: {_numPassengers} speed: {Speed} position: {Position} altitude: {Altitude}";
    }
}