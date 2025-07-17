using Zork1.Handlers;

namespace Zork1.Scenic;

public class Crack : Object
{
    public Crack()
    {
        Scenery = true;
    }

    public override void Initialize()
    {
        Name = "crack";
        Adjectives = ["crack", "narrow"];
        Before<Enter>(() => Print("You can't fit through the crack."));
    }
}