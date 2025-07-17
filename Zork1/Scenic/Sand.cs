using Zork1.Handlers;
using Zork1.Library;
using Zork1.Things;

namespace Zork1.Scenic;

public class Sand : Object
{
    private int BeachDig { get; set; }
    private readonly List<string> BeachDigs = [
        "You seem to be digging a hole here.",
        "The hole is getting deeper, but that's about it.",
        "You are surrounded by a wall of sand on all sides."
    ];

    public Sand()
    {
        Scenery = true;
    }

    public override void Initialize()
    {
        Name = "sand";
        Adjectives = ["sand"];
        Before<Dig>(() =>
        {
            if (BeachDig < 0)
            {
                return false;
            }

            BeachDig++;

            var scarab = Objects.Get<Scarab>();

            if (BeachDig > 3)
            {
                // related to https://github.com/the-infocom-files/zork1/issues/46
                BeachDig = -1;

                if (Location.Has(scarab))
                {
                    scarab.Concealed = true;
                    return JigsUp("The hole collapses, smothering you.");
                }

                return false;
            }

            if (BeachDig == 3)
            {
                if (!scarab.Concealed)
                {
                    return false;
                }

                Print("You can see a scarab here in the sand.");
                SetLast.Object(scarab);
                scarab.Concealed = false;
                return true;
            }

            Print(BeachDigs[BeachDig - 1]);
            return true;
        });
    }
}
