namespace Zork1.Scenic;

public class ControlPanel : Object
{
    public static string Integral = "It is an integral part of the control panel.";

    public ControlPanel()
    {
        Scenery = true;
    }

    public override void Initialize()
    {
        Name = "control panel";
        Adjectives = ["panel", "control"];
    }
}
