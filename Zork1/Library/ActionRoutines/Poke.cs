namespace Zork1.Library.ActionRoutines;

//Verb 'poke'
//    * animate(in_room, on_ground) 'with'/'using'/'thru'/'through' weapon(held, carried, have) -> Poke
public class Poke : Routine
{
    public Poke()
    {
        Verbs = ["poke"];
        Prepositions = ["with", "using", "thru", "through"];
        Requires = [X.Animate, X.Held]; // weapon, 
    }

    public override bool Handler(Object first, Object second = null)
    {
        //PokeSub ;	! 32592 / 0x7f50
        //    if (noun has animate) {
        //        Perform(##Attack,noun);	! not popped
        //        rtrue;
        //    }
        //    "Nice try.";
        return Print("Nice try.");
    }
}
