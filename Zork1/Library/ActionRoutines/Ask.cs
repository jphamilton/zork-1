namespace Zork1.Library.ActionRoutines;

/*
 Verb 'ask'
    * creature 'about' topic                    -> Ask
    * creature 'for' noun                       -> AskFor
    * creature 'to' topic                       -> AskTo
    * 'that' creature topic                     -> AskTo; -- NOT IMPLEMENTING
 */

public class Ask : Routine
{
    public Ask()
    {
        Verbs = ["ask"];
        Prepositions = ["about"];
        Requires = [X.Animate, X.Topic];
    }

    public override bool Handler(Object first, Object second = null)
    {
        return Print("There was no reply.");
    }
}

public class AskFor : Ask
{
    public AskFor()
    {
        Verbs = ["ask"];
        Prepositions = ["for"];
        Requires = [X.Animate, X.Noun];
    }
}

public class AskTo : Ask
{
    public AskTo()
    {
        Verbs = ["ask"];
        Prepositions = ["to"];
    }
}
