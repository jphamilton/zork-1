using Zork1.Library.Things;

namespace Zork1.Library.ActionRoutines;

/*
 Verb 'climb' 'sit'
    * 'with'/'using'/'thru'/'through' object		-> EnterObj
    * 'onto'/'on' vehicle(in_room,on_ground)		-> ClimbOn
    * 'into'/'inside'/'in' vehicle(in_room,on_ground)	-> Board
    * climbable(in_room,on_ground)			-> ClimbObj
    * 'down'/'d//' climbable(in_room,on_ground)		-> ClimbDown
    * 							-> ClimbDown
    * 'up'/'u//' climbable(in_room,on_ground)		-> ClimbUp
    * 							-> ClimbUp
;
 */

//[ ClimbObjSub ;	! 29486 / 0x732e
//    return ClimbUpSub(u_to,noun);
//];

//[ ClimbOnSub ;	! 29496 / 0x7338
//    if (noun has vehicle) {
//        return ClimbUpSub(u_to,pair_of_hands);
//    }
//    "You can't climb onto the ", (name) noun, ".";
//];

//[ ClimbDownSub ;	! 29476 / 0x7324
//    return ClimbUpSub(d_to,noun);
//];

//[ ClimbUpSub dir=u_to obj pnum paddr UNUSED ;	! 29528 / 0x7358
//    if ((~~obj) && noun) {
//        obj = noun;
//    }
//    paddr = location.&dir;
//    if (paddr) {
//        if (obj) {
//            pnum = get_prop_len(paddr);
//            if (pnum == 2 || (pnum == 4 or 5 or 1 && (~~InRoomContains(noun,paddr->0)))) {
//                print "The ", (name) obj, " do";
//                if (obj ~= stairs) {
//                    print "es";
//                }
//                print "n't lead ";
//                if (dir == u_to) {
//                    print "up";
//                } else {
//                    print "down";
//                }
//                "ward.";
//            }
//        }
//        PlayerToProp(dir);	! not popped
//        rtrue;
//    }
//    if (~~obj) {
//        "You can't go that way.";
//    }
//    if (obj) {
//        pnum = noun.&name;
//        if (ZMemQ('wall',pnum,get_prop_len(pnum))) {
//            "Climbing the walls is to no avail.";
//        }
//    }
//    "You can't do that!";
//];
public class Climb : Routine
{
    public Climb()
    {
        Verbs = ["climb"];
        Requires = [X.Noun];
    }

    public override bool Handler(Object obj, Object _)
    {
        if (obj.Vehicle)
        {
            // return ClimbUpSub(u_to,pair_of_hands);
        }

        return Print($"You can't climb onto the {obj}.");
    }
}

public class ClimbOn : Routine
{
    public ClimbOn()
    {
        Verbs = ["climb", "sit"];
        Prepositions = ["on", "onto"];
        Requires = [X.Noun];
    }

    public override bool Handler(Object obj, Object _)
    {
        if (obj.Vehicle)
        {
            // return ClimbUpSub(u_to,pair_of_hands);
        }

        return Print($"You can't climb onto the {obj}.");
    }
}

public class ClimbUp : Routine
{
    public ClimbUp()
    {
        Verbs = ["climb"];
        Prepositions = ["up", "u"];
    }

    public override bool Handler(Object first, Object second = null)
    {
        if (!first.Climable)
        {
            return Print("You can't do that!");
        }

        if (!Location.CanGo<Up>())
        {
            var dooznt = first.PluralName ? "don't" : "doesn't";
            return Print($"The {first} {dooznt} go upward.");
        }

        return Redirect.To<Up>();
    }
}

public class ClimbDown : Routine
{
    public ClimbDown()
    {
        Verbs = ["climb"];
        Prepositions = ["down", "d"];
    }

    public override bool Handler(Object first, Object second = null)
    {
        if (!first.Climable)
        {
            return Print("You can't do that!");
        }

        if (!Location.CanGo<Down>())
        {
            var dooznt = first.PluralName ? "don't" : "doesn't";
            return Print($"The {first} {dooznt} go downward.");
        }

        return Redirect.To<Down>();
    }
}