namespace Zork1.Scenic;

public class WoodenDoor : FakeDoor
{
    public WoodenDoor()
    {
        // https://github.com/the-infocom-files/zork1/issues/41
        // Transparent = true;
        Readable = true;
    }

    public override void Initialize()
    {
        Name = "wooden door";
        Adjectives = ["door", "wooden", "gothic", "strange", "letter", "writing"];
        Text = "The engravings translate to ~This space intentionally left blank.~";
        Before(FakeDoorAction);
    }
}
