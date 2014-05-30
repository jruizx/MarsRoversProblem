using MarsRovers.Exceptions;

namespace MarsRovers
{
    public static class OrientationFactory
    {
        public static IOrientation GenerateOrientation(string type)
        {
            switch (type)
            {
                case "N":
                    return new NorthOrientation();
                case "E":
                    return new EastOrientation();
                case "S":
                    return new SouthOrientation();
                case "W":
                    return new WestOrientation();
                default:
                    throw new OrientationException("Unknown orientation type.");
            }
        }
    }
}
