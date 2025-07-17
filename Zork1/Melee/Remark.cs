using System.Text;
using Zork1.Library;

namespace Zork1.Melee;

public static class MeleeRoutine
{
    public static void Remark(MeleeMessage message, Object objectForCode0, Object objectForCode1)
    {
        StringBuilder sb = new StringBuilder();

        foreach (var part in message.Parts)
        {
            if (part.SpecialCode.HasValue)
            {
                switch (part.SpecialCode.Value)
                {
                    case 0: sb.Append(objectForCode0?.Name ?? "something"); break;
                    case 1: sb.Append(objectForCode1?.Name ?? "something"); break;
                    default: sb.Append($"<UNKNOWN_CODE:{part.SpecialCode.Value}>"); break;
                }
            }
            else if (part.Text != null)
            {
                sb.Append(part.Text);
            }
        }

        Output.Print($"^{sb}");
    }
}
