namespace Zork1.Handlers;

public class Eat : FineDining
{
    public override bool Handler(Object noun, Object second)
    {
        return EatOrDrink(noun, false);
    }
}
