namespace Zork1.Things;

public class BurnedOutLantern : Object
{
    public BurnedOutLantern()
    {
        Size = 20;
        Takeable = true;
    }

    public override void Initialize()
    {
        Name = "burned-out lantern";
        Adjectives = ["lantern", "lamp", "rusty", "burned", "dead", "useless"];
        Initial = "The deceased adventurer's useless lantern is here.";
    }
}