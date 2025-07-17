using Zork1.Library;
using Zork1.Library.Things;

namespace Zork1.Handlers;

public class Give : Sub
{
    public Give()
    {
        PreSub = PreGiveTo;
    }

    public static bool PreGiveTo(Object noun, Object second)
    {
        if (noun.In(Player.Instance))
        {
            return false;
        }

        Output.Print($"That's easy for you to say since you don't even have the {noun}.");
        return true;
    }

    public override bool Handler(Object noun, Object second)
    {
        if (!second.Animate)
        {
            return Print($"You can't give a {noun} to a {second}!");
        }

        return Print($"The {noun} refuses it politely.");
    }
}