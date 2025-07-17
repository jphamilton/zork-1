using Zork1.Handlers;
using Zork1.Library;

namespace Zork1.Things;

public class TrophyCase : Container
{
    public bool Complete { get; set; }

    public TrophyCase()
    {
        Capacity = 10000;
        Open = false;
        Openable = true;
        Scenery = true;
        Search = true;
        Transparent = true;
        TryTake = false;
    }

    public override void Initialize()
    {
        Name = "trophy case";
        Adjectives = ["trophy", "case"];
        IsHere<AncientMap>();
        Before<Take>(() => Print("The trophy case is securely fastened to the wall."));
        After<Insert>(() =>
        {
            if (!Complete && State.Score == 350)
            {
                Complete = true;
                Print("^An almost inaudible voice whispers in your ear, ~Look to your treasures for the final secret.~");
            }
        });
    }
}
