using Zork1.Handlers;
using Zork1.Library;

namespace Tests;
public class RedHat : Object
{
    public RedHat()
    {
        Clothing = true;
        Takeable = true;
    }

    public override void Initialize()
    {
        Name = "red hat";
        Adjectives = ["hat", "red"];
    }
}

public class BlackHat : Object
{
    public BlackHat()
    {
        Clothing = true;
        Takeable = true;
    }

    public override void Initialize()
    {
        Name = "black hat";
        Adjectives = ["hat", "black"];
    }
}

public class WhiteHat : Object
{
    public WhiteHat()
    {
        Clothing = true;
        Takeable = true;
    }

    public override void Initialize()
    {
        Name = "white hat";
        Adjectives = ["hat", "white"];
    }
}

public class BlackCloak : Object
{
    public BlackCloak()
    {
        Clothing = true;
        Takeable = true;
    }

    public override void Initialize()
    {
        Name = "black cloak";
        Adjectives = ["cloak", "black", "cape"];
        Description = "The cloak is a black darker than black. A color so dark it confuses the eyes.";
    }
}

public class Table : Supporter
{
    public override void Initialize()
    {
        Name = "rustic wooden table";
        Adjectives = ["table", "rustic", "wooden"];
        Description = "Just an old farmhouse table that's seen better years.";
    }
}

public class TransparentBox : Container
{
    public TransparentBox()
    {
        Takeable = true;
        Transparent = true;
        Openable = true;
        Open = true;
    }

    public override void Initialize()
    {
        Name = "strange glass box";
        Adjectives = ["box", "strange", "glass"];
        Description = "The box is just strange, ok?";
    }
}

public class OpaqueBox : Container
{
    public OpaqueBox()
    {
        Takeable = true;
        Transparent = false;
        Openable = true;
        Open = true;
    }

    public override void Initialize()
    {
        Name = "opaque box";
        Adjectives = ["box", "opaque"];
        Description = "The box looks like a solid cube made of light.";
    }
}

public class MagentaBox : Container
{
    public MagentaBox()
    {
        Takeable = true;
        Transparent = true;
        Openable = true;
        Open = true;
    }

    public override void Initialize()
    {
        Name = "magenta box";
        Adjectives = ["box", "magenta"];
        Description = "It's just a box";
    }
}

public class ChinaCabinet : Container
{
    public ChinaCabinet()
    {
        Transparent = true;
        Openable = true;
        Open = true;
        Search = true;
    }

    public override void Initialize()
    {
        Name = "china cabinet";
        Adjectives = ["cabinet", "china"];
        Description = "It's looks just like the one at your Granny's house!";
    }
}

public class HiddenFrog : Object
{
    public HiddenFrog()
    {
        Concealed = true;
        Takeable = true;
    }

    public override void Initialize()
    {
        Name = "hidden frog";
        Adjectives = ["frog", "hidden"];
    }
}

public class MoonRock : Object
{
    public MoonRock()
    {
        Takeable = true;
    }

    public override void Initialize()
    {
        Name = "moon rock";
        Adjectives = ["rock", "moon"];
    }
}

public class FlickeringTorch : Object
{
    public FlickeringTorch()
    {
        Flame = true;
        Takeable = true;
    }

    public override void Initialize()
    {
        Name = "flickering torch";
        Adjectives = ["torch", "flickering"];
    }
}

public class Flashlight : Object
{
    public Flashlight()
    {
        Light = false;
        On = false;
        Switchable = true;
        Takeable = true;
    }

    public override void Initialize()
    {
        Name = "Radio Shack flashlight";
        Adjectives = ["flashlight", "radio", "shack", "radioshack"];
    }
}

public class Boulder : Object
{
    public Boulder()
    {
        Size = 150;
        Takeable = true;
    }

    public override void Initialize()
    {
        Name = "boulder";
        Adjectives = ["boulder"];
    }
}

public class ImposingCave : Room
{
    public ImposingCave()
    {
        Light = false;
        DryLand = true;
    }

    public override void Initialize()
    {
        Name = "imposing cave";
    }
}

public class OakDoor : Door
{
    public OakDoor()
    {
        Scenery = true;
    }

    public override void Initialize()
    {
        Name = "oak door";
        Adjectives = ["oak", "door"];
    }
}

public class DarkSpirit : Object
{
    public DarkSpirit()
    {
        Animate = true;
    }

    public override void Initialize()
    {
        Name = "dark spirit";
        Adjectives = ["spirit", "dark"];
        Before<Attack>(() => Print($"The {Name} is unphased by your attempts at violence."));
    }
}

public class InfiniteWhiteRoom : Room
{
    public InfiniteWhiteRoom()
    {
        Light = true;
        DryLand = true;
    }

    public override void Initialize()
    {
        Name = "infinite white room";
        Description = "This is like the Matrix, but without the guns.";
    }
}