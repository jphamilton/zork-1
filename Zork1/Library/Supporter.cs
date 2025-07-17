namespace Zork1.Library;

public abstract class Supporter : HasContents
{
    public Supporter()
    {
        Container = true;
        Open = true;
        Scenery = true;
        Supporter = true;
    }
}