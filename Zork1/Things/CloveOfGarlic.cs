using Zork1.Handlers;

namespace Zork1.Things;

public class CloveOfGarlic : Object
{
    public CloveOfGarlic()
    {
        Edible = true;
        Takeable = true;
    }

    public override void Initialize()
    {
        Name = "clove of garlic";
        Adjectives = ["garlic", "clove"];
        Before<Eat>(() =>
        {
            Remove();
            return Print("What the heck! You won't make friends this way, but nobody around here is too friendly anyhow. Gulp!");
        });
    }
}
