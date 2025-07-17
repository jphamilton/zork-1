using Zork1.Library;
using Zork1.Things;

namespace Tests.Handlers;

public class CutTests : BaseTestFixture
{
    [Fact]
    public void cut_as_attack()
    {
        Inv<NastyKnife>();
        Here<DarkSpirit>();
        Execute("cut spirit with knife");
        Assert.Contains("The dark spirit is unphased by your attempts at violence.", ConsoleOut);
    }

    [Fact]
    public void cut_with_what()
    {
        Here<DarkSpirit>();
        Prompt.FakeInput("knife");
        Execute("cut spirit");
        Assert.Contains("What do you want to cut the dark spirit with?", ConsoleOut);
        Assert.Contains("You can't see any knife here!", ConsoleOut);
    }

    [Fact]
    public void cut_flammable()
    {
        Inv<NastyKnife>();
        var leaflet = Here<Advertisement>();
        Execute("cut leaflet");
        Assert.Contains("(the nasty knife)", ConsoleOut);
        Assert.Contains("Your skillful nasty knifesmanship slices the leaflet into innumerable slivers which blow away.", ConsoleOut);
        Assert.Null(leaflet.Parent);
    }

    [Fact]
    public void cutting_edge()
    {
        Inv<Screwdriver>();
        Here<Advertisement>();
        Execute("cut leaflet with screwdriver");
        Assert.Contains("The ~cutting edge~ of a screwdriver is hardly adequate.", ConsoleOut);
    }

    [Fact]
    public void strange_concept()
    {
        Inv<NastyKnife>();
        Inv<Screwdriver>();
        Execute("cut screwdriver");
        Assert.Contains("Strange concept, cutting the screwdriver....", ConsoleOut);
    }
}
