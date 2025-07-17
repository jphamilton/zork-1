namespace Zork1.Things;

public class PileOfCoal : Object
{
    public PileOfCoal()
    {
        Takeable = true;
        Flammable = true;
        Size = 20;
    }

    public override void Initialize()
    {
        Name = "small pile of coal";
        Adjectives = ["coal", "pile", "small", "heap"];
    }
}
