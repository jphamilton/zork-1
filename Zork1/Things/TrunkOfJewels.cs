namespace Zork1.Things;

public class TrunkOfJewels : NoEmpty
{
    public TrunkOfJewels()
    {
        Concealed = true;
        Takeable = true;
        TrophyValue = 5;
        TakeValue = 15;
        Size = 35;
    }

    public override void Initialize()
    {
        Name = "trunk of jewels";
        Description = "There is an old trunk here, bulging with assorted jewels.";
        Initial = "Lying half buried in the mud is an old trunk, bulging with jewels.";
        Adjectives = ["trunk", "chest", "jewels", "treasure", "old"];
    }
}
