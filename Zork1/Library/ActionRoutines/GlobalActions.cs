using Zork1.Library.Utilities;

namespace Zork1.Library.ActionRoutines;
public static class GlobalActions
{
    private static PickOne DummyTable = new([
        "Look around.",
        "Too late for that.",
        "Have your eyes checked."
    ]);
    
    public static bool OpenOrClose(this Object obj, string openMsg, string closeMsg)
    {
        if (obj.Verb is Open)
        {
            if (obj.Open)
            {
                Output.Print(DummyTable.Pick());
            }
            else
            {
                Output.Print(openMsg);
                obj.Open = true;
            }

            return true;
        }

        if (obj.Verb is not Close)
        {
            return false;
        }

        if (obj.Open)
        {
            Output.Print(closeMsg);
            obj.Open = false;
        }
        else
        {
            Output.Print(DummyTable.Pick());
        }

        //Output.Print("\n");
        return true;
    }
}
