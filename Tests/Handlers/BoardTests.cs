using Zork1.Scenic;
using Zork1.Things;

namespace Tests.Handlers;

public class BoardTests : BaseTestFixture
{
    [Fact]
    public void should_enter_boat()
    {
        var boat = Here<MagicBoat>();
        Execute("enter boat");
        Assert.Equal(player.Parent, boat);
        Assert.Contains("You are now in the magic boat.", ConsoleOut);
    }

    [Fact]
    public void should_also_enter_boat()
    {
        var boat = Here<MagicBoat>();
        Execute("board boat");
        Assert.Equal(player.Parent, boat);
        Assert.Contains("You are now in the magic boat.", ConsoleOut);
    }

    [Fact]
    public void should_be_on_the_ground()
    {
        var table = Here<KitchenTable>();
        var boat = Here<MagicBoat>();
        boat.Move(table);
        Execute("board boat");
        Assert.NotEqual(player.Parent, boat);
        Assert.Contains("The magic boat must be on the ground to be boarded.", ConsoleOut);
    }

    [Fact]
    public void should_already_be_in_it()
    {
        var boat = Here<MagicBoat>();
        player.Move(boat);
        Execute("board boat");
        Assert.Equal(player.Parent, boat);
        Assert.Contains("You are already in the magic boat!", ConsoleOut);
    }

    [Fact]
    public void should_not_boat()
    {
        var location = Location;
        Execute("board mailbox");
        Assert.Contains("You have a theory on how to board a small mailbox, perhaps?", ConsoleOut);
        Assert.Equal(player.Parent, location);
    }
}
