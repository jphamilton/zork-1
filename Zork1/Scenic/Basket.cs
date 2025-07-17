using Zork1.Handlers;
using Zork1.Library;
using Zork1.Rooms;

namespace Zork1.Scenic;

public abstract class Basket : Container
{
    protected static bool Raised { get; set; } = true;

    public Basket()
    {
        TryTake = true;
    }

    public override void Initialize()
    {
        var (basket1, basket2, shaft_room, drafty_room) = Get<Basket1, Basket2, ShaftRoom, DraftyRoom>();

        Before<Take>(() => Print("The cage is securely fastened to the iron chain."));

        Before(() =>
        {
            if (Noun is Basket2 || (Second is Basket2 && Location.Has<Basket2>()))
            {
                return Print("The basket is at the other end of the chain.");
            }

            return false;
        });

        Before<Raise>(() =>
        {
            if (Raised)
            {
                return Print(Tables.Dummy.Pick());
            }

            basket1.Move(shaft_room);
            basket2.Move(drafty_room);
            Raised = true;
            SetLast.Object(basket1);

            return Print("The basket is raised to the top of the shaft.");
        });

        Before<Lower>(() =>
        {
            if (!Raised)
            {
                return Print(Tables.Dummy.Pick());
            }

            basket1.Move(drafty_room);
            basket2.Move(shaft_room);
            Raised = false;
            SetLast.Object(basket2);

            return Print("The basket is lowered to the bottom of the shaft.");
        });
    }
}

public class Basket1 : Basket
{
    public Basket1()
    {
        Capacity = 50;
        Transparent = true;
        Open = true;
    }

    public override void Initialize()
    {
        Name = "basket";
        Adjectives = ["basket", "cage", "dumbwaiter"];
        Description = "At the end of the chain is a basket.";
        base.Initialize();
    }
}

public class Basket2 : Basket
{
    public override void Initialize()
    {
        Name = "basket";
        Adjectives = ["basket", "cage", "dumbwaiter", "lowered"];
        Description = "From the chain is suspended a basket.";
        base.Initialize();
    }
}
