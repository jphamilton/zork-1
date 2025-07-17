using Zork1.Library;

namespace Zork1.Handlers;

public class Poke : Sub
{
    public Poke()
    {
        PreSub = PrePoke;
    }

    public bool PrePoke(Object noun, Object second)
    {
        if (second?.Weapon == true)
        {
            return false;
        }

        var weapon = second == null ? "your bare hands" : $"a {second}";
        return Print($"Trying to destroy the {noun} with {weapon} is futile.");
    }

    public override bool Handler(Object noun, Object second)
    {
        if (noun.Animate)
        {
            return Redirect.To<Attack>(noun);
        }

        return Print("Nice try.");
    }
}