using Zork1.Scenic;
using Zork1.Things;

namespace Tests.Handlers;

public class LookOnTests : BaseTestFixture
{
    [Fact]
    public void table()
    {
        var table = Here<KitchenTable>();
        Execute("look on table");
        Assert.Contains("On the table is an elongated brown sack", ConsoleOut);
    }

    [Fact]
    public void not_a_table()
    {
        Execute("look on mailbox");
        Assert.Contains("Look on a small mailbox???", ConsoleOut);
    }

    [Fact]
    public void creature()
    {
        Here<Cyclops>();
        Execute("look on cyclops");
        Assert.Contains("There is nothing special to be seen.", ConsoleOut);
    }
}
