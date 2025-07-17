using Zork1.Handlers;
using Zork1.Library;
using Zork1.Library.Parsing;
using Zork1.Library.Things;
using Zork1.Rooms;
using Zork1.Scenic;
using Zork1.Things;

namespace Tests.Parsing;
public class SnarfObjectsTests : BaseTestFixture
{
    // NEED MORE TESTS - supply objects missing from command

    [Fact]
    public void TOO_DARK_SEE()
    {
        // do an actual move, so Lit gets set in the game code
        MovePlayer.To<ImposingCave>();
        Assert.Equal(Location, Get<ImposingCave>());
        Assert.False(State.Lit);

        Here<Flashlight>();

        var (frame, grammar) = GetSyntax("take all");

        Snarf.Objects(frame, grammar);

        Assert.Equal(Messages.TooDarkToSee, frame.Error);
    }

    [Fact]
    public void inventory_accessible_when_TOO_DARK_SEE()
    {
        //...because one should have the ability to turn on a light

        // do an actual move, so Lit gets set in the game code
        MovePlayer.To<ImposingCave>();
        Assert.Equal(Location, Get<ImposingCave>());
        Assert.False(State.Lit);

        Inv<Flashlight>();

        var (frame, grammar) = GetSyntax("turn on flashlight");

        Snarf.Objects(frame, grammar);

        Assert.NotEqual(Messages.TooDarkToSee, frame.Error);
    }

    [Fact]
    public void drop_all_should_work_when_TOO_DARK_SEE()
    {
        // do an actual move, so Lit gets set in the game code
        MovePlayer.To<ImposingCave>();
        Assert.Equal(Location, Get<ImposingCave>());
        Assert.False(State.Lit);

        Inv<Flashlight>();
        Here<OpaqueBox>();
        Here<WhiteHat>();

        var (frame, grammar) = GetSyntax("drop all");

        Snarf.Objects(frame, grammar);

        Assert.NotEqual(Messages.TooDarkToSee, frame.Error);
    }

    [Fact]
    public void SEARCHBIT_true_will_get_included()
    {
        var cabinet = Here<ChinaCabinet>();
        var cloak = Get<BlackCloak>();
        cloak.Move(cabinet);

        var (frame, grammar) = GetSyntax("take all");

        Snarf.Objects(frame, grammar);

        Assert.Contains(cloak, frame.Objects);
    }

    [Fact]
    public void SEARCHBIT_false_will_not_be_included()
    {
        Location = Get<InfiniteWhiteRoom>();
        var cabinet = Here<ChinaCabinet>();
        var cloak = Get<BlackCloak>();
        cloak.Move(cabinet);
        cabinet.Search = false;

        var (frame, grammar) = GetSyntax("take all");

        Snarf.Objects(frame, grammar);

        Assert.DoesNotContain(cloak, frame.Objects);
    }

    [Fact]
    public void ALL_drop_only_held()
    {
        // have
        var cloak = Inv<BlackCloak>();
        var torch = Inv<FlickeringTorch>();
        // don't have
        var mailbox = Get<Mailbox>();
        var leaflet = Get<Advertisement>();

        // expose leaflet to the elements
        mailbox.Open = true;

        var (frame, grammar) = GetSyntax("drop all");

        Snarf.Objects(frame, grammar);

        Assert.DoesNotContain(mailbox, frame.Objects);
        Assert.DoesNotContain(leaflet, frame.Objects);

        Assert.Contains(cloak, frame.Objects);
        Assert.Contains(torch, frame.Objects);
    }

    [Fact]
    public void EXCEPT_with_valid_command()
    {
        // except only with valid objects
        var box = Here<OpaqueBox>();
        var cloak = Here<BlackCloak>();
        var torch = Here<FlickeringTorch>();

        var (frame, grammar) = GetSyntax("take box cloak torch except torch");

        Snarf.Objects(frame, grammar);

        Assert.Contains(box, frame.Objects);
        Assert.Contains(cloak, frame.Objects);
        Assert.DoesNotContain(torch, frame.Objects);
        Assert.False(frame.Orphan);
        Assert.Null(frame.Error);
    }

    [Fact]
    public void EXCEPT_returns_nothing()
    {
        var (frame, grammar) = GetSyntax("take mailbox except mailbox");

        Snarf.Objects(frame, grammar);

        Assert.Equal(Messages.NotClear, frame.Error);
    }

    [Fact]
    public void EXCEPT_with_ALL_cancels_out_everything()
    {
        // take these
        Here<Mailbox>();
        Here<Advertisement>();

        // ignore these
        Inv<BlackCloak>();
        Inv<FlickeringTorch>();

        var (frame, grammar) = GetSyntax("take all except mailbox leaflet");

        Snarf.Objects(frame, grammar);
        Assert.Equal(Messages.NotClear, frame.Error);
    }

    [Fact]
    public void EXCEPT_with_unresolved_objects()
    {
        // except with unresolved
        Inv<RedHat>();
        Inv<WhiteHat>();
        Inv<BlackHat>();

        var (frame, grammar) = GetSyntax("drop all except hat");

        Snarf.Objects(frame, grammar);

        Assert.Contains("Which do you mean", frame.Error);
    }

