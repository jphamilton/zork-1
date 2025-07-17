namespace Zork1.Things;

public class CrystalSkull : Object
{
    public CrystalSkull()
    {
        TrophyValue = 10;
        TakeValue = 10;
        Takeable = true;
    }

    public override void Initialize()
    {
        Name = "crystal skull";
        Adjectives = ["skull", "crystal", "head", "treasure"];
        Initial = "Lying in one corner of the room is a beautifully carved crystal skull. It appears to be grinning at you rather nastily.";
    }
}