using Zork1.Handlers;
using Zork1.Library;
using Zork1.Things;

namespace Zork1.Scenic;

public abstract class H2O : Object
{
    protected bool WaterAction()
    {
        var water = this;
        var verb = Verb;
        var second = Noun == water ? Second : Noun;
        var noun = Noun == water ? Noun : Second;

        var glassBottle = Get<GlassBottle>();
        var quantityOfWater = Get<QuantityOfWater>();

        if (verb is Fill)
        {
            verb = Routines.Get<Insert>();
        }

        var boat = player.Parent.Vehicle ? player.Parent : null;

        // pi????
        if (verb is Insert || verb is Take)// && !pi)
        {
            if (boat != null && (boat == second || (second == null && !boat.Children.Contains(water))))
            {
                noun.Move(boat);
                return Print($"There is now a puddle in the bottom of the {boat}.");
            }

            if (second != null && second != glassBottle)
            {
                water.Remove();
                return Print($"The water leaks out of the {second} and evaporates immediately.");
            }

            if (player.Has(glassBottle) && second == glassBottle)
            {
                if (!glassBottle.Open)
                {
                    Print("The bottle is closed.");
                    return SetLast.Object(glassBottle);
                }

                if (glassBottle.IsEmpty)
                {
                    quantityOfWater.Move(glassBottle);
                    return Print("The bottle is now full of water.");
                }

                return Print("The bottle is already full.");
            }

            return (glassBottle.In(Location) && glassBottle.Has(quantityOfWater) && verb is Take && second == null)
                ? Print("It's in the bottle. Perhaps you should take that instead.")
                : Print("The water slips through your fingers.");
        }

        //if (pi)
        //{
        //    return Print("Nice try.");
        //}

        if (verb is Give || verb is Drop)
        {
            if (boat != null)
            {
                quantityOfWater.Move(boat);
                return Print($"There is now a puddle in the bottom of the {boat}.");
            }

            quantityOfWater.Remove();
            return Print("The water spills to the floor and evaporates immediately.");
        }

        return false;
    }
}

public class Water : H2O, IGlobalObject
{
    public Water()
    {
        Scenery = true;
        Drinkable = true;
        Takeable = true;
        TryTake = true;
    }

    public override void Initialize()
    {
        Name = "water";
        Adjectives = ["water", "quantity"];
        Before(WaterAction);
        Before<Enter>(() => Print(Tables.NoSwim.Pick()));
    }
}
