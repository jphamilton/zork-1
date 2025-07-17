namespace Zork1.Library.ActionRoutines;

// Zork

//Verb 'wind'
//    * 'up'/'u//' object		-> WindUp
//    * object					-> WindUp
//;

public class WindUp : Routine
{
    public WindUp()
    {
        Verbs = ["wind"];
        Prepositions = ["up"];
        Requires = [X.Noun];
    }

    public override bool Handler(Object first, Object second = null)
    {
        return Print($"You cannot wind up a {first.Name}");
    }
}
