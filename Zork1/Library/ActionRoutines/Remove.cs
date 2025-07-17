
/*
Verb 'remove'
* held                                      -> Disrobe
* multi                                     -> Take (NOT IMPLEMENTING)

* multiinside 'from' noun                   -> Remove; 
* multiinside 'from' noun                   -> // ALSO TAKE??? 

* multiinside 'off' noun                    -> not implemented

*/

using Zork1.Library;
using Zork1.Library.Things;

namespace Zork1.Library.ActionRoutines;

public class Remove : Disrobe
{
    public Remove()
    {
        Verbs = ["remove"];
        Requires = [X.Held];
    }
}

public class RemoveFrom : Take //Routine
{
    public RemoveFrom()
    {
        Verbs = ["remove"];
        Prepositions = ["from"];
        Requires = [X.MultiInside, X.Noun];
    }

    public override bool Handler(Object first, Object second)
    {
        if (second is not Container)
        {
            return Print(Messages.OLD_CantSeeObject);
        }

        if (second is Container container && container.Contains(first))
        {
            if (!container.Open && !Implicit.Action<Open>(second))
            {
                return false;
            }

            // subtle difference here
            // if container is in inventory, the object inside has essensitally been taken already
            if (Inventory.Contains(container))
            {
                Player.Add(first);
                return Print("Removed.");
            }
            else if (Inventory.CanAdd())
            {
                Player.Add(first);
                return Print("Removed.");
            }
            else
            {
                return Fail(Messages.OLD_CarryingTooMuch);
            }
        }

        return Fail(Messages.OLD_CantSeeObject);
    }
}
