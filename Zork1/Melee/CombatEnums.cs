namespace Zork1.Melee;

public enum CombatFlags
{
    DISARMED = 1,   // M_HANDLED
    DEAD = 2,       // M_ENTER
    OUTCOLD = 3,    // M_LOOK
    WAKE = 4,       // M_WAKE
    ATTACKED = 5    // M_FIGHT
}

// corresponds to the 1-indexed attack types in the _melee arrays.
public enum CombatOutcome
{
    None = 0,
    Missed = 1,             // "attacker misses"
    Knockout = 2,           // "defender unconscious"
    Killed = 3,             // "defender dead"
    LightWound = 4,         // "defender lightly wounded"
    SeriousWound = 5,       // "defender seriously wounded"
    Stagger = 6,            // "defender staggered (miss turn)"
    LoseWeapon = 7,         // "defender loses weapon" (derived outcome)
    Hesitate = 8,           // "hesitates (miss on free swing)" (derived outcome)
    SittingDuck = 9         // "sitting duck (crunch!)" (derived outcome)
}