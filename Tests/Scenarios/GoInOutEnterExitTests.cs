using Zork1.Rooms;
using Zork1.Scenic;
using Zork1.Things;

namespace Tests.Scenarios;

public class GoInOutEnterExitTests : BaseTestFixture
{
    public GoInOutEnterExitTests()
    {
        Location = Get<BehindHouse>();
    }

    [Fact]
    public void should_go_in_and_go_out()
    {
        var window = Get<KitchenWindow>();
        Execute("open window");

        Execute("go in");
        Assert.True(Location is Kitchen);

        Execute("go out");
        Assert.True(Location is BehindHouse);
    }

    [Fact]
    public void should_in_and_out()
    {
        var window = Get<KitchenWindow>();
        Execute("open window");

        Execute("in");
        Assert.True(Location is Kitchen);

        Execute("out");
        Assert.True(Location is BehindHouse);
    }

    [Fact]
    public void should_go_in_and_out_of_window()
    {
        var window = Get<KitchenWindow>();
        window.Open = true;
        window.Visited = true;

        Execute("go in window");
        Assert.True(Location is Kitchen);

        Execute("go out window");
        Assert.True(Location is BehindHouse);
    }

    [Fact]
    public void should_enter_and_exit()
    {
        var window = Get<KitchenWindow>();
        window.Open = true;
        window.Visited = true;

        Execute("enter");
        Assert.True(Location is Kitchen);

        Execute("exit");
        Assert.True(Location is BehindHouse);
    }

    [Fact]
    public void should_enter_window_and_exit_window()
    {
        var window = Get<KitchenWindow>();
        window.Open = true;
        window.Visited = true;

        Execute("enter window");
        Assert.True(Location is Kitchen);

        var f = Execute("exit window");
        
        Assert.True(Location is BehindHouse);
    }

    [Fact]
    public void should_enter_boat()
    {
        Location = Get<InfiniteWhiteRoom>();
        var boat = Here<MagicBoat>();

        Execute("enter boat");
        
        Assert.Equal(player.Parent, boat);
        Assert.Contains("You are now in the magic boat.", ConsoleOut);
    }

    [Fact]
    public void should_go_up_chimney()
    {
        Location = Get<Studio>();
        var lamp = Inv<BrassLantern>();
        lamp.Light = true;

        Execute("go up chimney");

        Assert.Equal(player.Parent, Get<Kitchen>());

    }
}
