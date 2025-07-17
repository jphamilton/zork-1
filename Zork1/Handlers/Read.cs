using Zork1.Library;
using Zork1.Things;

namespace Zork1.Handlers;

public class Read : Sub
{
    public Read()
    {
        PreSub = PreRead;
    }

    public static bool PreRead(Object noun, Object second)
    {
        if (!State.Lit)
        {
            return Print("It is impossible to read in the dark.");
        }

        if (second?.Transparent != false)
        {
            return false;
        }

        if (second is Number)
        {
            return false;
        }

        return Print($"How does one look through a {second}?");
    }

    public override bool Handler(Object noun, Object second)
    {
        if (!noun.Readable)
        {
            return Print($"How does one read a {noun}?");
        }

        return Print(noun.Text);
    }
}