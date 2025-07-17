using Zork1.Library;

namespace Zork1.Things;

public static class Flags
{
    private static GameState State => Objects.Get<GameState>();

    public static bool AlwaysLit { get => State.AlwaysLit; set => State.AlwaysLit = value; }
    public static bool DamOpen { get => State.DamOpen; set => State.DamOpen = value; }
    public static bool Dead { get => State.Dead; set => State.Dead = value; }
    public static bool Dome { get => State.Dome; set => State.Dome = value; }
    public static bool Done { get => State.Done; set => State.Done = value; }
    public static bool ExorcismBell { get => State.ExorcismBell; set => State.ExorcismBell = value; }
    public static bool ExorcismCandle { get => State.ExorcismCandle; set => State.ExorcismCandle = value; }
    public static bool Gate { get => State.Gate; set => State.Gate = value; }
    public static bool GrueRepellent { get => State.GrueRepellent; set => State.GrueRepellent = value; }
    public static bool LLD { get => State.LLD; set => State.LLD = value; }
    public static bool LowTide { get => State.LowTide; set => State.LowTide = value; }
    public static bool Lucky { get => State.Lucky; set => State.Lucky = value; }
    public static bool MirrorBroken { get => State.MirrorBroken; set => State.MirrorBroken = value; }
    public static bool Rainbow { get => State.Rainbow; set => State.Rainbow = value; }
    public static bool RugMoved { get => State.RugMoved; set => State.RugMoved = value; }
    public static bool SingSong { get => State.SingSong; set => State.SingSong = value; }
    public static bool ThiefHere { get => State.ThiefHere; set => State.ThiefHere = value; }
    public static bool Troll { get => State.Troll; set => State.Troll = value; }
    public static bool Won { get => State.Won; set => State.Won = value; }

    // for testing
    public static void Reset()
    {
        AlwaysLit = false;
        DamOpen = false;
        Dead = false;
        Dome = false;
        Done = false;
        ExorcismBell = false;
        ExorcismCandle = false;
        Gate = false;
        GrueRepellent = false;
        LLD = false;
        LowTide = false;
        Lucky = true;
        MirrorBroken = false;
        Rainbow = false;
        RugMoved = false;
        SingSong = false;
        ThiefHere = false;
        Troll = false;
        Won = false;
    }
}

// flags are stored in a "state" object for saving games
public class GameState : Object
{
    public bool AlwaysLit { get; set; }
    public bool DamOpen { get; set; }
    public bool Dead { get; set; }
    public bool Dome { get; set; }
    public bool Done { get; set; }
    public bool ExorcismBell { get; set; }
    public bool ExorcismCandle { get; set; }
    public bool Gate { get; set; }
    public bool GrueRepellent { get; set; }
    public bool LeavesMoved { get; set; }
    public bool LLD { get; set; }
    public bool LowTide { get; set; }
    public bool Lucky { get; set; }
    public bool MirrorBroken { get; set; }
    public bool Rainbow { get; set; }
    public bool RugMoved { get; set; }
    public bool SingSong { get; set; }
    public bool SuperBrief { get; set; }
    public bool ThiefHere { get; set; }
    public bool Troll { get; set; }
    public bool Verbose { get; set; }
    public bool Won { get; set; }
    public int Deaths { get; set; }
    public Object LastNoun { get; set; }
    public Object LastNounPlace { get; set; }
    public int LoadAllowed { get; set; } = 100;
    public int LoadMax { get; set; } = 100;
    public int MaxHeldMult { get; set; } = 8;
    public int MaximumHeld { get; set; } = 7;
    public int Moves { get; set; }
    public int PossibleScore { get; set; } = 350;
    public int Score { get; set; }
    public new bool Lit { get; set; }
    public override void Initialize() { }
}
