using Zork1.Library;
using Zork1.Things;

namespace Zork1.Melee;

public static class MeleeDefinitions
{
    public static MeleeDefinition TrollMelee { get; private set; }
    public static MeleeDefinition ThiefMelee { get; private set; }
    public static MeleeDefinition CyclopsMelee { get; private set; } // NOT USED
    public static MeleeDefinition HeroMelee { get; private set; }

    // Inform's Def1, Def2a, Def2b, Def3a, Def3b, Def3c arrays
    public static int[] Def1 { get; private set; }
    public static int[] Def2a { get; private set; }
    public static int[] Def2b { get; private set; }
    public static int[] Def3a { get; private set; }
    public static int[] Def3b { get; private set; }
    public static int[] Def3c { get; private set; }

    // Inform's Def1_res, Def2_res, Def3_res lookups
    // These abstract the complex pointer arithmetic in Inform to select the correct DefX array for outcome lookup.
    // The `random(9) - 1` implies that the chosen `DefX` array will be sampled randomly.
    public static List<VillainDefinitionEntry> VillainDefinitions { get; private set; }

    // This method replaces Inform's `SetupMelee` and `SetupMeleeTables` by pre-populating C# structures.
    public static void Initialize()
    {
        // --- Populate TrollMelee ---
        TrollMelee = new MeleeDefinition();
        // Attack Type 1: Missed
        TrollMelee.AttackTypes.Add(new MeleeAttackType
        {
            Messages = new([
                new MeleeMessage { Parts = { new MeleeMessagePart("The troll swings his axe, but it misses.") } },
                new MeleeMessage { Parts = { new MeleeMessagePart("The troll's axe barely misses your ear.") } },
                new MeleeMessage { Parts = { new MeleeMessagePart("The axe sweeps past as you jump aside.") } },
                new MeleeMessage { Parts = { new MeleeMessagePart("The axe crashes against the rock, throwing sparks!") } }
            ])
        });
        // Attack Type 2: Knockout
        TrollMelee.AttackTypes.Add(new MeleeAttackType
        {
            Messages = new([
                new MeleeMessage { Parts = { new MeleeMessagePart("The flat of the troll's axe hits you delicately on the head, knocking you out.") } }
            ])
        });
        // Attack Type 3: Killed
        TrollMelee.AttackTypes.Add(new MeleeAttackType
        {
            Messages = new([
                new MeleeMessage { Parts = { new MeleeMessagePart("The troll neatly removes your head.") } },
                new MeleeMessage { Parts = { new MeleeMessagePart("The troll's axe stroke cleaves you from the nave to the chops.") } },
                new MeleeMessage { Parts = { new MeleeMessagePart("The troll's axe removes your head.") } }
            ])
        });
        // Attack Type 4: Light Wound
        TrollMelee.AttackTypes.Add(new MeleeAttackType
        {
            Messages = new([
                new MeleeMessage { Parts = { new MeleeMessagePart("The axe gets you right in the side. Ouch!") } },
                new MeleeMessage { Parts = { new MeleeMessagePart("The flat of the troll's axe skins across your forearm.") } },
                new MeleeMessage { Parts = { new MeleeMessagePart("The troll's swing almost knocks you over as you barely parry in time.") } },
                new MeleeMessage { Parts = { new MeleeMessagePart("The troll swings his axe, and it nicks your arm as you dodge.") } }
            ])
        });
        // Attack Type 5: Serious Wound (includes special code 0 for weapon/arm)
        TrollMelee.AttackTypes.Add(new MeleeAttackType
        {
            Messages = new([
                new MeleeMessage { Parts = { new MeleeMessagePart("The troll charges, and his axe slashes you on your "), new MeleeMessagePart(0), new MeleeMessagePart(" arm.") } },
                new MeleeMessage { Parts = { new MeleeMessagePart("An axe stroke makes a deep wound in your leg.") } },
                new MeleeMessage { Parts = { new MeleeMessagePart("The troll's axe swings down, gashing your shoulder.") } }
            ])
        });
        // Attack Type 6: Stagger
        TrollMelee.AttackTypes.Add(new MeleeAttackType
        {
            Messages = new([
                new MeleeMessage { Parts = { new MeleeMessagePart("The troll hits you with a glancing blow, and you are momentarily stunned.") } },
                new MeleeMessage { Parts = { new MeleeMessagePart("The troll swings; the blade turns on your armor but crashes broadside into your head.") } },
                new MeleeMessage { Parts = { new MeleeMessagePart("You stagger back under a hail of axe strokes.") } },
                new MeleeMessage { Parts = { new MeleeMessagePart("The troll's mighty blow drops you to your knees.") } }
            ])
        });
        // Attack Type 7: Lose Weapon (includes special code 0 for weapon/arm)
        TrollMelee.AttackTypes.Add(new MeleeAttackType
        {
            Messages = new([
                new MeleeMessage { Parts = { new MeleeMessagePart("The axe hits your "), new MeleeMessagePart(0), new MeleeMessagePart(" and knocks it spinning.") } },
                new MeleeMessage { Parts = { new MeleeMessagePart("The troll swings, you parry, but the force of his blow knocks your "), new MeleeMessagePart(0), new MeleeMessagePart(" away.") } },
                new MeleeMessage { Parts = { new MeleeMessagePart("The axe knocks your "), new MeleeMessagePart(0), new MeleeMessagePart(" out of your hand. It falls to the floor.") } }
            ])
        });
        // Attack Type 8: Hesitate
        TrollMelee.AttackTypes.Add(new MeleeAttackType
        {
            Messages = new([
                new MeleeMessage { Parts = { new MeleeMessagePart("The troll hesitates, fingering his axe.") } },
                new MeleeMessage { Parts = { new MeleeMessagePart("The troll scratches his head ruminatively: Might you be magically protected, he wonders?") } }
            ])
        });
        // Attack Type 9: Sitting Duck (Killed)
        TrollMelee.AttackTypes.Add(new MeleeAttackType
        {
            Messages = new([
                new MeleeMessage { Parts = { new MeleeMessagePart("Conquering his fears, the troll puts you to death.") } }
            ])
        });

        // --- Populate ThiefMelee (partial for example, follow pattern above) ---
        ThiefMelee = new MeleeDefinition();
        ThiefMelee.AttackTypes.Add(new MeleeAttackType
        { // Missed (1)
            Messages = new([
                new MeleeMessage { Parts = { new MeleeMessagePart("The thief stabs nonchalantly with his stiletto and misses.") } },
                new MeleeMessage { Parts = { new MeleeMessagePart("You dodge as the thief comes in low.") } },
                new MeleeMessage { Parts = { new MeleeMessagePart("You parry a lightning thrust, and the thief salutes you with a grim nod.") } },
                new MeleeMessage { Parts = { new MeleeMessagePart("The thief tries to sneak past your guard, but you twist away.") } }
            ])
        });
        ThiefMelee.AttackTypes.Add(new MeleeAttackType
        { // Knockout (2)
            Messages = new([
                new MeleeMessage { Parts = { new MeleeMessagePart("Shifting in the midst of a thrust, the thief knocks you unconscious with the haft of his stiletto.") } },
                new MeleeMessage { Parts = { new MeleeMessagePart("The thief knocks you out.") } }
            ])
        });
        // ... (continue for all Thief_melee messages)
        ThiefMelee.AttackTypes.Add(new MeleeAttackType
        { // Killed (3)
            Messages = new([
                new MeleeMessage { Parts = { new MeleeMessagePart("Finishing you off, the thief inserts his blade into your heart.") } },
                new MeleeMessage { Parts = { new MeleeMessagePart("The thief comes in from the side, feints, and inserts the blade into your ribs.") } },
                new MeleeMessage { Parts = { new MeleeMessagePart("The thief bows formally, raises his stiletto, and with a wry grin, ends the battle and your life.") } }
            ])
        });
        ThiefMelee.AttackTypes.Add(new MeleeAttackType
        { // Light Wound (4)
            Messages = new([
                new MeleeMessage { Parts = { new MeleeMessagePart("A quick thrust pinks your left arm, and blood starts to trickle down.") } },
                new MeleeMessage { Parts = { new MeleeMessagePart("The thief draws blood, raking his stiletto across your arm.") } },
                new MeleeMessage { Parts = { new MeleeMessagePart("The stiletto flashes faster than you can follow, and blood wells from your leg.") } },
                new MeleeMessage { Parts = { new MeleeMessagePart("The thief slowly approaches, strikes like a snake, and leaves you wounded.") } }
            ])
        });
        ThiefMelee.AttackTypes.Add(new MeleeAttackType
        { // Serious Wound (5)
            Messages = new([
                new MeleeMessage { Parts = { new MeleeMessagePart("The thief strikes like a snake! The resulting wound is serious.") } },
                new MeleeMessage { Parts = { new MeleeMessagePart("The thief stabs a deep cut in your upper arm.") } },
                new MeleeMessage { Parts = { new MeleeMessagePart("The stiletto touches your forehead, and the blood obscures your vision.") } },
                new MeleeMessage { Parts = { new MeleeMessagePart("The thief strikes at your wrist, and suddenly your grip is slippery with blood.") } }
            ])
        });
        ThiefMelee.AttackTypes.Add(new MeleeAttackType
        { // Stagger (6)
            Messages = new([
                new MeleeMessage { Parts = { new MeleeMessagePart("The butt of his stiletto cracks you on the skull, and you stagger back.") } },
                new MeleeMessage { Parts = { new MeleeMessagePart("The thief rams the haft of his blade into your stomach, leaving you out of breath.") } },
                new MeleeMessage { Parts = { new MeleeMessagePart("The thief attacks, and you fall back desperately.") } }
            ])
        });
        ThiefMelee.AttackTypes.Add(new MeleeAttackType
        { // Lose Weapon (7)
            Messages = new([
                new MeleeMessage { Parts = { new MeleeMessagePart("A long, theatrical slash. You catch it on your "), new MeleeMessagePart(0), new MeleeMessagePart(", but the thief twists his knife, and the "), new MeleeMessagePart(0), new MeleeMessagePart(" goes flying.") } },
                new MeleeMessage { Parts = { new MeleeMessagePart("The thief neatly flips your "), new MeleeMessagePart(0), new MeleeMessagePart(" out of your hands, and it drops to the floor.") } },
                new MeleeMessage { Parts = { new MeleeMessagePart("You parry a low thrust, and your "), new MeleeMessagePart(0), new MeleeMessagePart(" slips out of your hand.") } }
            ])
        });
        ThiefMelee.AttackTypes.Add(new MeleeAttackType
        { // Hesitate (8)
            Messages = new([
                new MeleeMessage { Parts = { new MeleeMessagePart("The thief, a man of superior breeding, pauses for a moment to consider the propriety of finishing you off.") } },
                new MeleeMessage { Parts = { new MeleeMessagePart("The thief amuses himself by searching your pockets.") } },
                new MeleeMessage { Parts = { new MeleeMessagePart("The thief entertains himself by rifling your pack.") } }
            ])
        });
        ThiefMelee.AttackTypes.Add(new MeleeAttackType
        { // Sitting Duck (Killed) (9)
            Messages = new([
                new MeleeMessage { Parts = { new MeleeMessagePart("The thief, forgetting his essentially genteel upbringing, cuts your throat.") } },
                new MeleeMessage { Parts = { new MeleeMessagePart("The thief, a pragmatist, dispatches you as a threat to his livelihood.") } }
            ])
        });

        // --- Populate CyclopsMelee (partial for example) ---
        CyclopsMelee = new MeleeDefinition();
        CyclopsMelee.AttackTypes.Add(new MeleeAttackType
        { // Missed (1)
            Messages = new([
                new MeleeMessage { Parts = { new MeleeMessagePart("The Cyclops misses, but the backwash almost knocks you over.") } },
                new MeleeMessage { Parts = { new MeleeMessagePart("The Cyclops rushes you, but runs into the wall.") } }
            ])
        });
        CyclopsMelee.AttackTypes.Add(new MeleeAttackType
        { // Knockout (2)
            Messages = new([
                new MeleeMessage { Parts = { new MeleeMessagePart("The Cyclops sends you crashing to the floor, unconscious.") } }
            ])
        });
        // ... (continue for all Cyclops_melee messages)
        CyclopsMelee.AttackTypes.Add(new MeleeAttackType
        { // Killed (3)
            Messages = new([
                new MeleeMessage { Parts = { new MeleeMessagePart("The Cyclops breaks your neck with a massive smash.") } }
            ])
        });
        CyclopsMelee.AttackTypes.Add(new MeleeAttackType
        { // Light Wound (4)
            Messages = new([
                new MeleeMessage { Parts = { new MeleeMessagePart("A quick punch, but it was only a glancing blow.") } },
                new MeleeMessage { Parts = { new MeleeMessagePart("A glancing blow from the Cyclops' fist.") } }
            ])
        });
        CyclopsMelee.AttackTypes.Add(new MeleeAttackType
        { // Serious Wound (5)
            Messages = new([
                new MeleeMessage { Parts = { new MeleeMessagePart("The monster smashes his huge fist into your chest, breaking several ribs.") } },
                new MeleeMessage { Parts = { new MeleeMessagePart("The Cyclops almost knocks the wind out of you with a quick punch.") } }
            ])
        });
        CyclopsMelee.AttackTypes.Add(new MeleeAttackType
        { // Stagger (6)
            Messages = new([
                new MeleeMessage { Parts = { new MeleeMessagePart("The Cyclops lands a punch that knocks the wind out of you.") } },
                new MeleeMessage { Parts = { new MeleeMessagePart("Heedless of your weapons, the Cyclops tosses you against the rock wall of the room.") } }
            ])
        });
        CyclopsMelee.AttackTypes.Add(new MeleeAttackType
        { // Lose Weapon (7)
            Messages = new([
                new MeleeMessage { Parts = { new MeleeMessagePart("The Cyclops grabs your "), new MeleeMessagePart(0), new MeleeMessagePart(", tastes it, and throws it to the ground in disgust.") } },
                new MeleeMessage { Parts = { new MeleeMessagePart("The monster grabs you on the wrist, squeezes, and you drop your "), new MeleeMessagePart(0), new MeleeMessagePart(" in pain.") } }
            ])
        });
        CyclopsMelee.AttackTypes.Add(new MeleeAttackType
        { // Hesitate (8)
            Messages = new([
                new MeleeMessage { Parts = { new MeleeMessagePart("The Cyclops seems unable to decide whether to broil or stew his dinner.") } }
            ])
        });
        CyclopsMelee.AttackTypes.Add(new MeleeAttackType
        { // Sitting Duck (Killed) (9)
            Messages = new([
                new MeleeMessage { Parts = { new MeleeMessagePart("The Cyclops, no sportsman, dispatches his unconscious victim.") } }
            ])
        });

        // --- Populate HeroMelee (partial for example) ---
        HeroMelee = new MeleeDefinition();
        // Attack Type 1: Missed
        HeroMelee.AttackTypes.Add(new MeleeAttackType
        {
            Messages = new([
                new MeleeMessage { Parts = { new MeleeMessagePart("Your "), new MeleeMessagePart(0), new MeleeMessagePart(" misses the "), new MeleeMessagePart(1), new MeleeMessagePart(" by an inch.") } },
                new MeleeMessage { Parts = { new MeleeMessagePart("A good slash, but it misses the "), new MeleeMessagePart(1), new MeleeMessagePart(" by a mile.") } },
                new MeleeMessage { Parts = { new MeleeMessagePart("You charge, but the "), new MeleeMessagePart(1), new MeleeMessagePart(" jumps nimbly aside.") } },
                new MeleeMessage { Parts = { new MeleeMessagePart("Clang! Crash! The "), new MeleeMessagePart(1), new MeleeMessagePart(" parries.") } },
                new MeleeMessage { Parts = { new MeleeMessagePart("A quick stroke, but the "), new MeleeMessagePart(1), new MeleeMessagePart(" is on guard.") } },
                new MeleeMessage { Parts = { new MeleeMessagePart("A good stroke, but it's too slow; the "), new MeleeMessagePart(1), new MeleeMessagePart(" dodges.") } }
            ])
        });
        // Attack Type 2: Knockout
        HeroMelee.AttackTypes.Add(new MeleeAttackType
        {
            Messages = new([
                new MeleeMessage { Parts = { new MeleeMessagePart("Your "), new MeleeMessagePart(0), new MeleeMessagePart(" crashes down, knocking the "), new MeleeMessagePart(1), new MeleeMessagePart(" into dreamland.") } },
                new MeleeMessage { Parts = { new MeleeMessagePart("The "), new MeleeMessagePart(1), new MeleeMessagePart(" is battered into unconsciousness.") } },
                new MeleeMessage { Parts = { new MeleeMessagePart("A furious exchange, and the "), new MeleeMessagePart(1), new MeleeMessagePart(" is knocked out!") } },
                new MeleeMessage { Parts = { new MeleeMessagePart("The haft of your "), new MeleeMessagePart(0), new MeleeMessagePart(" knocks out the "), new MeleeMessagePart(1), new MeleeMessagePart(".") } },
                new MeleeMessage { Parts = { new MeleeMessagePart("The "), new MeleeMessagePart(1), new MeleeMessagePart(" is knocked out!") } }
            ])
        });
        // Attack Type 3: Killed
        HeroMelee.AttackTypes.Add(new MeleeAttackType
        {
            Messages = new([
                new MeleeMessage { Parts = { new MeleeMessagePart("It's curtains for the "), new MeleeMessagePart(1), new MeleeMessagePart(" as your "), new MeleeMessagePart(0), new MeleeMessagePart(" removes his head.") } },
                new MeleeMessage { Parts = { new MeleeMessagePart("The fatal blow strikes the "), new MeleeMessagePart(1), new MeleeMessagePart(" square in the heart: He dies.") } },
                new MeleeMessage { Parts = { new MeleeMessagePart("The "), new MeleeMessagePart(1), new MeleeMessagePart(" takes a fatal blow and slumps to the floor dead.") } }
            ])
        });
        // Attack Type 4: Light Wound
        HeroMelee.AttackTypes.Add(new MeleeAttackType
        {
            Messages = new([
                new MeleeMessage { Parts = { new MeleeMessagePart("The "), new MeleeMessagePart(1), new MeleeMessagePart(" is struck on the arm; blood begins to trickle down.") } },
                new MeleeMessage { Parts = { new MeleeMessagePart("Your "), new MeleeMessagePart(0), new MeleeMessagePart(" pinks the "), new MeleeMessagePart(1), new MeleeMessagePart(" on the wrist, but it's not serious.") } },
                new MeleeMessage { Parts = { new MeleeMessagePart("Your stroke lands, but it was only the flat of the blade.") } },
                new MeleeMessage { Parts = { new MeleeMessagePart("The blow lands, making a shallow gash in the "), new MeleeMessagePart(1), new MeleeMessagePart("'s arm!") } }
            ])
        });
        // Attack Type 5: Serious Wound
        HeroMelee.AttackTypes.Add(new MeleeAttackType
        {
            Messages = new([
                new MeleeMessage { Parts = { new MeleeMessagePart("The "), new MeleeMessagePart(1), new MeleeMessagePart(" receives a deep gash in his side.") } },
                new MeleeMessage { Parts = { new MeleeMessagePart("A savage blow on the thigh! The "), new MeleeMessagePart(1), new MeleeMessagePart(" is stunned but can still fight!") } },
                new MeleeMessage { Parts = { new MeleeMessagePart("Slash! Your blow lands! That one hit an artery, it could be serious!") } },
                new MeleeMessage { Parts = { new MeleeMessagePart("Slash! Your stroke connects! This could be serious!") } }
            ])
        });
        // Attack Type 6: Stagger
        HeroMelee.AttackTypes.Add(new MeleeAttackType
        {
            Messages = new([
                new MeleeMessage { Parts = { new MeleeMessagePart("The "), new MeleeMessagePart(1), new MeleeMessagePart(" is staggered, and drops to his knees.") } },
                new MeleeMessage { Parts = { new MeleeMessagePart("The "), new MeleeMessagePart(1), new MeleeMessagePart(" is momentarily disoriented and can't fight back.") } },
                new MeleeMessage { Parts = { new MeleeMessagePart("The force of your blow knocks the "), new MeleeMessagePart(1), new MeleeMessagePart(" back, stunned.") } },
                new MeleeMessage { Parts = { new MeleeMessagePart("The "), new MeleeMessagePart(1), new MeleeMessagePart(" is confused and can't fight back.") } },
                new MeleeMessage { Parts = { new MeleeMessagePart("The quickness of your thrust knocks the "), new MeleeMessagePart(1), new MeleeMessagePart(" back, stunned.") } }
            ])
        });
        // Attack Type 7: Lose Weapon
        HeroMelee.AttackTypes.Add(new MeleeAttackType
        {
            Messages = new([
                new MeleeMessage { Parts = { new MeleeMessagePart("The "), new MeleeMessagePart(1), new MeleeMessagePart("'s weapon is knocked to the floor, leaving him unarmed.") } },
                new MeleeMessage { Parts = { new MeleeMessagePart("The "), new MeleeMessagePart(1), new MeleeMessagePart(" is disarmed by a subtle feint past his guard.") } }
            ])
        });

        // These map to CombatOutcome enums
        Def1 = [
            (int)CombatOutcome.Missed, (int)CombatOutcome.Missed, (int)CombatOutcome.Missed, (int)CombatOutcome.Missed,
            (int)CombatOutcome.Stagger, (int)CombatOutcome.Stagger,
            (int)CombatOutcome.Knockout, (int)CombatOutcome.Knockout,
            (int)CombatOutcome.Killed, (int)CombatOutcome.Killed, (int)CombatOutcome.Killed, (int)CombatOutcome.Killed, (int)CombatOutcome.Killed
        ];

        Def2a = [
            (int)CombatOutcome.Missed, (int)CombatOutcome.Missed, (int)CombatOutcome.Missed, (int)CombatOutcome.Missed, (int)CombatOutcome.Missed,
            (int)CombatOutcome.Stagger, (int)CombatOutcome.Stagger,
            (int)CombatOutcome.LightWound, (int)CombatOutcome.LightWound,
            (int)CombatOutcome.Knockout
        ];

        Def2b = [
            (int)CombatOutcome.Missed, (int)CombatOutcome.Missed, (int)CombatOutcome.Missed,
            (int)CombatOutcome.Stagger, (int)CombatOutcome.Stagger,
            (int)CombatOutcome.LightWound, (int)CombatOutcome.LightWound, (int)CombatOutcome.LightWound,
            (int)CombatOutcome.Knockout,
            (int)CombatOutcome.Killed, (int)CombatOutcome.Killed, (int)CombatOutcome.Killed
        ];

        Def3a = [
            (int)CombatOutcome.Missed, (int)CombatOutcome.Missed, (int)CombatOutcome.Missed, (int)CombatOutcome.Missed, (int)CombatOutcome.Missed,
            (int)CombatOutcome.Stagger, (int)CombatOutcome.Stagger,
            (int)CombatOutcome.LightWound, (int)CombatOutcome.LightWound,
            (int)CombatOutcome.SeriousWound, (int)CombatOutcome.SeriousWound
        ];

        Def3b = [
            (int)CombatOutcome.Missed, (int)CombatOutcome.Missed, (int)CombatOutcome.Missed,
            (int)CombatOutcome.Stagger, (int)CombatOutcome.Stagger,
            (int)CombatOutcome.LightWound, (int)CombatOutcome.LightWound, (int)CombatOutcome.LightWound,
            (int)CombatOutcome.SeriousWound, (int)CombatOutcome.SeriousWound, (int)CombatOutcome.SeriousWound
        ];

        Def3c = [
            (int)CombatOutcome.Missed,
            (int)CombatOutcome.Stagger, (int)CombatOutcome.Stagger,
            (int)CombatOutcome.LightWound, (int)CombatOutcome.LightWound, (int)CombatOutcome.LightWound, (int)CombatOutcome.LightWound,
            (int)CombatOutcome.SeriousWound, (int)CombatOutcome.SeriousWound, (int)CombatOutcome.SeriousWound
        ];

        VillainDefinitions = [
            new VillainDefinitionEntry(Objects.Get<Troll>(), Objects.Get<Sword>(), 1, 0, TrollMelee),
            new VillainDefinitionEntry(Objects.Get<Thief>(), Objects.Get<NastyKnife>(), 1, 0, ThiefMelee),
            new VillainDefinitionEntry(Objects.Get<Cyclops>(), null, 0, 0, CyclopsMelee)
        ];
    }

