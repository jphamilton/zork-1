using Zork1.Handlers;
using Zork1.Library;

namespace Zork1.Things;

public class RedBuoy : Container
{
    public bool Flag { get; set; }

    public RedBuoy()
    {
        Capacity = 20;
        Size = 10;
        Takeable = true;
    }

    public override void Initialize()
    {
        Name = "red buoy";
        Adjectives = ["buoy", "red"];
        Initial = "There is a red buoy here (probably a warning).";
        IsHere<LargeEmerald>();

        Before<Open>(() =>
        {
            Score.ScoreObject(Get<LargeEmerald>());
            return false;
        });

        After<Take>(() =>
        {
            if (Flag)
            {
                return;
            }

            Flag = true;

            Print("You notice something funny about the feel of the buoy.");
        });
    }
}
