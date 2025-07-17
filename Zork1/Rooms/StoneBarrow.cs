using Zork1.Handlers;
using Zork1.Library;
using Zork1.Scenic;
using Zork1.Things;

namespace Zork1.Rooms;

public class StoneBarrow : AboveGround
{
    public override void Initialize()
    {
        Name = "Stone Barrow";
        Description = "You are standing in front of a massive barrow of stone. In the east face is a huge stone door which is open. " +
            "You cannot see into the dark of the tomb.";
        WithScenery<StoneDoor, StoneBarrowOb>();
        NorthEastTo<WestOfHouse>();
    }
}

public class InsideTheBarrow : Room
{
    public InsideTheBarrow()
    {
        DryLand = true;
        Sacred = true;
        Light = true;
    }

    public override void Initialize()
    {
        Name = "Inside the Barrow";
        Description = "As you enter the barrow, the door closes inexorably behind you. Around you it is dark, but ahead is an " +
            "enormous cavern, brightly lit. Through its center runs a wide stream. Spanning the stream is a small wooden footbridge, " +
            "and beyond a path leads into a dark tunnel. Above the bridge, floating in the air, is a large sign. It reads:  " +
            "All ye who stand before this bridge have completed a great and perilous adventure which has tested your wit and courage. " +
            "You have mastered the first part of the ZORK trilogy. Those who pass over this bridge must be prepared to undertake an " +
            "even greater adventure that will severely test your skill and bravery!^^" +
            "The ZORK trilogy continues with ~ZORK II: The Wizard of Frobozz~ and is completed in ~ZORK III: The Dungeon Master,~ " +
            "available now at fine stores everywhere.";

        After<Enter>(() =>
        {
            Output.NewLine();
            Score.PrintScore(false);
            Flags.Done = true;
        });
    }
}
