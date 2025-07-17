namespace Zork1.Things;

public class PotOfGold : Object
{
    public PotOfGold()
    {
        TakeValue = 10;
        TrophyValue = 10;
        Size = 15;
        Concealed = true;
        Takeable = true;
    }

    public override void Initialize()
    {
        Name = "pot of gold";
        Adjectives = ["gold", "pot", "treasure"];
        Initial = "At the end of the rainbow is a pot of gold.";
    }
}