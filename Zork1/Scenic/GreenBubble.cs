using Zork1.Handlers;

namespace Zork1.Scenic;

public class GreenBubble : Object
{
    public GreenBubble()
    {
        Scenery = true;
        TryTake = true;
    }

    public override void Initialize()
    {
        Name = "green bubble";
        Adjectives = ["bubble", "green", "small", "plastic"];
        Before<Take>(() => Print(ControlPanel.Integral));
    }
}