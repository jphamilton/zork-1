using Zork1.Handlers;

namespace Zork1.Scenic;

public class BoardedWindow : Object
{
    public BoardedWindow()
    {
        Scenery = true;
    }

    public override void Initialize()
    {
        Name = "boarded window";
        Adjectives = ["boarded", "window"];
        Before<Open>(() => Print("The windows are boarded and can't be opened."));
        Before<Poke>(() => Print("You can't break the windows open."));
    }
}
