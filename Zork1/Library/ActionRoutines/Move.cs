
//Verb 'move'
//    * object 'with'/'using'/'thru'/'through' toolbit	-> MoveWith
//    * object(held, many, have) 'into'/'inside'/'in' object -> Insert
//    * object(in_room, on_ground)				-> Move


namespace Zork1.Library.ActionRoutines;
public class Move : Routine
{
    public Move()
    {
        Verbs = ["move"];
        //    * object(in_room, on_ground)				-> Move
        Requires = [X.Noun];
    }


    public override bool Handler(Object first, Object second = null)
    {
        if (first.Scenery || first.Static)
        {
            return Fail($"Moving the {first} reveals nothing.");
        }

        return Fail($"You can't move the {first}");
    }
}
