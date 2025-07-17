namespace Zork1.Things;

public class BrokenLantern : Object
{
    public BrokenLantern()
    {
        Takeable = true;
    }

    public override void Initialize()
    {
        Name = "broken lantern";
        Adjectives = ["lamp", "lantern", "broken"];
    }
}
