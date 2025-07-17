namespace Zork1.Things;

public class SkeletonKey : Object
{
    public SkeletonKey()
    {
        Size = 10;
        Takeable = true;
        Tool = true;
    }

    public override void Initialize()
    {
        Name = "skeleton key";
        Adjectives = ["key", "skeleton"];
    }
}
