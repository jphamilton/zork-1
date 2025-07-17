namespace Zork1.Library.ActionRoutines;

// Zork

//Verb 'cross' 'ford'
//    * object						-> Cross
//;
public class Cross : Routine
{
    public Cross()
    {
        Verbs = ["cross", "fjord"];
        Requires = [X.Noun];
    }
    public override bool Handler(Object first, Object second = null)
    {
        return Print("You can't cross that!");
    }
}
