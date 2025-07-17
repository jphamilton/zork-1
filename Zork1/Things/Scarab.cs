namespace Zork1.Things;

public class Scarab : Object
{
    public Scarab()
    {
        Concealed = true;
        Size = 8;
        Takeable = true;
        TakeValue = 5;
        TrophyValue = 5;
    }

    public override void Initialize()
    {
        Name = "beautiful jeweled scarab";
        Adjectives = ["scarab", "bug", "beetle", "treasure", "beautiful", "carved", "jeweled"];
    }
}