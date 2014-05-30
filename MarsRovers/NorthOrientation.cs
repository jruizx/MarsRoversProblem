using System;

namespace MarsRovers
{
    public class NorthOrientation : IOrientation
    {
        private const string description = "N";

        public IOrientation TurnLeft()
        {
            return new WestOrientation();
        }

        public IOrientation TurnRight()
        {
            return new EastOrientation();
        }

        public Coordinates Advance(Coordinates coordinates)
        {
            return new Coordinates(coordinates.X, coordinates.Y + 1);
        }

        public override bool Equals(object obj)
        {
            return obj is NorthOrientation;
        }

        public override string ToString()
        {
            return description;
        }

        public bool Equals(NorthOrientation other)
        {
            return true;
        }

        public static bool operator ==(NorthOrientation orientation1, NorthOrientation orientation2)
        {
            return true;
        }

        public static bool operator !=(NorthOrientation orientation1, NorthOrientation orientation2)
        {
            return true;
        }

        public override int GetHashCode()
        {
            return description.GetHashCode();
        }
    }
}
