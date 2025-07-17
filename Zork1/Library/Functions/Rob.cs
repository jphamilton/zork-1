using Zork1.Things;

namespace Zork1.Library.Functions;

public static class Rob
{
    public static bool Run(Object target, Object destination, int probability = 0)
    {
        bool robbed = false;

        foreach (var obj in target.Items)
        {
            if (obj.TrophyValue > 0 && !obj.Sacred && (probability == 0 || probability > Random.Number(100)))
            {
                if (probability == 0 || probability > Random.Number(100))
                {
                    obj.Move(destination);

                    if (destination is Thief)
                    {
                        obj.Concealed = true;
                    }

                    robbed = true;
                }
            }
        }

        return robbed;
    }
}
