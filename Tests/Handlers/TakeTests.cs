using Zork1.Rooms;
using Zork1.Things;

namespace Tests.Handlers;

public class TakeTests : BaseTestFixture
{
    [Fact]
    public void should_take_all()
    {
        Location = Get<Kitchen>();
        var frame = Execute("take all");
        Assert.True(player.Has(Get<GlassBottle>()));
        Assert.True(player.Has(Get<BrownSack>()));
    }

    [Fact]
    public void already_wearing()
    {
        var hat = Inv<RedHat>();
        hat.Worn = true;
        Execute("take hat");
        Assert.Contains("You are already wearing it.", ConsoleOut);
    }

    [Fact]
    public void already_have()
    {
        var hat = Inv<RedHat>();
        Execute("take hat");
        Assert.Contains("You already have that!", ConsoleOut);
    }

    [Fact]
    public void take_from_ground()
    {
        var hat = Here<RedHat>();
        Execute("take hat from ground");
        Assert.Contains("Taken.", ConsoleOut);
    }

    [Fact]
    public void take_from_parent()
    {
        var hat = Here<RedHat>();
        Execute("take hat from mailbox");
        Assert.Contains("The red hat isn't in the small mailbox.", ConsoleOut);
    }

    [Fact]
    public void youre_inside_of_it()
    {
        var boat = Here<MagicBoat>();
        player.Move(boat);
        Execute("take boat");
        Assert.Contains("You're inside of it!", ConsoleOut);
    }

    [Fact]
    public void vanilla_take()
    {
        var leaflet = Here<Advertisement>();
        Execute("take leaflet");
        Assert.Equal(leaflet.Parent, player);
    }

    [Fact]
    public void take_all_in_a_boat()
    {
        Location = Get<InfiniteWhiteRoom>();
        var boat = Here<MagicBoat>();
        player.Move(boat);
        var (leaflet, box) = Get<Advertisement, OpaqueBox>();
        leaflet.Move(boat);
        box.Move(boat);

        Execute("take all");

        Assert.Equal(leaflet.Parent, player);
        Assert.Equal(box.Parent, player);
    }
}
