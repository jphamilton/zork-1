namespace Zork1.Things;

public class VitreousSlag : Object
{
    public VitreousSlag()
    {
        Size = 10;
        TryTake = true;
        Takeable = true;
    }

    public override void Initialize()
    {
        Name = "small piece of vitreous slag";
        Adjectives = ["slag", "gunk", "small", "vitreous", "piece"];
        Before(() =>
        {
            Remove();
            return Print("The slag was rather insubstantial, and crumbles into dust at your touch.");
        });
    }
}