    public static CombatOutcome GetDefensiveResult(int defensiveStrength, int attackingStrength)
    {
        int[] sourceArray;
        int maxSampleLength = 9; // Most Inform arrays use random(9)

        if (defensiveStrength == 1)
        {
            // Inform: if (att > 2) { att = 3; } tbl = Def1_res-->(att - 1);
            // This part implies mapping of attacker strength to Def1 for strength 1 defender.
            // For simplicity, we just use Def1 as the source.
            sourceArray = Def1;
        }
        else if (defensiveStrength == 2)
        {
            // Inform: if (att > 3) { att = 4; } tbl = Def2_res-->(att - 1);
            // This maps to Def2a or Def2b based on attacker's strength.
            if (attackingStrength == 1 || attackingStrength == 2)
            {
                sourceArray = Def2a;
            }
            else
            {
                sourceArray = Def2b; // For att 3 or 4.
            }
        }
        else // defensiveStrength > 2
        {
            // Inform: att = att - def; if (att < -1) { att = -2; } else if (att > 1) { att = 2; }
            // tbl = Def3_res-->(att + 2);
            // This calculates a 'relative strength' difference and maps it to Def3a/b/c.
            int relativeStrength = attackingStrength - defensiveStrength;

            if (relativeStrength < -1)
            {
                relativeStrength = -2;
            }
            else if (relativeStrength > 1)
            {
                relativeStrength = 2;
            }

            switch (relativeStrength)
            {
                case -2: sourceArray = Def3c; break;
                case -1: sourceArray = Def3a; break;
                case 0: sourceArray = Def3a; break; // Default or implicitly handled
                case 1: sourceArray = Def3b; break;
                case 2: sourceArray = Def3b; break;
                default: sourceArray = Def3a; break; // Fallback if unexpected value
            }
        }

        int randomIndex = Random.Number(0, Math.Min(maxSampleLength, sourceArray.Length));
        return (CombatOutcome)sourceArray[randomIndex];
    }

}
