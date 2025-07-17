using Zork1.Handlers;

namespace Zork1.Things;

public class BloodyAxe : Object
{
    public BloodyAxe()
    {
        TryTake = true;
        Scenery = true;
        Size = 25;
        Weapon = true;
        Takeable = true;
    }

    public override void Initialize()
    {
        Name = "bloody axe";
        Adjectives = ["axe", "ax", "bloody"];
        Before<Take>(() =>
        {
            var troll = Get<Thief>();
            return troll.TryTakeWeapon(this);
        });
    }
}