//Verb 'hatch'
//    * object						-> Hatch
//;
namespace Zork1.Library.ActionRoutines;
public class Hatch : Routine
{
    public Hatch()
    {
        Verbs = ["hatch"];
        Requires = [X.Noun];
    }

    public override bool Handler(Object first, Object second = null) => Print("Bizarre!");
}
