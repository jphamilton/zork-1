using Zork1.Library.Things;
using Zork1.Rooms;
using Zork1.Scenic;
using Zork1.Things;

namespace Tests.Scenarios;
public class ChuteTests : BaseTestFixture
{
    [Fact]
    public void you_cant_climb_up_a_chute()
    {
        Location = Get<Cellar>();
        Location.Light = true;

        Execute("climb up chute");
        Assert.Contains("You try to ascend the ramp, but it is impossible, and you slide back down.", ConsoleOut);
    }

    [Fact]
    public void should_throw_myself_down_the_chute()
    {
        Location = Get<InfiniteWhiteRoom>();
        Location.WithScenery<Chute>();

        var f = Execute("go in chute");

        Assert.Contains("You tumble down the slide....", ConsoleOut);
        Assert.True(Location is Cellar);
    }

    [Fact]
    public void should_also_throw_myself_down_the_chute()
    {
        Location = Get<InfiniteWhiteRoom>();
        Location.WithScenery<Chute>();

        var f = Execute("enter chute");

        Assert.Contains("You tumble down the slide....", ConsoleOut);
        Assert.True(Location is Cellar);
    }

    [Fact]
    public void can_chuck_stuff_down_the_chute_into_the_cellar()
    {
        Location = Get<SlideRoom>();
        Location.Light = true;
        var leaflet = Inv<Advertisement>();

        Assert.Equal(player, leaflet.Parent);

        var f = Execute("put leaflet in chute");

        Assert.Contains($"The {leaflet} falls into the slide and is gone.", ConsoleOut);
        
        Assert.Equal(Get<Cellar>(), leaflet.Parent);
    }

    [Fact]
    public void lots_of_effort_put_into_water_for_this_game()
    {
        Location = Get<SlideRoom>();
        Location.Light = true;

        var bottle = Inv<GlassBottle>();
        bottle.Open = true;

        var water = Get<QuantityOfWater>();

        Assert.Equal(water.Parent, bottle);

        var f = Execute("put water in chute");

        Assert.Contains($"The {water} falls into the slide and is gone.", ConsoleOut);

        // see, the water evaporates when you chuck it in a chute
        Assert.Null(water.Parent);
    }
}
