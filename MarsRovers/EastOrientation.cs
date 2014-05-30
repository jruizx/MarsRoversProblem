namespace MarsRovers
{
    public class EastOrientation : IOrientation
    {
        private const string description = "E";

        public IOrientation TurnLeft()
        {
            return new NorthOrientation();
        }

        public IOrientation TurnRight()
        {
            return new SouthOrientation();
        }

        public Coordinates Advance(Coordinates coordinates)
        {
            return new Coordinates(coordinates.X + 1, coordinates.Y);
        }

        public override bool Equals(object obj)
        {
            return obj is EastOrientation;
        }

        public override string ToString()
        {
            return description;
        }

        public bool Equals(EastOrientation other)
        {
            return true;
        }

        public static bool operator ==(EastOrientation orientation1, EastOrientation orientation2)
        {
            return true;
        }

        public static bool operator !=(EastOrientation orientation1, EastOrientation orientation2)
        {
            return true;
        }  

        public override int GetHashCode()
        {
            return description.GetHashCode();
        }
    }
}
