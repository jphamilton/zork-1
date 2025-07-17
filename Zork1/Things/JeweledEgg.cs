using Zork1.Handlers;
using Zork1.Library;

namespace Zork1.Things;

public class JeweledEgg : Container
{
    public JeweledEgg()
    {
        Capacity = 6;
        Search = true;
        Takeable = true;
        TakeValue = 5;
        TrophyValue = 5;
        Open = false;
    }

    public override void Initialize()
    {
        Name = "jewel-encrusted egg";
        Adjectives = ["egg", "birds", "encrusted", "jeweled", "treasure"];
        Initial = "In the bird's nest is a large egg encrusted with precious jewels, apparently scavenged by a childless songbird. " +
            "The egg is covered with fine gold inlay, and ornamented in lapis lazuli and mother-of-pearl. " +
            "Unlike most eggs, this one is hinged and closed with a delicate looking clasp. The egg appears extremely fragile.";
        IsHere<GoldenCanary>();

        Before<Poke, Open>(() =>
        {
            var egg = Noun;

            if (egg.Open)
            {
                return Print("The egg is already open.");
            }

            if (Second == null)
            {
                return Print("You have neither the tools nor the expertise.");
            }

            if (Second is PairOfHands)
            {
                return Print("I doubt you could do that without damaging it.");
            }

            if (Second.Weapon || Second.Tool || Verb is Poke)
            {
                Print("The egg is now open, but the clumsiness of your attempt has seriously compromised its esthetic appeal.");
                BreakEgg();
                return true;
            }

            if (Noun.Fight)
            {
                return Print($"Not to say that using the {Second} isn't original too...");
            }

            Print($"The concept of using a {Second} is certainly original.");
            Noun.Fight = true;
            return true;
        });

        Before<Hatch, ClimbOn>(() =>
        {
            Print("There is a noticeable crunch from beneath you, and inspection reveals that the egg is lying open, badly damaged.");
            BreakEgg();
            return true;
        });

        Before<Throw, Poke, Open>(() =>
        {
            if (Verb is Throw)
            {
                Noun.MoveHere();
            }

            Print("Your rather indelicate handling of the egg has caused it some damage, although you have succeeded in opening it.");
            BreakEgg();
            return true;
        });
    }

    public void BreakEgg()
    {
        var (jeweled_egg, golden_canary, broken_canary, broken_egg) = Get<JeweledEgg, GoldenCanary, BrokenCanary, BrokenEgg>();

        if (jeweled_egg.Has(golden_canary))
        {
            //Print($"^{broken_canary.Initial}");
        }
        else
        {
            broken_canary.Remove();
        }

        broken_egg.Move(jeweled_egg.Parent);
        jeweled_egg.Remove();
    }
}
