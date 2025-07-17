using Zork1.Library.Utilities;

namespace Zork1.Library.ActionRoutines;
public class Restart : Routine
{
    public Restart()
    {
        Verbs = ["restart"];
        NoTurn = true;
    }

    public override bool Handler(Object first, Object second = null)
    {
        Score.Print();

        if (YesOrNo.Ask("Do you wish to restart?"))
        {
            Context.Story.Initialize();
            return true;
        }

        return false;
    }
}