    [Fact]
    public void EXCEPT_with_object_not_here()
    {
        // Zork seems to ignore except objects that are not present
        var red = Inv<RedHat>();
        var white = Inv<WhiteHat>();
        var black = Inv<BlackHat>();

        // torch not here, but other things are
        var (frame, grammar) = GetSyntax("drop all except torch");

        Snarf.Objects(frame, grammar);

        Assert.Contains(red, frame.Objects);
        Assert.Contains(white, frame.Objects);
        Assert.Contains(black, frame.Objects);
    }

    [Fact]
    public void RESOLVE_from_CARRIED()
    {
        var red = Inv<RedHat>();
        Here<BlackHat>();
        Here<WhiteHat>();

        // should favor carried (red hat)
        var (frame, grammar) = GetSyntax("put on hat");

        Snarf.Objects(frame, grammar);

        Assert.Empty(frame.UnresolvedObjects);
        Assert.Contains(red, frame.Objects);
    }

    [Fact]
    public void RESOLVE_indirect_using_GWIMBIT()
    {
        Here<Advertisement>();
        var torch = Here<FlickeringTorch>();

        var (frame, grammar) = GetSyntax("burn leaflet");
        // (with flickering torch)

        Snarf.Objects(frame, grammar);
        Assert.Contains(torch, frame.IndirectObjects);
    }

    [Fact]
    public void RESOLVE_direct_using_GWIMBIT()
    {
        var leaflet = Inv<Advertisement>();
        Here<FlickeringTorch>();
        Here<RedHat>();

        var (frame, grammar) = GetSyntax("drop");
        // (the leaflet)

        Snarf.Objects(frame, grammar);
        Assert.Contains(leaflet, frame.Objects);
    }

    [Fact]
    public void RESOLVE_from_HELD()
    {
        var red = Inv<RedHat>();
        Here<BlackHat>();
        Here<WhiteHat>();

        var (frame, grammar) = GetSyntax("drop hat");
        Assert.True(grammar.Handler is Drop);

        Snarf.Objects(frame, grammar);

        Assert.Empty(frame.UnresolvedObjects);
        Assert.Contains(red, frame.Objects);
    }

    [Fact]
    public void RESOLVE_does_not_work_with_more_than_one_match()
    {
        // more than one object will be matched, so it should fail
        Inv<Advertisement>();
        Inv<FlickeringTorch>();
        Here<RedHat>();

        var (frame, grammar) = GetSyntax("drop");

        Snarf.Objects(frame, grammar);
        Assert.Empty(frame.Objects);
        Assert.Equal("What do you want to drop?", frame.Error);
    }

    [Fact]
    public void ALL_from_ONGROUND_EXCEPT_from_ONGROUND()
    {
        // take these
        var mailbox = Get<Mailbox>();
        var leaflet = Here<Advertisement>();

        // ignore these
        var cloak = Inv<BlackCloak>();
        var torch = Inv<FlickeringTorch>();

        var (frame, grammar) = GetSyntax("take all except mailbox");

        Snarf.Objects(frame, grammar);

        // already have these
        Assert.DoesNotContain(cloak, frame.Objects);
        Assert.DoesNotContain(torch, frame.Objects);
        Assert.DoesNotContain(mailbox, frame.Objects);

        Assert.Contains(leaflet, frame.Objects);
    }

    [Fact]
    public void ALL_from_ONGROUND()
    {
        // take these
        var mailbox = Get<Mailbox>();
        var leaflet = Here<Advertisement>();

        // ignore these
        var cloak = Inv<BlackCloak>();
        var torch = Inv<FlickeringTorch>();

        var (frame, grammar) = GetSyntax("take all");

        Snarf.Objects(frame, grammar);

        // already have these
        Assert.DoesNotContain(cloak, frame.Objects);
        Assert.DoesNotContain(torch, frame.Objects);

        Assert.Contains(mailbox, frame.Objects);
        Assert.Contains(leaflet, frame.Objects);
    }

    [Fact]
    public void ALL_from_surface()
    {
        Location = Get<Kitchen>();

        // take these
        var sack = Get<BrownSack>();
        var bottle = Get<GlassBottle>();

        var (frame, grammar) = GetSyntax("take all");

        Snarf.Objects(frame, grammar);

        Assert.Equal(2, frame.Objects.Count);
        Assert.Contains(sack, frame.Objects);
        Assert.Contains(bottle, frame.Objects);
    }

    [Fact]
    public void ORPHAN_with_adverb()
    {
        var torch = Here<FlickeringTorch>();
        var mailbox = Here<Mailbox>();

        var frame = Lexer.Tokenize("burn", null);

        SyntaxCheck.Check(frame, out var grammar);
        Assert.True(grammar.Handler is Burn);

        Snarf.Objects(frame, grammar);

        Assert.Equal("What do you want to burn?", frame.Error);

        frame = Lexer.Tokenize("down mailbox with torch", frame);

        Assert.False(frame.Orphan);
        Assert.Equal("burn down", frame.Verb);
        Assert.Contains(mailbox, frame.Objects);
        Assert.Contains(torch, frame.IndirectObjects);
    }

