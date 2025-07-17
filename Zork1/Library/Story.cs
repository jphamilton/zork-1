using Zork1.Library.Parsing;

namespace Zork1.Library;

public abstract class Story
{
    public string Name { get; set; }
    public string Title { get; set; }

    protected abstract void Start();

    static Story()
    {
        AppDomain.CurrentDomain.ProcessExit += (s, e) => Output.StopScripting();
    }

    public void Initialize()
    {
        Dictionary.Load();

        Syntax.Load<ZorkSyntax>();
        
        Routines.Load();

        Objects.Load();
        
        // initialize rooms first
        foreach (var obj in Objects.All.Where(x => x is Room))
        {
            obj.Initialize();
            Dictionary.AddObject(obj);
        }

        // then objects
        foreach (var obj in Objects.All.Where(x => x is not Room))
        {
            obj.Initialize();
            Dictionary.AddObject(obj);
        }

        Dictionary.Sort();

        Start();
    }
}
