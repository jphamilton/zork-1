using Zork1.Scenic;

namespace Zork1.Rooms;

public class ForestPath : SongBirdRoom
{
    public override void Initialize()
    {
        base.Initialize();

        Name = "Forest Path";
        Description = "This is a path winding through a dimly lit forest. The path heads north-south here. One particularly large tree with some low branches stands at the edge of the path.";
        WithScenery<Tree, Songbird, WhiteHouse, Forest>();
        UpTo<UpATree>();
        SouthTo<NorthOfHouse>();
        WestTo<Forest1>();
        EastTo<Forest2>();
        NorthTo<Clearing1>();
    }
}
