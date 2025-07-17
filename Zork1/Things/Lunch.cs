namespace Zork1.Things;

public class Lunch : Object
{
    public Lunch()
    {
        Edible = true;
        Takeable = true;
    }

    public override void Initialize()
    {
        Name = "lunch";
        Description = "A hot pepper sandwich is here.";
        Adjectives = ["food", "sandwich", "lunch", "dinner", "hot", "pepper"];
    }
}
