// Zork syntax
//
//Verb 'dive' 'jump' 'leap'
//    * 'off' object					-> Dive
//    * 'from' object					-> Dive
//    * 'into'/'inside'/'in' object			-> Dive
//    * 'across' object					-> Dive
//    * 'over' object					-> Dive
//    * 							-> Dive
using Zork1.Library.Utilities;

namespace Zork1.Library.ActionRoutines;
public class Dive : Routine
{
    private readonly PickOne HopMsg = new([
        "Very good. Now you can go to the second grade.",
        "Are you enjoying yourself?",
        "Wheeeeeeeeee!!!!!",
        "Do you expect me to applaud?"
    ]);

    public Dive()
    {
        Verbs = ["dive", "jump", "leap"];
        Prepositions = ["off", "from", "in", "into", "inside", "across", "over"];
    }

    public override bool Handler(Object first, Object second = null)
    {
        throw new NotImplementedException();
    }

    private bool JumpSub()
    {
        return Print(HopMsg.Pick());
    }
}

//[ DiveSub prop propsize ;	! 31874 / 0x7c82
//    if (noun) {
//        if (noun in location) {
//            if (noun has animate) {
//                "The ", (name) noun, " is too big to jump over.";
//            }
//            return JumpSub();
//        }
//        "That would be a good trick.";
//    }
//    prop = location.&d_to;
//    if (prop) {
//        propsize = get_prop_len(prop);
//        if (propsize ~= 2) {
//            if (propsize ~= 4) jump label32007;
//            @load (prop->1) -> SP;
//            @jz SP ?~label32007;
//        }
//        print "This was not a very safe place to try jumping.";
//        new_line;
//        return JigsUp(ComplexPickOne(Dive_msg));
//      .label32007;
//        if (location == up_a_tree) {
//            print "In a feat of unaccustomed daring, you manage to land on your feet without killing yourself.";
//            new_line;
//            new_line;
//            PlayerToProp(d_to);	! not popped
//            rtrue;
//        }
//        return JumpSub();
//    }
//    return JumpSub();
//];