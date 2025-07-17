using Zork1.Library;
using Zork1.Scenic;

namespace Zork1.Rooms;

public class SlideRoom : Room
{
    public SlideRoom()
    {
        DryLand = true;
    }

    public override void Initialize()
    {
        Name = "Slide Room";
        Description = "This is a small chamber, which appears to have been part of a coal mine. " +
            "On the south wall of the chamber the letters ~Granite Wall~ are etched in the rock. " +
            "To the east is a long passage, and there is a steep metal slide twisting downward. " +
            "To the north is a small opening.";
        WithScenery<Chute>();
        DownTo<Cellar>();
        EastTo<ColdPassage>();
        NorthTo<MineEntrance>();
    }
}