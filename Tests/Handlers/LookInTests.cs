using Zork1.Rooms;
using Zork1.Scenic;
using Zork1.Things;

namespace Tests.Handlers;

public class LookInTests : BaseTestFixture
{
    [Fact]
    public void open_doors()
    {
        Location = Get<GratingRoom>();
        Location.Light = true;
        var grate = Get<Grating>();
        grate.Open = true;
        grate.Concealed = false;
        grate.Locked = false;
        Execute("look in grate");
        Assert.Contains("The grating is open, but I can't tell what's beyond it.", ConsoleOut);
    }

    [Fact]
    public void closed_doors()
    {
        Location = Get<GratingRoom>();
        Location.Light = true;
        var grate = Get<Grating>();
        grate.Open = false;
        grate.Concealed = false;
        grate.Locked = false;
        Execute("look in grate");
        Assert.Contains("The grating is closed.", ConsoleOut);
    }

    [Fact]
    public void creatures()
    {
        var cyclops = Get<Cyclops>();
        cyclops.MoveHere();
        Execute("look in cyclops");
        Assert.Contains("There is nothing special to be seen.", ConsoleOut);
    }

    [Fact]
    public void closed_container()
    {
        var mailbox = Get<Mailbox>();
        Execute("look in mailbox");
        Assert.Contains($"The {mailbox} is closed.", ConsoleOut);
    }

    [Fact]
    public void open_container()
    {
        var mailbox = Get<Mailbox>();
        mailbox.Open = true;
        var manual = Get<ZorkOwnersManual>();
        manual.Move(mailbox);
        var label = Get<TanLabel>();
        label.Move(mailbox);
        Execute("look in mailbox");
        Assert.Contains("The small mailbox contains a leaflet, a ZORK owner's manual and a tan label.", ConsoleOut);
    }

    [Fact]
    public void empty_container()
    {
        var mailbox = Get<Mailbox>();
        mailbox.Open = true;
        var leaflet = Get<Advertisement>();
        leaflet.Remove();
        Execute("look in mailbox");
        Assert.Contains("The small mailbox is empty.", ConsoleOut);
    }

    [Fact]
    public void cant_do_it()
    {
        Inv<Wrench>();
        Execute("look in wrench");
        Assert.Contains("You can't look inside a wrench.", ConsoleOut);
    }
}
