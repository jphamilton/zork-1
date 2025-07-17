namespace Zork1.Things;

public class RustyKnife : Object
{
    public RustyKnife()
    {
        TryTake = true;
        Takeable = true;
        Tool = true;
        Weapon = true;
        Size = 20;
    }

    public override void Initialize()
    {
        Name = "rusty knife";
        Adjectives = ["knife", "kbives", "rusty"];
        Initial = "Beside the skeleton is a rusty knife.";
    }
}
