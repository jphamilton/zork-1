namespace Zork1.Things;

public class JadeFigurine : Object
{
    public JadeFigurine()
    {
        Takeable = true;
        TakeValue = 5;
        TrophyValue = 5;
        Size = 10;
    }

    public override void Initialize()
    {
        Name = "jade figurine";
        Adjectives = ["jade", "figurine", "exquisite", "treasure"];
        Description = "There is an exquisite jade figurine here.";
    }
}