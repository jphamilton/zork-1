using Zork1.Rooms;
using Zork1.Things;

namespace Tests.Handlers;

public class DisembarkTests : BaseTestFixture
{
    [Fact]
    public void not_in_it()
    {
        Here<MagicBoat>();
        Execute("get out of boat");
        Assert.Contains("You're not in that!", ConsoleOut);

        Execute("leave boat");
        Assert.Contains("You're not in that!", ConsoleOut);

        Execute("exit boat");
        Assert.Contains("You're not in that!", ConsoleOut);
    }

    [Fact]
    public void leave_on_dry_land()
    {
        var boat = Here<MagicBoat>();
        player.Parent = boat;
        Execute("leave boat");
        Assert.Contains("You are on your own feet again.", ConsoleOut);
        Assert.NotEqual(player.Parent, boat);
    }

    [Fact]
    public void would_be_fatal()
    {
        var river = Get<River4>();
        Location = river;
        var boat = Get<MagicBoat>();
        boat.Move(river);
        player.Move(boat);

        Execute("leave boat");

        Assert.Contains("You realize that getting out here would be fatal.", ConsoleOut);
        Assert.Equal(player.Parent, boat);
    }
}
