using Zork1.Library;
using Zork1.Things;

namespace Tests.Handlers;

public class BurnTests : BaseTestFixture
{
    [Fact]
    public void presub_should_prevent()
    {
        Inv<Advertisement>();
        Inv<Screwdriver>();
        Execute("burn leaflet with screwdriver");
        Assert.Contains("With a screwdriver??!?", ConsoleOut);
    }

    [Fact]
    public void should_not_live()
    {
        Inv<Torch>();
        Inv<Advertisement>();

        Assert.Equal(0, State.Deaths);

        Execute("burn leaflet with torch");
        
        Assert.Equal(1, State.Deaths);

        Assert.Contains("You have died", ConsoleOut);
    }

    [Fact]
    public void should_burn()
    {
        Inv<Torch>();
        var leaflet = Here<Advertisement>();

        Execute("burn leaflet with torch");

        Assert.Contains("The leaflet catches fire and is consumed.", ConsoleOut);
        Assert.Null(leaflet.Parent);
    }
}
