using Zork1.Library;

namespace Zork1.Handlers;

public class SprayOn : Sub
{
    public override bool Handler(Object noun, Object second)
    {
        return Redirect.To<Squeeze>(noun, second);
    }
}

public class SprayWith : Sub
{
    public override bool Handler(Object noun, Object second)
    {
        return Redirect.To<SprayOn>(noun, second);
    }
}

public class Squeeze : Sub
{
    public override bool Handler(Object noun, Object second)
    {
        if (noun != null && noun.Animate)
        {
            return Print($"The {noun} does not understand this.");
        }

        return Print("How singularly useless.");
    }
}