namespace Zork1.Things;

public class Shovel : Object
{
    public Shovel()
    {
        Takeable = true;
        Tool = true;
        Size = 15;
    }

    public override void Initialize()
    {
        Name = "shovel";
        Adjectives = ["shovel", "tool", "tools"];
    }
}