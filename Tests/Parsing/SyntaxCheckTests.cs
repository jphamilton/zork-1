using Zork1.Handlers;
using Zork1.Library;
using Zork1.Library.Parsing;
using Zork1.Library.Things;
using Zork1.Rooms;
using Zork1.Scenic;
using Zork1.Things;

namespace Tests.Parsing;
public class SyntaxCheckTests : BaseTestFixture
{
    [Fact]
    public void should_resolve_PUT_BEHIND()
    {
        var table = Get<Table>();
        var hat = Get<WhiteHat>();

        var frame = new Frame
        {
            Verb = "put",
            Prep = "behind",
            Objects = [hat],
            IndirectObjects = [table]
        };

        Assert.True(SyntaxCheck.Check(frame, out var grammar));
        Assert.True(grammar.Handler is PutBehind);
    }

    [Fact]
    public void should_resolve_WEAR()
    {
        var cloak = Get<BlackCloak>();

        var frame = new Frame
        {
            Verb = "put",
            Prep = "on",
            Objects = [cloak],
        };

        Assert.True(SyntaxCheck.Check(frame, out var grammar));
        Assert.True(grammar.Handler is Wear);
    }

    [Fact]
    public void should_resolve_SWITCH_OFF()
    {
        var torch = Get<FlickeringTorch>();

        var frame = new Frame
        {
            Verb = "put",
            Prep = "out",
            Objects = [torch],
        };

        Assert.True(SyntaxCheck.Check(frame, out var grammar));
        Assert.True(grammar.Handler is SwitchOff);
    }

    [Fact]
    public void should_resolve_PUT_UNDER()
    {
        var cloak = Here<BlackCloak>();
        var table = Here<Table>();

        var frame = Lexer.Tokenize("hide cloak under table", null);

        Assert.True(SyntaxCheck.Check(frame, out var grammar));
        Assert.True(grammar.Handler is PutUnder);
    }

    [Fact]
    public void should_resolve_DROP()
    {
        var cloak = Here<BlackCloak>();

        var frame = Lexer.Tokenize("place down cloak", null);
        Assert.True(SyntaxCheck.Check(frame, out var grammar));
        Assert.True(grammar.Handler is Drop);
    }

    [Fact]
    public void should_resolve_PUT_ON()
    {
        var cloak = Get<BlackCloak>();
        var table = Get<Table>();

        var frame = new Frame
        {
            Verb = "put",
            Objects = [cloak],
            Prep = "on",
            IndirectObjects = [table],
        };

        Assert.True(SyntaxCheck.Check(frame, out var grammar));
        Assert.True(grammar.Handler is PutOn);
    }

    [Fact]
    public void should_resolve_INSERT()
    {
        var cloak = Get<BlackCloak>();
        var box = Get<TransparentBox>();

        var frame = new Frame
        {
            Verb = "put",
            Objects = [cloak],
            Prep = "in",
            IndirectObjects = [box],
        };

        Assert.True(SyntaxCheck.Check(frame, out var grammar));
        Assert.True(grammar.Handler is Insert);
    }

    [Fact]
    public void should_handle_partial_resolution_without_prep()
    {
        var cloak = Player.Add<BlackCloak>();

        var frame = Lexer.Tokenize("put", null);

        Assert.False(SyntaxCheck.Check(frame, out var grammar));
        Assert.Equal("What do you want to put?", frame.Error);
        Assert.True(frame.Orphan);

        frame = Lexer.Tokenize("on cloak", frame);

        Assert.False(frame.Orphan);
        Assert.Contains(cloak, frame.Objects);
        Assert.Equal("put", frame.Verb);
        Assert.Equal("on", frame.Prep);
    }

    [Fact]
    public void should_use_verb_entered_1()
    {
        var cloak = Player.Add<BlackCloak>();

        // hide is replace by put
        var frame = Lexer.Tokenize("hide", null);

        Assert.False(SyntaxCheck.Check(frame, out var grammar));

        Assert.Equal("What do you want to hide?", frame.Error);
    }

    [Fact]
    public void should_not_recognize_sentence()
    {
        var mailbox = Here<Mailbox>();

        // blast has no object clauses
        var frame = new Frame
        {
            Verb = "blast",
            Objects = [mailbox],
            IndirectObjects = [],
        };

        SyntaxCheck.Check(frame, out var grammar);

        Assert.Equal(Messages.DontRecognizeSentence, frame.Error);
    }

    [Fact]
    public void should_not_recognize_sentence_ind()
    {
        var mailbox = Here<Mailbox>();
        var torch = Here<FlickeringTorch>();

        // indirect object is extra
        var frame = new Frame
        {
            Verb = "take",
            Objects = [mailbox],
            Prep = "up",
            IndirectObjects = [torch],
        };

        SyntaxCheck.Check(frame, out var grammar);

        Assert.Equal(Messages.DontRecognizeSentence, frame.Error);
    }

    [Fact]
    public void should_handle_directions()
    {
        var frame = Lexer.Tokenize("go north", null);
        SyntaxCheck.Check(frame, out var grammar);
        Assert.True(grammar.Handler is North);

        frame = Lexer.Tokenize("n", null);
        SyntaxCheck.Check(frame, out grammar);
        Assert.True(grammar.Handler is North);

        frame = Lexer.Tokenize("down", null);
        SyntaxCheck.Check(frame, out grammar);
        Assert.True(grammar.Handler is Down);

        frame = Lexer.Tokenize("out", null);
        SyntaxCheck.Check(frame, out grammar);
        Assert.True(grammar.Handler is Exit);
    }

    [Fact]
    public void should_handle_directions_IN()
    {
        Location = Get<BehindHouse>();
        var window = Get<KitchenWindow>();
        window.Open = true;

        var frame = Lexer.Tokenize("go in", null);
        SyntaxCheck.Check(frame, out Grammar grammar);
        
    }

    [Fact]
    public void should_also_handle_directions_IN()
    {
        var frame = Lexer.Tokenize("in", null);
        SyntaxCheck.Check(frame, out Grammar grammar);
        Assert.True(grammar.Handler is Enter);
    }

    [Fact]
    public void go_in_BUG()
    {
        var frame = Lexer.Tokenize("go in");
        SyntaxCheck.Check(frame, out Grammar grammar);
        
    }

    [Fact]
    public void put_leaflet_BUG()
    {
        Inv<Advertisement>();
        Get<Mailbox>().Open = true;

        var frame = Lexer.Tokenize("put leaflet");
        SyntaxCheck.Check(frame, out Grammar grammar);
        Assert.Equal($"What do you want to put the leaflet in?", frame.Error);
    }
}
