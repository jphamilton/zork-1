using Zork1.Library;
using Zork1.Library.Parsing;
using Zork1.Library.Things;

namespace Tests.Parsing;

public class SearchListTests : BaseTestFixture
{
    private Table _table;
    private MoonRock _rock;
    private OpaqueBox _box;
    private HiddenFrog _frog;
    private BlackCloak _cloak;
    private Room _infiniteWhiteRoom;

    public SearchListTests()
    {
        _infiniteWhiteRoom = Get<InfiniteWhiteRoom>();
        _table = Get<Table>();
        _rock = Get<MoonRock>();
        _box = Get<OpaqueBox>();
        _frog = Get<HiddenFrog>();
        _cloak = Get<BlackCloak>();
        Location = _infiniteWhiteRoom;
    }

    [Fact]
    public void should_not_find_concealed()
    {
        _rock.MoveHere();
        _frog.MoveHere();

        var objects = SearchList.All();

        Assert.Contains(_rock, objects);
        Assert.DoesNotContain(_frog, objects);
    }

    [Fact]
    public void should_not_find_obj_in_closed_container()
    {
        _box.MoveHere();
        _rock.Move(_box);
        _box.Open = false;

        var objects = SearchList.All();

        Assert.Contains(_box, objects);
        Assert.DoesNotContain(_rock, objects);
    }

    [Fact]
    public void should_find_obj_in_open_container()
    {
        _box.MoveHere();
        _rock.Move(_box);
        _box.Open = true;

        var objects = SearchList.All();

        Assert.Contains(_box, objects);
        Assert.Contains(_rock, objects);
    }

    [Fact]
    public void should_not_find_obj_in_closed_container_on_surface()
    {
        _table.MoveHere();
        _box.MoveHere();
        _box.Move(_table);
        _rock.Move(_box);
        _box.Open = false;

        var objects = SearchList.All();

        Assert.Contains(_box, objects);
        Assert.DoesNotContain(_rock, objects);
    }

    [Fact]
    public void should_find_obj_in_open_container_on_surface()
    {
        _table.MoveHere();
        _box.MoveHere();
        _box.Move(_table);
        _rock.Move(_box);
        _box.Open = true;

        var objects = SearchList.All();

        Assert.Contains(_box, objects);
        Assert.Contains(_rock, objects);
        Assert.Contains(_table, objects);
    }

    [Fact]
    public void should_include_inventory()
    {
        Player.Add(_box);
        _rock.Move(_box);
        _box.Open = true;

        var objects = SearchList.All();

        Assert.Contains(_box, objects);
        Assert.Contains(_rock, objects);
    }

    [Fact]
    public void should_include_inventory_but_not_stuff_in_closed_containers()
    {
        Player.Add(_box);
        _rock.Move(_box);
        _box.Open = false;

        var objects = SearchList.All();

        Assert.Contains(_box, objects);
        Assert.DoesNotContain(_rock, objects);
    }

    [Fact]
    public void should_not_include_player()
    {
        var objects = SearchList.All();
        Assert.DoesNotContain(player, objects);
    }

    [Fact]
    public void should_not_include_location()
    {
        var objects = SearchList.All();
        Assert.DoesNotContain(_infiniteWhiteRoom, objects);
    }

    [Fact]
    public void should_narrow_with_filter()
    {
        _rock.MoveHere();
        _box.MoveHere();

        var objects = SearchList.All(x => x.Adjectives.Contains("moon"));

        Assert.Contains(_rock, objects);
        Assert.DoesNotContain(_box, objects);
    }

    [Fact]
    public void should_not_go_to_far_into_surface()
    {
        _table.MoveHere();
        _box.MoveHere();
        _rock.MoveHere();
        _cloak.MoveHere();

        _rock.Move(_box);
        _box.Move(_table);
        _cloak.Move(_table);

        _box.Open = true; // contents should not be returned

        var objects = SearchList.Top(_table);

        Assert.DoesNotContain(_rock, objects);
        Assert.Contains(_cloak, objects);
        Assert.Contains(_box, objects);
    }
}