    [Fact]
    public void ORPHAN_indirect()
    {
        var mailbox = Here<Mailbox>();

        var frame = Lexer.Tokenize("burn down mailbox", null);

        SyntaxCheck.Check(frame, out var grammar);

        Snarf.Objects(frame, grammar);

        Assert.Equal($"What do you want to burn down the {mailbox} with?", frame.Error);
        Assert.True(frame.Orphan);

        frame = Lexer.Tokenize("torch", frame);

        Assert.Equal("burn down", frame.Verb);
        Assert.Contains(mailbox, frame.Objects);
        Assert.False(frame.Orphan); // should be false because there is no recovery from here
        Assert.Equal(Messages.CantSeeThatHere("torch"), frame.Error);
    }

    [Fact]
    public void ORPHAN_indirect_multiple()
    {
        // burn, down mailbox - unfulfilled partial
        Here<Mailbox>();

        var frame = Lexer.Tokenize("burn", null);

        SyntaxCheck.Check(frame, out var grammar);
        Snarf.Objects(frame, grammar);

        Assert.Equal("What do you want to burn?", frame.Error);
        Assert.True(frame.Orphan);

        frame = Lexer.Tokenize("mailbox", frame);
        SyntaxCheck.Check(frame, out grammar);
        Snarf.Objects(frame, grammar);

        Assert.Equal("What do you want to burn the small mailbox with?", frame.Error);
    }

    [Fact]
    public void ORPHAN_with_prep()
    {
        var frame = Lexer.Tokenize("put in", null);

        SyntaxCheck.Check(frame, out var grammar);
        Assert.True(grammar.Handler is Insert);
        Snarf.Objects(frame, grammar);
        Assert.Equal("What do you want to put?", frame.Error);
    }

    [Fact]
    public void should_find_CARRIED()
    {
        var box = Inv<OpaqueBox>();
        box.Open = true;

        var cloak = Get<BlackCloak>();
        cloak.Move(box);

        var (frame, grammar) = GetSyntax("drop cloak");

        Snarf.Objects(frame, grammar);

        Assert.Contains(cloak, frame.Objects);
    }

    [Fact]
    public void should_use_verb_entered_2()
    {
        Player.Add<BlackCloak>();

        // ignite is burn
        var frame = Lexer.Tokenize("ignite down", null);

        SyntaxCheck.Check(frame, out var grammar);
        Snarf.Objects(frame, grammar);

        Assert.Equal("What do you want to ignite down?", frame.Error);
    }

    [Fact]
    public void should_use_verb_entered_3()
    {
        Player.Add<BlackCloak>();

        // ignite is burn
        var frame = Lexer.Tokenize("ignite down cloak", null);

        SyntaxCheck.Check(frame, out var grammar);
        Snarf.Objects(frame, grammar);

        Assert.Equal("What do you want to ignite down the black cloak with?", frame.Error);
    }

    [Fact]
    public void BUG_which_water()
    {
        // we are next to water and we have
        // a bottle full of water...two waters!
        Location = Get<Shore>();
        var water = Get<Water>();
        var bottle = Inv<GlassBottle>();
        bottle.Open = true;
        var frame = Lexer.Tokenize("fill bottle with water");
        SyntaxCheck.Check(frame, out var grammar);
        Snarf.Objects(frame, grammar);
        Assert.Contains(water, frame.IndirectObjects);
    }

    [Fact]
    public void BUG_another_which_water()
    {
        // scenery was not being set at ONGROUND
        Location = Get<Shore>();
        var bottle = Inv<GlassBottle>();
        var shovel = Inv<Shovel>();
        bottle.Open = true;
        var frame = Lexer.Tokenize("dig in water with shovel"); // dig syntax wants first object to be INROOM, ONGROUND
        SyntaxCheck.Check(frame, out var grammar);
        Snarf.Objects(frame, grammar);
        Assert.DoesNotContain("Which do you mean", frame.Error);
        Assert.Contains(Objects.Get<Water>(), frame.Objects);
    }

    [Fact]
    public void BUG_all_should_not_take_concealed()
    {
        var stiletto = Here<Stiletto>();
        stiletto.Concealed = true;
        var frame = Lexer.Tokenize("take all"); // dig syntax wants first object to be INROOM, ONGROUND
        SyntaxCheck.Check(frame, out var grammar);
        Snarf.Objects(frame, grammar);
        Assert.DoesNotContain(stiletto, frame.Objects);
        Assert.Contains(Get<Mailbox>(), frame.Objects);
    }

    private static (Frame, Grammar) GetSyntax(string command)
    {
        var frame = Lexer.Tokenize(command, null);
        Assert.False(frame.IsError);
        Assert.True(SyntaxCheck.Check(frame, out var grammar));
        return (frame, grammar);
    }
}