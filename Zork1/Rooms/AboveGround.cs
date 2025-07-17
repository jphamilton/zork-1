using Zork1.Library;

namespace Zork1.Rooms;

/// <summary>
/// Base class for all outdoor rooms on dry land
/// </summary>
public abstract class AboveGround : Room
{
    protected AboveGround()
    {
        Light = true;
        DryLand = true;
        Sacred = true;
    }
}
