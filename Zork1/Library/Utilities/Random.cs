using Zork1.Things;

namespace Zork1.Library.Utilities;

public static class Random
{
    // >= min && < max
    public static int Number(int min, int max)
    {
        return System.Random.Shared.Next(min, max);
    }

    // >= 0 && < max
    public static int Number(int max)
    {
        return System.Random.Shared.Next(0, max);
    }

    // min to max inclusive
    public static int Between(int min, int max)
    {
        return System.Random.Shared.Next(min, max + 1);
    }

    public static bool Probability(int chance)
    {
        if (Flags.Lucky)
        {
            return chance > Number(100);
        }

        return chance > Number(300);
    }
}
