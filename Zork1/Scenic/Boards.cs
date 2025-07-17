using Zork1.Handlers;

namespace Zork1.Scenic;

public class Boards : Object
{
    public Boards()
    {
        Scenery = true;
    }

    public override void Initialize()
    {
        Name = "board";
        Adjectives = ["board", "boards"];
        Before<Take, Examine>(() => Print("The boards are securely fastened."));
    }
}
