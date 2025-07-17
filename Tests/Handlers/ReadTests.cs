using Zork1.Rooms;
using Zork1.Scenic;
using Zork1.Things;

namespace Tests.Handlers;

public class ReadTests : BaseTestFixture
{
	[Fact]
	public void cant_read_in_dark()
	{
		Location = Get<ImposingCave>();
		Inv<Advertisement>();
		Execute("read leaflet");
		Assert.Contains("It is impossible to read in the dark.", ConsoleOut);
	}

	[Fact]
	public void can_read_page()
	{
		Location = Get<Altar>();
		Location.Light = true;
		Execute("read page 569");
		Assert.Contains("Commandment #12592", ConsoleOut);
	}

	[Fact]
	public void if_you_can_read_a_wrench()
	{
		Inv<Wrench>();
		Execute("read wrench");
		Assert.Contains("How does one read a wrench?", ConsoleOut);
	}

	[Fact]
	public void should_implicit_take()
	{
		Get<Mailbox>().Open = true;
		var leaflet = Get<Advertisement>();
		Execute("read leaflet");
		Assert.True(player.Has(leaflet));
	}

	[Fact]
	public void should_read()
	{
        Get<Mailbox>().Open = true;
        var leaflet = Get<Advertisement>();
        Execute("read leaflet");
        Assert.Contains("WELCOME TO ZORK!", ConsoleOut);
	}
}