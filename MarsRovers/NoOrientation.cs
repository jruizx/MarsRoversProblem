using System;

namespace MarsRovers
{
    public class NoOrientation : IOrientation
    {
        private const string description = "No orientation";

        public IOrientation TurnLeft()
        {
            return this;
        }

        public IOrientation TurnRight()
        {
            return this;
        }

        public Coordinates Advance(Coordinates coordinates)
        {
            return coordinates;
        }

        public override bool Equals(object obj)
        {
            return obj is NoOrientation;
        }

        public override string ToString()
        {
            return description;
        }

        public bool Equals(NoOrientation other)
        {
            return true;
        }

        public static bool operator ==(NoOrientation orientation1, NoOrientation orientation2)
        {
            return true;
        }

        public static bool operator !=(NoOrientation orientation1, NoOrientation orientation2)
        {
            return true;
        }

        public override int GetHashCode()
        {
            return description.GetHashCode();
        }

    }
}
