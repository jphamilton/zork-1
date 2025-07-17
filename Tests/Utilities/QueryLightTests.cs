using System.Diagnostics;
using Zork1.Library;
using Zork1.Library.Things;
using Zork1.Rooms;
using Zork1.Things;

namespace Tests.Utilities;
public class QueryLightTests : BaseTestFixture
{
    public QueryLightTests()
    {
        Location = Get<ImposingCave>();
        
    }

    [Fact]
    public void should_be_really_dark()
    {
        Assert.False(Query.Light(Location));
    }

    [Fact]
    public void should_have_light()
    {
        Inv<FlickeringTorch>();
        Assert.True(Query.Light(Location));
    }

    [Fact]
    public void should_not_have_light_with_closed_container()
    {
        // torch is in a transparent container
        var box = Inv<OpaqueBox>();
        Get<FlickeringTorch>().Move(box);
        box.Open = false;
        
        Assert.False(Query.Light(Location));
    }

    [Fact]
    public void unless_its_transparent()
    {
        var box = Inv<TransparentBox>();
        Get<FlickeringTorch>().Move(box);
        box.Open = false;

        Assert.True(Query.Light(Location));
    }

    [Fact]
    public void tables_will_totally_work_too()
    {
        var table = Here<Table>();
        Get<FlickeringTorch>().Move(table);

        Assert.True(Query.Light(Location));
    }

    [Fact]
    public void containers_on_tables_will_also_totally_work()
    {
        var table = Here<Table>();
        var box = Get<TransparentBox>();
        Get<FlickeringTorch>().Move(box);
        box.Open = false;
        box.Move(table);

        Assert.True(Query.Light(Location));
    }

    [Fact]
    public void and_of_course_a_room_that_already_has_light()
    {
        Location = Get<WestOfHouse>();
        Assert.True(Query.Light(Location));
    }

    [Fact]
    public void should_query_from_boat_location()
    {
        Location = Get<DamBase>();
        var boat = Here<MagicBoat>();
        player.Move(boat);
        Assert.True(Query.Light(Location));
    }
}
