using Zork1.Library;
using Zork1.Things;

namespace Tests.Handlers;

public class DiveTests : BaseTestFixture
{
    [Fact]
    public void cant_jump_over_house()
    {
        Execute("jump over house");
        Assert.Contains("That would be a good trick.", ConsoleOut);
    }

    [Fact]
    public void cant_jump_over_creatures()
    {
        Here<Troll>();
        Execute("jump over troll");
        Assert.Contains("The troll is too big to jump over.", ConsoleOut);
    }

    [Fact]
    public void should_redirect_to_jump()
    {
        Execute("jump over mailbox");
        Assert.Contains(Tables.Hop.List, ConsoleOut.Contains);
    }
}
