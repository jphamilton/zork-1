namespace Zork1.Scenic;

public class WoodenLadder : Object
{
    public WoodenLadder()
    {
        Scenery = true;
        Climable = true;
    }

    public override void Initialize()
    {
        Name = "wooden ladder";
        Adjectives = ["ladder", "wooden", "ricketty", "narrow"];
    }
}