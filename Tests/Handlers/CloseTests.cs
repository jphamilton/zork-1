using Zork1.Library;
using Zork1.Scenic;

namespace Tests.Handlers;

public class CloseTests : BaseTestFixture
{
    [Fact]
    public void cant_close_that()
    {
        Here<MoonRock>();
        Execute("close rock");
        Assert.Contains("You must tell me how to do that to a moon rock.", ConsoleOut);
    }

    [Fact]
    public void should_hide_light_source()
    {
        Location = Get<ImposingCave>();

        var flashlight = Here<Flashlight>();
        var box = Inv<OpaqueBox>();
        
        box.Open = true;
        flashlight.On = true;
        flashlight.Light = true;
        flashlight.Move(box);

        var lit = Query.Light();
        Assert.True(lit);

        Execute("close box");

        Assert.Contains("Closed.", ConsoleOut);
        Assert.Contains("It is now pitch black.", ConsoleOut);
        Assert.False(box.Open);

        lit = Query.Light();
        Assert.False(lit);
    }

    [Fact]
    public void should_still_have_light()
    {
        Location = Get<ImposingCave>();

        var flashlight = Here<Flashlight>();
        var box = Inv<TransparentBox>();

        box.Open = true;
        flashlight.On = true;
        flashlight.Light = true;
        flashlight.Move(box);

        var lit = Query.Light();
        Assert.True(lit);

        Execute("close box");

        Assert.Contains("Closed.", ConsoleOut);
        Assert.False(box.Open);

        lit = Query.Light();
        Assert.True(lit);
    }

    [Fact]
    public void already_closed()
    {
        var box = Inv<OpaqueBox>();
        box.Open = false;
        Execute("close box");
        Assert.Contains("It is already closed.", ConsoleOut);
    }

    [Fact]
    public void should_open_door()
    {
        var cave = Get<ImposingCave>();
        cave.Light = true;

        Location = cave;

        var door = Get<OakDoor>();
        door.Open = true;

        cave.Children.Add(door);

        Execute("close door");

        Assert.Contains("The oak door is now closed.", ConsoleOut);
    }

    [Fact]
    public void cant_close_tables()
    {
        Here<KitchenTable>();
        Execute("close table");
        Assert.Contains("You cannot close that.", ConsoleOut);
    }
}
