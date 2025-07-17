using Zork1.Library;
using Zork1.Library.Extensions;

namespace Zork1.Handlers;

public class LookIn : Sub
{
    public override bool Handler(Object noun, Object second)
    {
        if (noun is Door)
        {
            if (noun.Open)
            {
                return Print($"The {noun} is open, but I can't tell what's beyond it.");
            }
            else
            {
                return Print($"The {noun} is closed.");
            }
        }

        if (noun.Animate)
        {
            return Print("There is nothing special to be seen.");
        }

        if (noun is Container container)
        {
            if (container.CanSeeContents)
            {
                var list = Describer.GetContents(container);
                var contents = list.Count > 0 ? $"contains {list.Join("and")}" : "is empty";
                return Print($"The {container} {contents}.");
            }

            return Print($"The {container} is closed.");
        }

        return Print($"You can't look inside a {noun}.");
    }
}