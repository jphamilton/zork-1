using Zork1.Rooms;
using Zork1.Things;

namespace Tests.Handlers;

public class EatOrDrinkTests : BaseTestFixture
{
    [Fact]
    public void cant_drink_a_sandwich()
    {
        Inv<Lunch>();
        Execute("drink lunch");
        Assert.Contains("How can you drink that?", ConsoleOut);
    }

    [Fact]
    public void can_eat_a_sandwich()
    {
        Inv<Lunch>();
        Execute("eat lunch");
        Assert.Contains("Thank you very much. It really hit the spot.", ConsoleOut);
    }

    [Fact]
    public void can_drink_water()
    {
        var bottle = Inv<GlassBottle>();
        bottle.Open = true;
        Execute("drink water");
        Assert.Contains("Thank you very much. I was rather thirsty (from all this talking, probably).", ConsoleOut);
        Assert.Empty(bottle.Children);
    }

    [Fact]
    public void should_open_bottle_first()
    {
        var bottle = Inv<GlassBottle>();
        bottle.Open = false;
        Execute("drink water");
        Assert.Contains("You'll have to open the glass bottle first.", ConsoleOut);
        Assert.NotEmpty(bottle.Children);
    }

    [Fact]
    public void should_be_holding()
    {
        var bottle = Here<GlassBottle>();
        bottle.Open = true;
        Execute("drink water");
        Assert.Contains("You have to be holding the glass bottle first.", ConsoleOut);
        Assert.NotEmpty(bottle.Children);
    }

    [Fact]
    public void eating_a_screwdriver()
    {
        var screwdriver = Inv<Screwdriver>();
        Execute("eat screwdriver");
        Assert.Contains("I don't think that the screwdriver would agree with you.", ConsoleOut);
        Assert.NotNull(screwdriver.Children);
    }

    [Fact]
    public void drinking_from_a_river()
    {
        Location = Get<Shore>();
        Execute("drink water");
        Assert.Contains("Thank you very much. I was rather thirsty (from all this talking, probably).", ConsoleOut);
    }
}
