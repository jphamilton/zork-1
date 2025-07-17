using Zork1.Handlers;
using Zork1.Library;
using Zork1.Library.Things;
using Zork1.Rooms;
using Zork1.Scenic;

namespace Zork1.Things;

public interface IGlobalObject;

public abstract class GlobalObject : Object, IGlobalObject
{
    protected GlobalObject()
    {
        Scenery = true;
    }
}

public class NotHere : GlobalObject
{
    public override void Initialize()
    {
        Name = "such thing";

        //[ Not_Here_Object_F obj ind_obj=true UNUSED ;	! 20418 / 0x4fc2
        //    if (noun == not_here_object && second == not_here_object) {
        //        "Those things aren't here!";
        //    }
        //    if (noun == not_here_object) {
        //        obj = P_prso;
        //    } else {
        //        obj = P_prsi;
        //        ind_obj = false;
        //    }
        //    P_cont = 0;
        //    P_quote_flag = false;
        //    if (player == actor) {
        //        print "You can't see any";
        //        Print_no_see(ind_obj);	! not popped
        //        " here!";
        //    }
        //    print "The ", (name) player, " seems confused. ~I don't see any";
        //    Print_no_see(ind_obj);	! not popped
        //    " here!~";
        //];
    }
}

public class It : GlobalObject
{
    public It()
    {
        Visited = true;
        Scenery = true;
    }

    public override void Initialize()
    {
        Name = "random object";
        Adjectives = ["it", "them", "her", "him"];
    }
}

public class Number : GlobalObject
{
    public int Value { get; set; }

    public Number()
    {
        Name = "number";
        Tool = true;
    }

    public override void Initialize() { }
}

public class SetOfTeeth : GlobalObject
{
    public SetOfTeeth()
    {
        Scenery = true;
    }

    public override void Initialize()
    {
        Name = "set of teeth";
        Adjectives = ["overboard", "teeth"];

        Before<Brush>(() =>
        {
            if (Second is ViscousMaterial && Player.Has(Second))
            {
                return JigsUp("Well, you seem to have been brushing your teeth with some sort of glue. " +
                    "As a result, your mouth gets glued together (with your nose) and you die of respiratory failure.");
            }

            if (Second == null)
            {
                return Print("Dental hygiene is highly recommended, but I'm not sure what you want to brush them with.");
            }

            return Print($"A nice idea, but with a {Second}?");
        });
    }
}

public class BlastOfAir : GlobalObject
{
    public override void Initialize()
    {
        Name = "blast of air";
        Adjectives = ["lungs", "air", "mouth", "breath"];
    }
}

public class Blessings : GlobalObject
{
    public override void Initialize()
    {
        Name = "blessings";
        Adjectives = ["blessings", "graces"];
    }
}

public class Ground : GlobalObject
{
    public override void Initialize()
    {
        Name = "ground";
        Adjectives = ["ground", "sand", "dirt", "floor"];

        Before<PutOn, Insert>(() => Redirect.To<Drop>(Noun));

        Before<Dig>(() =>
        {
            if (Location is SandyCave)
            {
                var sand = Get<Sand>();
                return sand.GetBefore<Dig>()();
            }

            return Print("The ground is too hard for digging here.");
        });
    }
}

public class PairOfHands : GlobalObject
{
    public PairOfHands()
    {
        Tool = true;
    }

    public override void Initialize()
    {
        Name = "pair of hands";
        Adjectives = ["hands", "hand", "bare", "pair"];
    }
}

public class PileOfBodies : GlobalObject
{
    public PileOfBodies()
    {
        TryTake = true;
    }

    public override void Initialize()
    {
        Name = "pile of bodies";
        Adjectives = ["bodies", "body", "remains", "pile", "mangled"];
        Before<Take>(() => Print("A force keeps you from taking the bodies."));
        Before<Burn, Poke>(() => JigsUp("The voice of the guardian of the dungeon booms out from the darkness, " +
            "~Your disrespect costs you your life!~ and places your head on a sharp pole."));
    }
}

public class Grue : GlobalObject
{
    public override void Initialize()
    {
        Name = "lurking grue";
        Adjectives = ["grue", "lurking", "sinister", "hungry", "silent"];
        Before<Examine>(() => Print("The grue is a sinister, lurking presence in the dark places of the earth. " +
            "Its favorite diet is adventurers, but its insatiable appetite is tempered by its fear of light. " +
            "No grue has ever been seen by the light of day, and few have survived its fearsome jaws to tell the tale."));
        Before<Find>(() => Print("There is no grue here, but I'm sure there is at least one lurking in the darkness nearby. " +
            "I wouldn't let my light go out if I were you!"));
        Before<Listen>(() => Print("It makes no sound but is always lurking in the darkness nearby."));
    }
}