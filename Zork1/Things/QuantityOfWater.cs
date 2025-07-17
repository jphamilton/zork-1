using Zork1.Handlers;
using Zork1.Scenic;

namespace Zork1.Things;

public class QuantityOfWater : H2O
{
    public QuantityOfWater()
    {
        Drinkable = true;
        Size = 4;
        Takeable = true;
        TryTake = true;
    }

    public override void Initialize()
    {
        Name = "quantity of water";
        Adjectives = ["water", "quantity", "liquid", "h2o"];
        Before(WaterAction);
        Before<Throw>(() =>
        {
            Remove();
            return Print("The water splashes on the walls and evaporates immediately.");
        });
    }
}