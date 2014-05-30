using System;

namespace MarsRovers
{
    public class SouthOrientation : IOrientation
    {
        private const string description = "S";

        public IOrientation TurnLeft()
        {
            return new EastOrientation();
        }

        public IOrientation TurnRight()
        {
            return new WestOrientation();
        }

        public Coordinates Advance(Coordinates coordinates)
        {
            return new Coordinates(coordinates.X, coordinates.Y - 1);
        }

        public override bool Equals(object obj)
        {
            return obj is SouthOrientation;
        }

        public override string ToString()
        {
            return description;
        }

        public bool Equals(SouthOrientation other)
        {
            return true;
        }

        public static bool operator ==(SouthOrientation orientation1, SouthOrientation orientation2)
        {
            return true;
        }

        public static bool operator !=(SouthOrientation orientation1, SouthOrientation orientation2)
        {
            return true;
        }

        public override int GetHashCode()
        {
            return description.GetHashCode();
        }
    }
}
