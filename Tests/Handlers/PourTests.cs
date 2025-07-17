using Zork1.Things;

namespace Tests.Handlers;

public class PourTests : BaseTestFixture
{
	[Fact]
	public void extinguish()
	{
		var bottle = Inv<GlassBottle>();
		bottle.Open = true;
		var torch = Here<FlickeringTorch>();
		Execute("pour water on torch");
		Assert.Contains("The flickering torch is extinguished.", ConsoleOut);
		Assert.False(torch.Light);
		Assert.False(torch.Flame);
		Assert.Empty(bottle.Children);
    }

	[Fact]
	public void needless_wetting()
	{
        var bottle = Inv<GlassBottle>();
        bottle.Open = true;
        Execute("pour water on mailbox");
        Assert.Contains("The water spills over the small mailbox, to the floor, and evaporates.", ConsoleOut);
		Assert.Empty(bottle.Children);
    }

    [Fact]
	public void redirect_to_insert()
	{
		var tube = Inv<Tube>();
		tube.Open = true;
		var punctured = Here<PuncturedBoat>();
		var plastic = Get<PileOfPlastic>();
		Execute("pour gunk on boat");
        Assert.Contains("The boat is repaired", ConsoleOut);
        Assert.Equal(plastic.Parent, Location);
	}

	[Fact]
	public void cant_pour()
	{
		Inv<Wrench>();
		Execute("pour wrench on mailbox");
		Assert.Contains("You can't pour that", ConsoleOut);
	}
}