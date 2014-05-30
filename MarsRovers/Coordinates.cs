using System;

namespace MarsRovers
{
    public class Coordinates : IEquatable<Coordinates>
    {
        private readonly int x;
        private readonly int y;

        public Coordinates(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int X
        {
            get { return x; }
        }

        public int Y
        {
            get { return y; }
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Coordinates))
                return false;

            return Equals((Coordinates) obj);
        }

        public bool Equals(Coordinates other)
        {
            if (x != other.x)
                return false;

            return y == other.y;  
        }

        public override int GetHashCode()
        {
            return x ^ y;
        }

        public static bool operator ==(Coordinates coordinates1, Coordinates coordinates2)
        {
            return coordinates1.Equals(coordinates2);
        }

        public static bool operator !=(Coordinates coordinates1, Coordinates coordinates2)
        {
            return !coordinates1.Equals(coordinates2);
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", x, y);
        }
    }
}