using Zork1.Library;
using Zork1.Library.Things;

namespace Zork1.Handlers;

public class Inventory : Sub
{
    public static int Count => SearchList.All(Player.Instance).Count;

    public override bool Handler(Object noun, Object second)
    {
        if (player.Children.Count == 0)
        {
            return Print("You are empty-handed.");
        }

        Print("You are carrying:");
        return Print(Describer.DisplayList(player));
    }
}
