using Zork1.Library;
using Zork1.Things;

namespace Zork1.Handlers;

public class Back() : DefaultSub("Sorry, my memory is poor. Please give a direction.");
public class Banish() : DefaultSub("What a bizarre concept!");
public class BlowIn() : ShortSub((noun, _) => Redirect.To<Inflate>(noun, Get<BlastOfAir>()));
public class BlowUp() : DefaultSub("You can't blast anything by using words.");
public class Brush() : DefaultSub("If you wish, but heaven only knows why.");
public class Bug() : DefaultSub("Bug? Not in a flawless program like this! (Cough, cough).");
public class Chant() : DefaultSub("The incantation echoes back faintly, but nothing else happens.");

public class Command() : ShortSub((noun, _) =>
{
    if (noun.Animate)
    {
        return Print($"The {noun} pays no attention.");
    }

    return Print("You cannot talk to that!");
});

public class Count() : ShortSub((noun, second) =>
{
    if (noun is Blessings)
    {
        return Print("Well, for one, you are playing Zork...");
    }

    return Print("You have lost your mind.");
});

public class Cross() : DefaultSub("You can't cross that!");

public class Curse() : ShortSub((noun, _) =>
{
    if (noun != null)
    {
        if (noun.Animate)
        {
            return Print("Insults of this nature won't help you.");
        }

        return Print("What a loony!");
    }

    return Print("Such language in a high-class establishment like this!");
});

public class Deflate() : DefaultSub("Come on, now!");

public class Dig() : ShortSub((noun, second) =>
{
    second = second is PairOfHands ? null : second;

    if (second is null)
    {
        return Print($"Digging with your hands is slow and tedious.");
    }
    else if (second.Tool)
    {
        return Print($"Digging with the {second} is slow and tedious.");
    }

    return Print($"Digging with a {second} is silly.");
});

public class Disenchant() : DefaultSub("Nothing happens.");
public class DrinkFrom() : DefaultSub("How peculiar!");
public class Echo() : DefaultSub("echo echo ...");
public class Enchant() : DefaultSub("Nothing happens.");
public class Fix() : DefaultSub("This has no effect.");
public class Follow() : DefaultSub("You're nuts!");
public class Frobozz() : DefaultSub("The FROBOZZ Corporation created, owns, and operates this dungeon.");
public class Grease() : DefaultSub("You probably put spinach in your gas tank, too.");
public class Inflate() : DefaultSub("How can you inflate that?");
public class Jump() : ShortSub((_, __) => Print(Tables.Hop.Pick()));
public class Kick() : ShortSub((_, __) => Print(Tables.HackHack("Kicking the ")));
public class Hatch() : DefaultSub("Bizarre!");
public class Kiss() : DefaultSub("I'd sooner kiss a pig.");

public class Knock() : ShortSub((noun, _) =>
{
    if (noun.Door)
    {
        return Print("Nobody's home.");
    }

    return Print($"Why knock on a {noun}?");
});

public class Launch() : ShortSub((noun, second) =>
{
    if (noun.Vehicle)
    {
        return Print($"You can't launch that by saying ~launch~!");
    }

    return Print("That's pretty weird.");
});

public class LeanOn() : DefaultSub("Getting tired?");
public class Listen() : ShortSub((noun, _) => Print($"The {noun} makes no sound."));
public class Lock() : DefaultSub("It doesn't seem to work.");
public class LookBehind() : ShortSub((noun, _) => Print($"There is nothing behind the {noun}."));
public class LookUnder() : DefaultSub("There is nothing but dust there.");
public class Lower() : ShortSub((noun, _) => Print(Tables.HackHack("Playing in this way with the")));
public class Make() : DefaultSub("You can't do that.");
public class Melt() : ShortSub((noun, _) => Print($"It's not clear that a {noun} can be melted."));
public class Molest() : DefaultSub("What a (ahem!) strange idea.");
public class Mumble() : DefaultSub("You'll have to speak up if you expect me to hear you!");
public class Pick() : DefaultSub("You can't pick that.");
public class Play() : DefaultSub("That's silly!");
public class Plugh() : DefaultSub("A hollow voice says ~Fool.~");
public class Push() : ShortSub((_, __) => Print(Tables.HackHack("Pushing the")));
public class PutBehind() : DefaultSub("That hiding place is too obvious.");
public class PutUnder() : DefaultSub("You can't do that.");
public class Raise() : ShortSub((_, __) => Redirect.To<Lower>());
public class Repent() : DefaultSub("It could very well be too late!");
public class Ring() : DefaultSub("How, exactly, can you ring that?");
public class Search() : DefaultSub("You find nothing unusual.");
public class Slide() : DefaultSub("You can't push things to that.");
public class Smell() : ShortSub((noun, _) => Print($"It smells like a {noun}."));
public class Spin() : DefaultSub("You can't spin that!");
public class Stay() : DefaultSub("You will be lost without me!");
public class TieWith() : DefaultSub("You could certainly never tie it with that!");
public class Touch() : ShortSub((_, __) => Print(Tables.HackHack("Fiddling with the")));
public class Unlock() : DefaultSub("It doesn't seem to work.");
public class Untie() : DefaultSub("This cannot be tied, so it cannot be untied!");
public class Verify() : DefaultSub("Verifying disk...^The disk is correct.");
public class Version() : ShortSub((_, __) => Print(Messages.Version));
public class Vomit() : DefaultSub("Preposterous!");
public class WalkAround() : DefaultSub("Use compass directions for movement.");
public class Wield() : ShortSub((_, __) => Print(Tables.HackHack("Waving the")));
public class WindUp() : ShortSub((noun, _) => Print($"You cannot wind up a {noun}."));
public class Win() : DefaultSub("Naturally!");
public class Wish() : DefaultSub("With luck, your wish will come true.");
public class Yell() : DefaultSub("Aaaarrrrgggghhhh!");
public class Zork() : DefaultSub("At your service!");
