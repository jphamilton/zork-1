
//Verb 'chase' 'come' 'follow' 'pursue'
//    * object						-> Follow
//    * 							-> Follow

namespace Zork1.Library.ActionRoutines;
public class Follow : Routine
{
    public Follow()
    {
        Verbs = ["chase", "come", "follow", "pursue"];
        Requires = [X.Noun];
    }
    public override bool Handler(Object first, Object second = null)
    {
        return Print("You're nuts!");
    }
}
