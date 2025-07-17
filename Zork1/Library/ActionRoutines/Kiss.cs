namespace Zork1.Library.ActionRoutines;

public class Kiss : Routine
{
    public Kiss()
    {
        Verbs = ["kiss", "embrace", "hug"];
        Requires = [X.Animate];
    }
    public override bool Handler(Object first, Object second = null)
    {
        return Print("Keep your mind on the game.");
    }
}
