namespace Zork1.Library.Extensions;

public static class ByteExtensions
{
    public static bool Has(this byte flags, byte BIT)
    {
        return (flags & 1 << BIT) != 0;
    }
}
