namespace Zork1.Library.ActionRoutines;

public class Read : Routine
{
    public Read()
    {
        Verbs = ["read"];
    }

    // PreReadSub/ReadSub
    public override bool Handler(Object first, Object second = null)
    {
        if (!Lit)
        {
            return Print("It is impossible to read in the dark.");
        }

        //    if ((~~second) || second has transparent) rfalse;
        //    "How does one look through a ", (name) second, "?";

        if (!first.Readable)
        {
            return Fail($"How does one read a {first}?");
        }

        return Print(first.Text);
    }
}