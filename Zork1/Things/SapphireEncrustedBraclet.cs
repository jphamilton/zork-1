namespace Zork1.Things;

public class SapphireEncrustedBraclet : Object
{
    public SapphireEncrustedBraclet()
    {
        TakeValue = 5;
        TrophyValue = 5;
        Size = 10;
        Takeable = true;
    }

    public override void Initialize()
    {
        Name = "sapphire-encrusted bracelet";
        Adjectives = ["sapphire", "bracelet", "jewel", "treasure"];
    }
}