namespace Zork1.Handlers;

public class Drink : FineDining
{
    public override bool Handler(Object noun, Object second)
    {
        return EatOrDrink(noun, true);
    }
}
