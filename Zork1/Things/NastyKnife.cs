using Zork1.Handlers;
using Zork1.Scenic;

namespace Zork1.Things;

public class NastyKnife : Object
{
    public NastyKnife()
    {
        TryTake = true;
        Takeable = true;
        Weapon = true;
    }

    public override void Initialize()
    {
        Name = "nasty knife";
        Adjectives = ["knife", "nasty", "knives", "blade", "unrusted"];
        Initial = "On a table is a nasty-looking knife.";

        Before<Take>(() =>
        {
            Get<AtticTable>().Scenery = false;
            return false;
        });
    }
}
