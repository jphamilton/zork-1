using Zork1.Library.Parsing;
using Zork1.Scenic;
using Zork1.Things;

namespace Tests.Parsing;
public class ManyCheckTests : BaseTestFixture
{
    [Fact]
    public void should_fail_MANY_indirect_objects()
    {
        var frame = new Frame
        {
            Verb = "put",
            Objects = [Inv<Advertisement>()],
            Prep = "in",
            IndirectObjects = [Get<Mailbox>(), Get<WhiteHouse>()],
        };

        SyntaxCheck.Check(frame, out Grammar grammar);
        Assert.False(Many.Check(frame, grammar));
        Assert.Equal($"You can't use multiple indirect objects with \"{frame.Verb}\".", frame.Error);
    }

    [Fact]
    public void should_fail_MANY_direct_objects()
    {
        var frame = new Frame
        {
            Verb = "count",
            Objects = [Get<Blessings>(), Here<PileOfLeaves>()],
        };

        SyntaxCheck.Check(frame, out Grammar grammar);
        Assert.False(Many.Check(frame, grammar));
        Assert.Equal($"You can't use multiple direct objects with \"{frame.Verb}\".", frame.Error);
    }

    [Fact]
    public void should_pass_with_syntax_that_allows_MANY()
    {
        var frame = new Frame
        {
            Verb = "drop",
            Objects = [Get<OpaqueBox>(), Here<HiddenFrog>()],
        };

        SyntaxCheck.Check(frame, out Grammar grammar);
        Assert.True(Many.Check(frame, grammar));
    }
}
