using Zork1.Handlers;

namespace Zork1.Things;

public class Torch : Object
{
    public Torch()
    {
        TakeValue = 14;
        TrophyValue = 6;
        Size = 20;
        Takeable = true;
        Light = true;
        Flame = true;
        On = true;
    }

    public override void Initialize()
    {
        Name = "torch";
        Adjectives = ["torch", "ivory", "treasure", "flaming", "treasure"];
        Initial = "Sitting on the pedestal is a flaming torch, made of ivory.";
        Before<Examine>(() => Print("The torch is burning."));
        Before<Pour>(() =>
        {
            if (Second == this)
            {
                return Print("The water evaporates before it gets close.");
            }

            return false;
        });
        Before<SwitchOff>(() =>
        {
            if (Light)
            {
                return Print("You nearly burn your hand trying to extinguish the flame.");
            }

            return false;
        });
    }
}