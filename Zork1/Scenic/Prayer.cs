namespace Zork1.Scenic;

public class Prayer : Object
{
    public Prayer()
    {
        Sacred = true;
        Scenery = true;
        Readable = true;
    }

    public override void Initialize()
    {
        Name = "prayer";
        Adjectives = ["prayer", "ancient", "old", "inscription"];
        Text = "The prayer is inscribed in an ancient script, rarely used today. " +
            "It seems to be a philippic against small insects, absent-mindedness, and the " +
            "picking up and dropping of small objects. The final verse consigns trespassers to " +
            "the land of the dead. All evidence indicates that the beliefs of the ancient Zorkers were obscure.";
    }
}