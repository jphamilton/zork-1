namespace Zork1.Library.ActionRoutines;

/*
ZORK
Verb 'go' 'proceed' 'run' 'step' 'walk'
    * 'down'/'d//' climbable(in_room,on_ground)		-> ClimbDown
    * 'up'/'u//' climbable(in_room,on_ground)		-> ClimbUp
    * 'around' object					-> WalkAround
    * 'to' object					-> WalkTo
    * 'over' object					-> Dive
    * 'onto'/'on' object				-> EnterObj
    * 'with'/'using'/'thru'/'through' object		-> EnterObj
    * 'into'/'inside'/'in' object			-> EnterObj
    * 'away' object					-> Go
    * object						-> Go
*/

public class WalkAround : Routine
{
    public WalkAround()
    {
        Verbs = ["go", "proceed", "run", "step", "walk"];
        Prepositions = ["around"];
        Requires = [X.Noun];
    }

    public override bool Handler(Object first, Object second = null)
    {
        return Print(Messages.UseCompassDirections);
    }
}

//---- These are old
public class GoVague : Routine
{
    public GoVague()
    {
        Verbs = ["go", "proceed", "run", "step", "walk"];
        Requires = [];
    }

    public override bool Handler(Object _, Object __)
    {
        return Fail(Messages.UseCompassDirections);
    }
}

public class Go : Enter
{
    public Go()
    {
        Verbs = ["go", "proceed", "run", "step", "walk"];
    }

    public override bool Handler(Object _, Object __)
    {
        return Fail(Messages.UseCompassDirections);
    }
}

public class GoIn : Enter
{
    public GoIn()
    {
        Verbs = ["go", "proceed", "run", "step", "walk"];
        Prepositions = ["in", "through"];
    }
}

public class GoOut : Exit
{
    public GoOut()
    {
        Verbs = ["go", "proceed", "run", "step", "walk"];
        Prepositions = ["out"];
    }
}
