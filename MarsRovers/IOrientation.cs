namespace MarsRovers
{
    public interface IOrientation
    {
        IOrientation TurnLeft();
        IOrientation TurnRight();
        Coordinates Advance(Coordinates coordinates);
    }
}
