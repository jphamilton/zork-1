using Zork1.Library;
using Zork1.Library.Things;
using Zork1.Things;

namespace Zork1.Library.ActionRoutines;

//Verb 'find' 'see' 'seek' 'where'
//    * object						-> Find

//[ FindSub env ;	! 31062 / 0x7956
//    env = parent(noun);
//    if (noun == pair_of_hands or blast_of_air) {
//        "Within six feet of your head, assuming you haven't left that somewhere.";
//    }
//    if (noun == you) {
//        "You're around here somewhere...";
//    }
//    if (env == global_objects) {
//        "You find it.";
//    }
//    if (noun in player) {
//        "You have it.";
//    }
//    if (noun in location || InRoomContains(noun,location) || noun == pseudo) {
//        "It's right here.";
//    }
//    if (env has animate) {
//        "The ", (name) env, " has it.";
//    }
//    if (env has supporter) {
//        "It's on the ", (name) env, ".";
//    }
//    if (env has container) {
//        "It's in the ", (name) env, ".";
//    }
//    "Beats me.";
//];

public class Find : Routine
{
    public Find()
    {
        Verbs = ["find", "see", "seek", "where"];
        Requires = [X.Noun];
    }

    public override bool Handler(Object noun, Object _ = null)
    {
        var parent = noun.Parent;

        if (noun is PairOfHands || noun is BlastOfAir)
        {
            return Print("Within six feet of your head, assuming you haven't left that somewhere.");
        }

        if (noun == Player.Instance)
        {
            return Print("You're around here somewhere...");
        }

        // Need to test this
        //    if (env == global_objects) {
        //        "You find it.";
        //    }

        if (Inventory.Contains(noun))
        {
            return Print("You have it.");
        }

        if (CurrentRoom.Contains(noun))
        {
            return Print("It's right here.");
        }
            
        if (parent?.Animate == true) {
            return Print($"The {parent.Name} has it.");
        }

        if (parent is Supporter supporter)
        {
            return Print($"It's on the {supporter.Name}.");
        }
        
        if (parent is Container container)
        {
            return Print($"It's in the {container.Name}.");
        }

        return Print("Beats me.");
    }
}
