namespace Zork1.Things;

public class HugeDiamond : Object
{
    public HugeDiamond()
    {
        TakeValue = 10;
        TrophyValue = 10;
        Takeable = true;
    }

    public override void Initialize()
    {
        Name = "huge diamond";
        Adjectives = ["diamond", "huge", "enormous", "treasure"];
        Description = "There is an enormous diamond (perfectly cut) here.";
    }
}
