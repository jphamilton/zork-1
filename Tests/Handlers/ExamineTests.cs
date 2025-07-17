using Zork1.Rooms;
using Zork1.Scenic;
using Zork1.Things;

namespace Tests.Handlers;

public class ExamineTests : BaseTestFixture
{
    [Fact]
    public void should_read()
    {
        Inv<Advertisement>();
        Execute("examine leaflet");
        Assert.Contains("WELCOME TO ZORK", ConsoleOut);
    }

    [Fact]
    public void should_look_in()
    {
        Location = Get<BehindHouse>();
        var window = Get<KitchenWindow>();
        window.Visited = true;
        Execute("examine window");
        Assert.Contains("You can see what appears to be a kitchen.", ConsoleOut);
    }

    [Fact]
    public void nothing_special()
    {
        var rock = Here<MoonRock>();
        Execute("examine rock");
        Assert.Contains("There's nothing special about the moon rock.", ConsoleOut);
    }
}
