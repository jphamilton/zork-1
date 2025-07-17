using Zork1.Library;
using Zork1.Library.Utilities;

namespace Zork1.Library.ActionRoutines;

public class Quit : Routine
{
    public Quit()
    {
        Verbs = ["quit", "q"];
        NoTurn = true;
    }

    public override bool Handler(Object first, Object second = null)
    {
        Score.Print();

        if (YesOrNo.Ask("Do you wish to quit?"))
        {
            State.IsDone = true;
        }

        return false;
    }

}
