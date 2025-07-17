using Zork1.Handlers;
using Zork1.Library;

namespace Zork1.Things;

public class GlassBottle : Container
{
    public GlassBottle()
    {
        Capacity = 4;
        Takeable = true;
        Transparent = true;
    }

    public override void Initialize()
    {
        Name = "glass bottle";
        Adjectives = ["bottle", "container", "clear", "glass"];
        Initial = "A bottle (which contains a quantity of water) is sitting on the table.";
        IsHere<QuantityOfWater>();

        Before(() =>
        {
            var filled = false;
            var water = Get<QuantityOfWater>();

            if (Verb is Throw)
            {
                filled = true;
                Remove();
                Print("The bottle hits the far wall and shatters.");
            }
            else if (Verb is Poke)
            {
                filled = true;
                Remove();
                Print("A brilliant maneuver destroys the bottle.");
            }
            else if (Verb is Shake && Open && Has(water))
            {
                // changed from original, we will return false here
                // so that WaterFunction will ultimately get called
                // filled = true;
                return false;
            }

            if (filled && Has(water))
            {
                Print("The water spills to the floor and evaporates.");
                water.Remove();
                return true;
            }

            return filled;
        });
    }
}
