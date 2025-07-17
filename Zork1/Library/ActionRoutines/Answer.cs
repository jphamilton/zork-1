namespace Zork1.Library.ActionRoutines;

//Verb 'answer' 'say' 'shout' 'speak'
//    * topic 'to' creature                       -> Answer;

public class Answer : Routine
{
    public Answer()
    {
        Verbs = ["answer", "say", "shout", "speak"];
        Prepositions = ["to"];
        Requires = [X.Topic, X.Animate];
    }

    public override bool Handler(Object first, Object second = null)
    {
        return Print("There is no reply.");
    }
}
