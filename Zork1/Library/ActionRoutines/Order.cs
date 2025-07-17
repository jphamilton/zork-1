namespace Zork1.Library.ActionRoutines;

public class Order : Routine
{
    public Order()
    {
        Verbs = ["order"];
        Requires = [X.Animate];
    }

    public override bool Handler(Object creature, Object _)
    {
        return Fail($"{creature.DName} has better things to do.");
    }
}
