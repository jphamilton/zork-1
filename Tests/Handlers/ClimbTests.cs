using Zork1.Scenic;
using Zork1.Things;

namespace Tests.Handlers;

public class ClimbTests : BaseTestFixture
{
    [Fact]
    public void should_go_down()
    {
        var infinite = Get<InfiniteWhiteRoom>();
        infinite.Light = true;
        var cave = Get<ImposingCave>();
        cave.Light = true;
        cave.DownTo<InfiniteWhiteRoom>();
        Location = cave;
        var stairs = Get<Stairs>();
        cave.Children.Add(stairs);
        Execute("climb down stairs");
        Assert.Equal(player.Parent, infinite);
    }

    [Fact]
    public void should_go_up()
    {
        var infinite = Get<InfiniteWhiteRoom>();
        infinite.Light = true;
        var cave = Get<ImposingCave>();
        cave.Light = true;
        cave.UpTo<InfiniteWhiteRoom>();
        Location = cave;
        var stairs = Get<Stairs>();
        cave.Children.Add(stairs);
        Execute("climb up stairs");
        Assert.Equal(player.Parent, infinite);
    }

    [Fact]
    public void cant_go_that_way()
    {
        var infinite = Get<InfiniteWhiteRoom>();
        infinite.Light = true;
        var cave = Get<ImposingCave>();
        cave.Light = true;
        cave.UpTo<InfiniteWhiteRoom>();
        Location = cave;
        var stairs = Get<Stairs>();
        cave.Children.Add(stairs);
        Execute("climb down stairs");
        Assert.Equal(player.Parent, cave);
        Assert.Contains("The stairs don't lead downward.", ConsoleOut);
    }

    [Fact]
    public void cant_climb_that()
    {
        var cave = Get<ImposingCave>();
        cave.Light = true;
        cave.UpTo<InfiniteWhiteRoom>();
        Location = cave;
        Here<MoonRock>();
        Execute("climb up rock");
        Assert.Equal(player.Parent, cave);
        Assert.Contains("You can't do that!", ConsoleOut);
    }

    [Fact]
    public void cant_go_that_way_2()
    {
        var cave = Get<ImposingCave>();
        cave.Light = true;
        cave.UpTo<InfiniteWhiteRoom>();
        Location = cave;
        Execute("climb down");
        Assert.Equal(player.Parent, cave);
        Assert.Contains("You can't go that way.", ConsoleOut);
    }

    [Fact]
    public void can_go_up()
    {
        var infinite = Get<InfiniteWhiteRoom>();
        infinite.Light = true;
        var cave = Get<ImposingCave>();
        cave.Light = true;
        cave.UpTo<InfiniteWhiteRoom>();
        Location = cave;
        var stairs = Get<Stairs>();
        cave.Children.Add(stairs);
        Execute("climb up");
        Assert.Equal(player.Parent, infinite);
    }

    [Fact]
    public void cant_climb_onto_that()
    {
        Here<KitchenTable>();
        Execute("climb on table");
        Assert.Contains("You can't climb onto the kitchen table.", ConsoleOut);
    }

    [Fact]
    public void can_climb_into_boat()
    {
        Here<MagicBoat>();
        Execute("climb on boat");
        Assert.Contains("You are now in the magic boat.", ConsoleOut);
    }
}
