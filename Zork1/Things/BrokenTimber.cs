namespace Zork1.Things;

public class BrokenTimber : Object
{
    public BrokenTimber()
    {
        Size = 50;
        Takeable = true;
    }

    public override void Initialize()
    {
        Name = "broken timber";
        Adjectives = ["timber", "pile", "wooden", "broken"];
    }
}