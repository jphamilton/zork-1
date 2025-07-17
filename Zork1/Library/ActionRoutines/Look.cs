namespace Zork1.Library.ActionRoutines;

public class Look : Routine
{
    public Look()
    {
        Verbs = ["look", "l"];
    }

    public override bool Handler(Object _, Object __)
    {
        CurrentRoom.Look(true);
        return true;
    }
}

// Zork
public class LookBehind : Routine
{
    public LookBehind()
    {
        Verbs = ["look", "l"];
        Prepositions = ["behind"];
        Requires = [X.Noun];
    }

    public override bool Handler(Object first, Object second = null)
    {
        return Print($"There is nothing behind the {first}.");
    }
}


public class LookIn : Routine
{
    public LookIn()
    {
        Verbs = ["look", "l"];
        Prepositions = ["in", "through", "on"];
        Requires = [X.Noun];
    }

    public override bool Handler(Object first, Object second = null)
    {
        return Print($"You can't look inside {first.IName}.");
    }
}

public class LookAt : Examine
{
    public LookAt()
    {
        Verbs = ["look at"];
    }
}

// this Zork 
public class LookUnder : Routine
{
    public LookUnder()
    {
        Verbs = ["look", "l"];
        Prepositions = ["under"];
        Requires = [X.Noun];
    }

    public override bool Handler(Object _, Object __)
    {
        return Print("There is nothing but dust there.");
    }
}

public class LookDirection : Routine
{
    public LookDirection()
    {
        Verbs = ["look", "l"];
        Requires = [X.Noun];
    }

    public override bool Handler(Object obj, Object _)
    {
        return Print("You see nothing unexpected in that direction.");
    }
}