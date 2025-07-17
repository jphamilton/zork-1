using Zork1.Handlers;

namespace Zork1.Things;

public class BrassBell : Object
{
    public BrassBell()
    {
        Takeable = true;
    }

    public override void Initialize()
    {
        Name = "brass bell";
        Adjectives = ["bell", "brass", "small"];
        Before<Ring>(() =>
        {
            if (Flags.LLD)
            {
                return Print("Ding, dong.");
            }

            return false;
        });
    }
}
