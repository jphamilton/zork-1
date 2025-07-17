using Zork1.Things;

namespace Tests.Handlers;

public class DropTests : BaseTestFixture
{
    [Fact]
    public void should_drop()
    {
        Location = Get<InfiniteWhiteRoom>();
        var box = Inv<OpaqueBox>();
        Execute("drop box");
        Assert.Contains("Dropped.", ConsoleOut);
        Assert.Equal(box.Parent, Location);
    }

    [Fact]
    public void should_not_drop()
    {
        Location = Get<InfiniteWhiteRoom>();
        var key = Here<SkeletonKey>();
        Execute("drop key");
        Assert.Contains("You don't have the skeleton key.", ConsoleOut);
        Assert.Equal(Location, key.Parent);
    }

    [Fact]
    public void should_drop_in_the_boat()
    {
        Location = Get<InfiniteWhiteRoom>();
        var boat = Here<MagicBoat>();
        var key = Inv<SkeletonKey>();
        var lamp = Inv<BrassLantern>();

        player.Move(boat);

        Execute("drop all");
        
        Assert.Equal(key.Parent, boat);
        Assert.Equal(lamp.Parent, boat);
    }
}
