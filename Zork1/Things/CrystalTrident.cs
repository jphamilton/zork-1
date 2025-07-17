namespace Zork1.Things;

public class CrystalTrident : Object
{
    public CrystalTrident()
    {
        TakeValue = 4;
        TrophyValue = 11;
        Size = 20;
        Takeable = true;
    }

    public override void Initialize()
    {
        Name = "crystal trident";
        Adjectives = ["trident", "crystal", "fork", "poseidon", "own", "treasure"];
        Initial = "On the shore lies Poseidon's own crystal trident.";
    }
}