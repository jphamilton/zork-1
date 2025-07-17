using Zork1.Handlers;

namespace Zork1.Things;

public abstract class NoEmpty : Object
{
    protected bool DoNotEmpty(string name)
    {
        if (Verb is Open || Verb is Close)
        {
            return Print($"The {name} are safely inside; there's no need to do that.");
        }

        if (Verb is Examine || Verb is LookIn)
        {
            return Print($"There are lots of {name} in there.");
        }

        if (Verb is not Insert || Second != this)
        {
            return false;
        }

        return Print($"Don't be silly. It wouldn't be a {this} anymore.");
    }
}

public class BagOfCoins : NoEmpty
{

    public BagOfCoins()
    {
        Takeable = true;
        TrophyValue = 5;
        TakeValue = 10;
        Size = 15;
    }

    public override void Initialize()
    {
        Name = "leather bag of coins";
        Adjectives = ["bag", "coins", "treasure", "old", "leather"];
        Description = "An old leather bag, bulging with coins, is here.";
        Before(() => DoNotEmpty("coins"));
    }
}
