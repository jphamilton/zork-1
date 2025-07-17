namespace Zork1.Things;

public class Wrench : Object
{
    public Wrench()
    {
        Size = 10;
        Takeable = true;
        Tool = true;
    }

    public override void Initialize()
    {
        Name = "wrench";
        Adjectives = ["wrench", "tool", "tools"];
    }
}
