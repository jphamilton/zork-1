using Zork1.Handlers;
using Zork1.Library;
using Zork1.Library.Things;

namespace Zork1.Things;

public class Tube : Container
{
    public Tube()
    {
        Size = 5;
        Capacity = 7;
        Readable = true;
        Takeable = true;
    }

    public override void Initialize()
    {
        Name = "tube";
        Adjectives = ["tube", "tooth", "paste"];
        Description = "There is an object which looks like a tube of toothpaste here.";
        Text = "---> Frobozz Magic Gunk Company <---^            All-Purpose Gunk";
        IsHere<ViscousMaterial>();
        Before<Insert>(() =>
        {
            if (Second == this)
            {
                return Print("The tube refuses to accept anything.");
            }

            return false;
        });

        Before<Squeeze>(() =>
        {
            var viscous_material = Get<ViscousMaterial>();
            if (Noun == this && Open && Has(viscous_material))
            {
                Player.Add(viscous_material);
                return Print("The viscous material oozes into your hand.");
            }

            if (Open)
            {
                return Print("The tube is apparently empty.");
            }

            return Print("The tube is closed.");
        });
    }
}
