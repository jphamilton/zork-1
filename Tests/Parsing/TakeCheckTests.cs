using Zork1.Library.Parsing;
using Zork1.Rooms;
using Zork1.Scenic;
using Zork1.Things;

namespace Tests.Parsing;
public class TakeCheckTests : BaseTestFixture
{
    [Fact]
    public void should_not_take_mailbox()
    {
        var frame = GetFrame("open mailbox");

        var success = TakeCheck.Check(frame);

        Assert.True(success);
        Assert.Empty(player.Children);
    }

    [Fact]
    public void should_not_try_to_take_mailbox()
    {
        var frame = GetFrame("take mailbox");

        var success = TakeCheck.Check(frame);

        Assert.True(success);
        Assert.Empty(player.Children);
    }


    [Fact]
    public void should_implicit_take_leaflet()
    {
        // expost the leaflet
        Get<Mailbox>().Open = true;

        var frame = GetFrame("read leaflet");

        var success = TakeCheck.Check(frame);

        Assert.True(success);
        Assert.Contains("(Taken)", ConsoleOut);
        Assert.Contains(Get<Advertisement>(), player.Children);
    }

    [Fact]
    public void also_here_but_not_HAVE()
    {
        Here<Torch>();

        // burn indirect has HAVE
        var frame = GetFrame("burn mailbox with torch");

        var success = TakeCheck.Check(frame);

        Assert.False(success);
        Assert.Contains("You don't have the torch.", frame.Error);
    }

    [Fact]
    public void turn_off_torch()
    {
        var torch = Here<Torch>();

        // torch is on ground and takeable
        var frame = GetFrame("turn off torch");

        var success = TakeCheck.Check(frame);

        Assert.True(success);
        Assert.Contains("(Taken)", ConsoleOut);
        Assert.True(player.Has(torch));
    }

    [Fact]
    public void here_but_not_HAVE_but_cant_TAKE_a_house()
    {
        var frame = GetFrame("turn off house");

        var success = TakeCheck.Check(frame);
        Assert.False(success);

        Assert.Contains("You don't have the white house.", frame.Error);
    }

    [Fact]
    public void GWIM_and_implicit_take()
    {
        var flashlight = Here<Flashlight>();

        var frame = GetFrame("turn on");
        var success = TakeCheck.Check(frame);

        Assert.True(success);
        Assert.Contains($"(the Radio Shack flashlight)", ConsoleOut);
        Assert.Contains($"(Taken)", ConsoleOut);
        Assert.True(player.Has(flashlight));
    }

    [Fact]
    public void BUG_you_dont_have_the_you()
    {
        var chasm = Get<EastOfChasm>();
        chasm.Light = true;

        var frame = Lexer.Tokenize("throw me off chasm");
        SyntaxCheck.Check(frame, out var grammar);
        Snarf.Objects(frame, grammar);
        TakeCheck.Check(frame);
        Assert.NotEqual("You don't have the you.", frame.Error);
        Assert.Contains(Get<Me>(), frame.Objects);

    }

    [Fact]
    public void should_take_CARRIED()
    {
        var (sack, knife) = Get<BrownSack, NastyKnife>();
        knife.Move(sack);
        
        sack.Move(player);
        sack.Open = true;

        var frame = Execute("take knife");
        Assert.Equal(knife.Parent, player);
    }

    private Frame GetFrame(string input)
    {
        var frame = Lexer.Tokenize(input);
        Assert.True(SyntaxCheck.Check(frame, out Grammar grammar));
        Assert.True(Snarf.Objects(frame, grammar));
        Assert.True(Many.Check(frame, grammar));

        return frame;
    }
}
