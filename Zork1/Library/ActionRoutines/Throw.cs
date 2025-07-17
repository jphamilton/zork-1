namespace Zork1.Library.ActionRoutines;

// Zork syntax
//Verb 'chuck' 'hurl' 'throw' 'toss'
//      IMPLEMENTED * object(held,carried,have) 'over' object		-> ThrowOver
//      IMPLEMENTED * object(held,carried,have) 'off' object		-> ThrowOver
//    * object(held,carried,have) 'onto'/'on' object	-> PutOn
//    * object(held,carried,have) 'into'/'inside'/'in' object -> Insert
//    * object object					-> ThrowTo
//    * object(held,carried,have) 'with'/'using'/'thru'/'through' animate(in_room, on_ground) -> Throw
//    * object (held, carried, have) 'at' animate(in_room, on_ground) -> Throw
//;
public class ThrowOver : Routine
{
    public ThrowOver()
    {
        Verbs = ["throw"];
        Prepositions = ["over", "off"];
        Requires = [X.Held, X.Noun];
    }

    public override bool Handler(Object held, Object noun)
    {
        return Print("You can't throw anything off of that!");
    }

}

// THIS IS OLD
//Verb 'throw'
//    * held 'at'/'against'/'on'/'onto' noun      -> ThrowAt;
public class Throw : Routine
{
    public Throw()
    {
        Verbs = ["throw"];
        Prepositions = ["at", "against", "on", "onto"];
        Requires = [X.Held, X.Noun];
    }

    public override bool Handler(Object held, Object noun)
    {
        if (noun.Animate)
        {
            return Fail("You lack the nerve when it comes to the crucial moment.");
        }

        return Fail("Futile.");
    }

}

