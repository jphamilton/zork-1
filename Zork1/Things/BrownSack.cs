using Zork1.Handlers;
using Zork1.Library;

namespace Zork1.Things;

public class BrownSack : Container
{
    public BrownSack()
    {
        Capacity = 15;
        Size = 3;
        Flammable = true;
        Openable = true;
        Takeable = true;
    }

    public override void Initialize()
    {
        Name = "brown sack";
        Adjectives = ["sack", "bag", "brown", "elongated", "smelly"];
        Initial = "On the table is an elongated brown sack, smelling of hot peppers.";
        var lunch = IsHere<Lunch>();
        IsHere<CloveOfGarlic>();
        Before<Smell>(() =>
        {
            if (Has(lunch))
            {
                return Print("It smells of hot peppers.");
            }

            return false;
        });
    }
}
