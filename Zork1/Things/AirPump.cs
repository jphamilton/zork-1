namespace Zork1.Things;

public class AirPump : Object
{
    public AirPump()
    {
        Takeable = true;
        Tool = true;
    }

    public override void Initialize()
    {
        Name = "hand-held air pump";
        Adjectives = ["pump", "air", "tool", "tools", "small", "hand", "held"];
    }
}
