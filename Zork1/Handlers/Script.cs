using Zork1.Library;

namespace Zork1.Handlers;

public class Script : Sub
{
    public override bool Handler(Object noun, Object second)
    {
        var path = Path.GetDirectoryName(typeof(Script).Assembly.Location);
        var count = 1;
        var getFile = () => Path.Combine(path, $"zork1_script_{count:D3}.log");
        var file = getFile();

        while (File.Exists(file))
        {
            count++;
            file = getFile();
        }

        return Output.StartScripting(file);
    }
}
