namespace Zork1.Scenic;

public class FrontDoor : FakeDoor
{
    public override void Initialize()
    {
        Name = "door";
        Adjectives = ["door", "front", "boarded"];
        Before(FakeDoorAction);
    }
}