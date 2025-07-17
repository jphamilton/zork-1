using Zork1.Handlers;

namespace Zork1.Things;

public class BlackBook : Object
{
    private const string FiveSixtyNine = "Beside page 569, there is only one other page with any legible printing on it. " +
        "Most of it is unreadable, but the subject seems to be the banishment of evil. Apparently, certain noises, lights, " +
        "and prayers are efficacious in this regard.";

    public BlackBook()
    {
        Turnable = true;
        Readable = true;
        Takeable = true;
        Flammable = true;
        Size = 10;
    }

    public override void Initialize()
    {
        Name = "black book";
        Adjectives = ["book", "prayer", "page", "books", "large", "black"];
        Initial = "On the altar is a large black book, open to page 569.";
        Text = "Commandment #12592^^Oh ye who go about saying unto each:  ~Hello sailor~:^" +
            "Dost thou know the magnitude of thy sin before the gods?^Yea, verily, thou shalt be ground between two stones." +
            "^Shall the angry gods cast thy body into the whirlpool?^Surely, thy eye shall be put out with a sharp stick!^" +
            "Even unto the ends of the earth shalt thou wander and^Unto the land of the dead shalt thou be sent at last.^" +
            "Surely thou shalt repent of thy cunning.";

        Before<Open>(() => Print("The book is already open to page 569."));
        Before<Close>(() => Print("As hard as you try, the book cannot be closed."));
        Before<MoveWith>(() => Print(FiveSixtyNine));

        Before<Read>(() =>
        {
            if (Second is Number number && number.Value != 569)
            {
                return Print(FiveSixtyNine);
            }

            return false;
        });

        Before<Burn>(() =>
        {
            Remove();
            return JigsUp("A booming voice says ~Wrong, cretin!~ and you notice that you have turned into a pile of dust. How, I can't imagine.");
        });
    }
}
