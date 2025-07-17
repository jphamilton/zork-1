namespace Zork1.Things;

public class LargeEmerald : Object
{
    public LargeEmerald()
    {
        TrophyValue = 10;
        TakeValue = 5;
        Takeable = true;
    }

    public override void Initialize()
    {
        Name = "large emerald";
        Adjectives = ["emerald", "large", "treasure"];
    }
}
