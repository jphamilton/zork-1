namespace Zork1.Things;

public class BrassBauble : Object
{
    public BrassBauble()
    {
        TakeValue = 1;
        TrophyValue = 1;
        Takeable = true;
    }

    public override void Initialize()
    {
        Name = "beautiful brass bauble";
        Adjectives = ["bauble", "treasure", "brass", "beautiful"];
    }
}
