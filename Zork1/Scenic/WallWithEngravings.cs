namespace Zork1.Scenic;

public class WallWithEngravings : Wall
{
    public WallWithEngravings()
    {
        Readable = true;
        Sacred = true;
    }

    public override void Initialize()
    {
        Name = "wall with engravings";
        Adjectives = ["wall", "walls", "engravings", "inscription", "old", "ancient"];
        Description = "There are old engravings on the walls here.";
        Text = "The engravings were incised in the living rock of the cave wall by an unknown hand. " +
            "They depict, in symbolic form, the beliefs of the ancient Zorkers. Skillfully interwoven " +
            "with the bas reliefs are excerpts illustrating the major religious tenets of that time. " +
            "Unfortunately, a later age seems to have considered them blasphemous and just as skillfully " +
            "excised them.";
    }
}