using System;

namespace MarsRovers
{
    public class WestOrientation : IOrientation
    {
        private const string description = "W";

        public IOrientation TurnLeft()
        {
            return new SouthOrientation();
        }

        public IOrientation TurnRight()
        {
            return new NorthOrientation();
        }

        public Coordinates Advance(Coordinates coordinates)
        {
            return new Coordinates(coordinates.X - 1, coordinates.Y);
        }

        public override bool Equals(object obj)
        {
            return obj is WestOrientation;
        }

        public override string ToString()
        {
            return description;
        }

        public bool Equals(WestOrientation other)
        {
            return true;
        }

        public static bool operator ==(WestOrientation orientation1, WestOrientation orientation2)
        {
            return true;
        }

        public static bool operator !=(WestOrientation orientation1, WestOrientation orientation2)
        {
            return true;
        }

        public override int GetHashCode()
        {
            return description.GetHashCode();
        }
    }
}
