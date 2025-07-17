namespace Zork1.Things;

public class TourGuidebook : Object
{
    public TourGuidebook()
    {
        Readable = true;
        Takeable = true;
        Flammable = true;
    }

    public override void Initialize()
    {
        Name = "tour guidebook";
        Adjectives = ["guide", "book", "books", "guidebook", "tour"];
        Initial = "Some guidebooks entitled ~Flood Control Dam #3~ are on the reception desk.";
        Text = "~  Flood Control Dam #3^^FCD#3 was constructed in year 783 of the Great Underground Empire to harness the mighty Frigid River. " +
            "This work was supported by a grant of 37 million zorkmids from your omnipotent local tyrant Lord Dimwit Flathead the Excessive. " +
            "This impressive structure is composed of 370,000 cubic feet of concrete, is 256 feet tall at the center, and 193 feet wide at the top. " +
            "The lake created behind the dam has a volume of 1.7 billion cubic feet, an area of 12 million square feet, and a shore line of 36 thousand feet." +
            "^^We will now point out some of the more interesting features of FCD#3 as we conduct you on a guided tour of the facilities:^" +
            "    1) You start your tour here in the Dam Lobby. You will notice on your right that....";
    }
}