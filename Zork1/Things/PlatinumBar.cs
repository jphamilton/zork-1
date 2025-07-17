namespace Zork1.Things;

public class PlatinumBar : Object
{
    public PlatinumBar()
    {
        TakeValue = 10;
        TrophyValue = 5;
        Size = 20;
        Sacred = true;
        Takeable = true;
    }

    public override void Initialize()
    {
        Name = "platinum bar";
        Adjectives = ["bar", "platinum", "large", "treasure"];
        Description = "On the ground is a large platinum bar.";
    }
}
