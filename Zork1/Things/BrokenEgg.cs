using Zork1.Library;

namespace Zork1.Things;

public class BrokenEgg : Container
{
    public BrokenEgg()
    {
        Open = true;
        Capacity = 6;
        TrophyValue = 2;
        Takeable = true;
    }

    public override void Initialize()
    {
        Name = "broken jewel-encrusted egg";
        Adjectives = ["broken", "egg", "birds", "encrusted", "jewel", "treasure"];
        Description = "There is a somewhat ruined egg here.";
        IsHere<BrokenCanary>();
    }
}
