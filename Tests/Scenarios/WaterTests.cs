using Zork1.Rooms;
using Zork1.Things;

namespace Tests.Scenarios;

public class WaterTests : BaseTestFixture
{
    public WaterTests()
    {
        Location = Get<Shore>();
    }

    [Fact]
    public void bottle_is_already_full()
    {

        var bottle = Inv<GlassBottle>();
        bottle.Open = true;

        Execute("fill bottle with water");

        Assert.Contains("The bottle is already full.", ConsoleOut);
    }

    [Fact]
    public void bottle_is_not_here()
    {
        // checking that parser will not allow things to
        // get this far

        var bottle = Get<GlassBottle>();
        bottle.Open = true;

        Execute("fill bottle with water");

        Assert.Contains("You can't see any bottle here!", ConsoleOut);
    }

    [Fact]
    public void should_not_fill_brown_sack()
    {
        var sack = Inv<BrownSack>();
        sack.Open = true;

        Execute("fill sack with water");

        Assert.Contains($"The water leaks out of the {sack} and evaporates immediately.", ConsoleOut);
    }

    [Fact]
    public void bottle_is_closed()
    {

        var bottle = Inv<GlassBottle>();
        bottle.Open = false;

        Execute("fill bottle with water");

        Assert.Contains("The bottle is closed.", ConsoleOut);
    }

    [Fact]
    public void should_fill_bottle()
    {
        var bottle = Inv<GlassBottle>();
        bottle.Open = true;
        bottle.Children.Clear();

        Execute("fill bottle with water");

        Assert.Contains("The bottle is now full of water.", ConsoleOut);
    }

    [Fact]
    public void on_taking_water()
    {
        var bottle = Inv<GlassBottle>();
        bottle.Open = true;

        Execute("take water");

        Assert.Contains("It's in the bottle. Perhaps you should take that instead.", ConsoleOut);
    }

    [Fact]
    public void on_taking_water_when_bottle_is_not_here()
    {
        Execute("take water");
        Assert.Contains("The water slips through your fingers.", ConsoleOut);
    }

    [Fact]
    public void on_throwing_water()
    {
        var bottle = Inv<GlassBottle>();
        bottle.Open = true;

        Execute("throw water");

        Assert.Contains("The water splashes on the walls and evaporates immediately.", ConsoleOut);
    }

    [Fact]
    public void pouring_water_in_a_boat()
    {
        var boat = Here<MagicBoat>();
        player.Move(boat);

        var bottle = Inv<GlassBottle>();
        bottle.Open = true;

        Execute("pour water");

        Assert.Contains($"There is now a puddle in the bottom of the {boat}.", ConsoleOut);
    }

    [Fact]
    public void can_still_give_water_to_cyclops()
    {
        Location = Get<CyclopsRoom>();
        Location.Light = true;

        var cyclops = Get<Cyclops>();
        cyclops.Cyclowrath = -1;

        var bottle = Inv<GlassBottle>();
        bottle.Open = true;

        Execute("give water to cyclops");

        Assert.Contains($"The cyclops takes the bottle", ConsoleOut);
    }

    [Fact]
    public void no_swimming()
    {
        Execute("enter water");

        Assert.Contains("You can't swim in the dungeon.", ConsoleOut);
    }

    [Fact]
    public void shaking_open_bottle()
    {
        var bottle = Inv<GlassBottle>();
        bottle.Open = true;

        Execute("shake bottle");

        Assert.Contains($"The water spills to the floor and evaporates immediately.", ConsoleOut);
    }

    [Fact]
    public void shaking_open_bottle_in_a_boat()
    {
        var boat = Here<MagicBoat>();
        player.Move(boat);

        var bottle = Inv<GlassBottle>();
        bottle.Open = true;

        Execute("shake bottle");

        Assert.Contains($"There is now a puddle in the bottom of the {boat}.", ConsoleOut);
    }
}
