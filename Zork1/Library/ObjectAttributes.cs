using System.Text.Json.Serialization;

namespace Zork1.Library;

public partial class Object
{
    private bool _flame;
    private bool _takeable;

    public bool Concealed { get; set; }                     // INVISIBLE When true, Object is currently unavailable/not visible at it's location
    public bool Animate { get; set; }                       // ALIVEBIT object is alive
    public bool Climable { get; set; }                      // CLIMBBIT can climb
    public bool Clothing { get; set; }                      // Is clothing that can be worn
    public bool Container { get; set; }                     // CONTBIT
    public bool Door { get; set; }
    public bool Drinkable { get; set; }                     // DRINKBIT can drink it
    public bool DryLand { get; set; }                       // RLANDBIT room is on dry land
    public bool Edible { get; set; }                        // Can be eaten
    public bool Fight { get; set; }                         // FIGHTBIT can be fought!
    public bool Flammable { get; set; }                     // BURNBIT can be burned
    public bool Flame                                       // FLAMEBIT, open flame - will also set ON and LIGHT
    {
        get => _flame;
        set
        {
            _flame = value;
            On = value;
            Light = value;
        }
    }
    public bool Light { get; set; }                         // Is providing Light (different than Zork LIGHTBIT)
    public bool Lockable { get; set; }                      // Can be locked
    public bool Locked { get; set; }                        // Is locked/unlocked
    public bool Multitude { get; set; }                     // more than one (e.g. a pile of leaves)
    public bool On { get; set; }                            // Is on/off
    public bool Open { get; set; }                          // Is open/closed
    public bool Openable { get; set; }                      // Can open/close
    public bool Readable { get; set; }                      // READBIT - can be read
    public bool RMUNGBIT { get; set; }                      // RMUNGBIT
    public bool Sacred { get; set; }                        // SACREDBIT - special for Zork, thief does not visit these rooms
    public bool Scenery { get; set; }                       // NDESCBIT Object might be described in the text of the room and will described with the other objects.
    public bool Search { get; set; }                        // SEARCHBIT - Tells the parser to look as deeply into a container as it can in order to find the referenced object.
    public bool Staggered { get; set; }                     // ???
    public bool Supporter { get; set; }                     // SURFACEBIT - The object is a surface, such as a table, desk, countertop, etc.
    public bool Switchable { get; set; }                    // Can be switched on/off
    public bool Takeable                                    // TAKEBIT can be picked up or carried
    {
        get => _takeable || TryTake;
        set => _takeable = value;
    }
    public bool Tool { get; set; }                          // TOOLBIT object can be used as a tool to open other things
    public bool Transparent { get; set; }                   // TRANSBIT
    public bool TryTake { get; set; }                       // TRYTAKEBIT - no implicit taking
    public bool Turnable { get; set; }                      // can be turned
    public bool Vehicle { get; set; }                       // VEHBIT object can be entered or boarded, should also set Container and Open
    public bool Visited { get; set; }                       // Room visited or object has been touched
    public bool WaterRoom { get; set; }
    public bool Weapon { get; set; }                        // WEAPONBIT weapon
    public bool Worn { get; set; }                          // Clothing is being worn
    public int Strength { get; set; }                       // Related to health
    public int Size { get; set; }                           // Related to capacity?
    public int TakeValue { get; set; }                      // Value added to score for taking object or visiting special room
    [JsonIgnore]
    public string Text { get; set; }                        // Text for Readable objects
    public int TrophyValue { get; set; }                    // Value added to score when depositing in the trophy case
}