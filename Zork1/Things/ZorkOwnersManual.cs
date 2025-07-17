namespace Zork1.Things;

public class ZorkOwnersManual : Object
{
    public ZorkOwnersManual()
    {
        Readable = true;
        Takeable = true;
        //https://github.com/the-infocom-files/zork1/issues/63
        Flammable = true;
    }

    public override void Initialize()
    {
        Name = "ZORK owner's manual";
        Adjectives = ["zork", "manual", "owners", "small", "piece", "paper"];
        Initial = "Loosely attached to a wall is a small piece of paper.";
        Text = "Congratulations!^^You are the privileged owner of ZORK I: The Great Underground Empire, a self-contained " +
            "and self-maintaining universe. If used and maintained in accordance with normal operating practices " +
            "for small universes, ZORK will provide many months of trouble-free operation.";
    }
}