using Zork1.Scenic;
using Zork1.Things;

namespace Tests.Handlers;

public class InsertTests : BaseTestFixture
{
    [Fact]
    public void not_open()
    {
        var mailbox = Get<Mailbox>();
        var leaflet = Inv<Advertisement>();
        Execute("insert leaflet into mailbox");
        Assert.Contains($"The {mailbox} isn't open.", ConsoleOut);
    }

    [Fact]
    public void cant_do_that()
    {
        var sword = Here<Sword>();
        var leaflet = Inv<Advertisement>();
        Execute("insert leaflet into sword");
        Assert.Contains($"You can't do that.", ConsoleOut);
    }

    [Fact]
    public void boatsert()
    {
        var boat = Here<MagicBoat>();
        var leaflet = Inv<Advertisement>();
        Execute("insert leaflet into boat");
        Assert.Contains($"Done.", ConsoleOut);
    }

    [Fact]
    public void selfsert()
    {
        var box =  Inv<OpaqueBox>();
        box.Open = true;
        Execute("insert box into box");
        Assert.Contains($"How can you do that?", ConsoleOut);
    }

    [Fact]
    public void already_inserted()
    {
        var box = Inv<OpaqueBox>();
        var rock = Get<MoonRock>();
        box.Open = true;
        rock.Move(box);
        Execute("insert rock into box");
        Assert.Contains($"The {rock} is already in the {box}.", ConsoleOut);
    }

    [Fact]
    public void no_room()
    {
        var mailbox = Get<Mailbox>();
        mailbox.Open = true;
        var rock = Inv<MoonRock>();
        rock.Size = 50;
        Execute("insert rock into mailbox");
        Assert.Contains($"There's no room.", ConsoleOut);
    }

    [Fact]
    public void no_have()
    {
        var mailbox = Get<Mailbox>();
        mailbox.Open = true;
        var rock = Here<MoonRock>();
        Execute("insert rock into mailbox");
        Assert.Contains($"You don't have the {rock}.", ConsoleOut);
    }
}
