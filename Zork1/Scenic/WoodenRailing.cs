namespace Zork1.Scenic;

public class WoodenRailing : Object
{
    public WoodenRailing()
    {
        Scenery = true;
    }

    public override void Initialize()
    {
        Name = "wooden railing";
        Adjectives = ["railing", "wooden", "rail", "wood"];
    }
}