namespace Zork1.Things;

public class AncientMap : Object
{
    public AncientMap()
    {
        Concealed = true;
        Readable = true;
        Size = 2;
        Takeable = true;
    }

    public override void Initialize()
    {
        Name = "ancient map";
        Adjectives = ["map", "antique", "parchment", "old", "ancient"];
        Initial = "In the trophy case is an ancient parchment which appears to be a map.";
        Text = "The map shows a forest with three clearings. The largest clearing contains a house. " +
        "Three paths leave the large clearing. One of these paths, leading southwest, is marked ~To Stone Barrow~.";
    }
}
