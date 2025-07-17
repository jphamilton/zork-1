using System.Reflection;
using System.Text;
using Zork1.Library.Things;
using Zork1.Library;
using Zork1;
using Zork1.Rooms;
using Zork1.Library.Parsing;
using Zork1.Things;

namespace Tests;
public class TestFormatter : IOutputFormatter
{
    public string Format(string text)
    {
        return text;
    }
}

[Collection("Sequential")]
public abstract class BaseTestFixture : IDisposable
{
    private StringBuilder _fakeConsole;
    private string _output;
    private Frame _previous;
    protected Object player => Player.Instance;

    public BaseTestFixture()
    {
        _fakeConsole = new StringBuilder();
        Context.Story = new Zork1GUE();
        Output.Initialize(new StringWriter(_fakeConsole), new TestFormatter());
        Prompt.Initialize(new StringReader(""));
        Context.Story.Initialize();

        Flags.Reset();

        LoadTestObjects();

        _fakeConsole.Clear();
    }

    private static void LoadTestObjects()
    {
        Assembly ax = typeof(BaseTestFixture).Assembly;

        var objectType = typeof(Object);
        
        foreach (var type in ax.GetTypes().Where(x => x.IsSubclassOf(objectType)).ToList())
        {
            if (Activator.CreateInstance(type) is Object obj)
            {
                obj.Initialize();
                Objects.Add(obj);
                Dictionary.AddObject(obj);
            }
        }
    }

    public void Dispose()
    {
        _fakeConsole.Clear();
        _output = null;
    }

    protected void ClearOutput()
    {
        _output = null;
        _fakeConsole.Clear();
    }

    protected Room Room<T>() where T : Room
    {
        return Get<T>();
    }

    protected Room Location
    {
        get
        {
            return Player.Location;
        }
        set
        {
            Player.Location = value;
        }
    }

    public string ConsoleOut
    {
        get
        {
            if (!string.IsNullOrEmpty(_output))
            {
                return _output;
            }

            _output = _fakeConsole.ToString();

            return _output;
        }
    }

    protected bool Print(string message)
    {
        Output.Print(message);
        return true;
    }

    protected Frame Execute(string input)
    {
        var index = 0;

        while (true)
        {
            var room = Player.Location;
            
            State.Lit = Query.Light(Player.Location);

            try
            {
                var frame = Parser.Parse(input, _previous);

                if (frame.IsError && !frame.Orphan)
                {
                    Output.Print(frame.Error);
                    break;
                }

                if (frame.Orphan)
                {
                    Output.Print(frame.Error);
                    input = Prompt.GetInput();
                    if (input == null)
                    {
                        break;
                    }
                    _previous = frame;
                    continue;
                }

                var command = new Command(frame);
                var run = command.Run();

                CurrentRoom.CheckLight(room, State.Lit);

                _previous = null;

                return frame;
            }
            catch (DeathException)
            {
                var dead = Routines.GetJigsUp();

                if (!dead.Handler(null, null))
                {
                    break;
                }
            }

            _previous = null;

            break;
        }

        return null;
    }

    protected T Inv<T>() where T : Object
    {
        return Player.Add<T>();
    }

    protected T Get<T>() where T : Object
    {
        return Objects.Get<T>();
    }
    public static (A, B) Get<A, B>()
        where A : Object
        where B : Object => Objects.Get<A, B>();

    public static (A, B, C) Get<A, B, C>()
        where A : Object
        where B : Object
        where C : Object => Objects.Get<A, B, C>();

    protected T Here<T>() where T : Object
    {
        var obj = Get<T>();
        obj.MoveHere();
        return obj;
    }
}