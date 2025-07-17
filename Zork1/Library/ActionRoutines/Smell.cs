namespace Zork1.Library.ActionRoutines;

// Zork
public class Smell : Routine
{
    public Smell()
    {
        Verbs = ["smell", "sniff"];
        Requires = [X.Noun];
    }

    public override bool Handler(Object noun, Object __)
    {
        return Print($"It smells like a {noun.Name}.");
    }
}
