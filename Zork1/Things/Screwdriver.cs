namespace Zork1.Things;

public class Screwdriver : Object
{
    public Screwdriver()
    {
        Takeable = true;
        Tool = true;
    }

    public override void Initialize()
    {
        Name = "screwdriver";
        Adjectives = ["screwdriver", "screw", "tool", "tools", "driver"];
    }
}
