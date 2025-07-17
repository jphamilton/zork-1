namespace Zork1.Library.ActionRoutines;

internal class Pray : Routine
{
    public Pray()
    {
        Verbs = ["pray"];
    }

    public override bool Handler(Object first, Object second = null)
    {
        return Print("Nothing practical results from your prayer.");
    }
}
