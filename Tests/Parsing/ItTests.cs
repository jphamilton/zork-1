using Zork1.Library.Parsing;
using Zork1.Scenic;

namespace Tests.Parsing;
public class ItTests : BaseTestFixture
{
    [Fact]
    public void should_handle_it()
    {
        // LastNoun is set to mailbox when game starts
        var x = Lexer.Tokenize("open it", null);
        Assert.Contains(Get<Mailbox>(), x.Objects);
    }
}
