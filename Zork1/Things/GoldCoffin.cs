using Zork1.Library;

namespace Zork1.Things;

public class GoldCoffin : Container
{
    public GoldCoffin()
    {
        Search = true;
        Sacred = true;
        Takeable = true;
        Capacity = 35;
        TakeValue = 10;
        TrophyValue = 15;
        Size = 55;
    }

    public override void Initialize()
    {
        Name = "gold coffin";
        Adjectives = ["coffin", "casket", "gold", "solid", "treasure"];
        Description = "The solid-gold coffin used for the burial of Ramses II is here.";
        IsHere<Sceptre>();
    }
}
