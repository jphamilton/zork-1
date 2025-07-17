using Zork1.Library;
using Zork1.Library.Things;
using Zork1.Rooms;
using Zork1.Melee;
using Zork1.Scenic;
using Zork1.Things;

namespace Zork1;

public class Zork1GUE : Story
{
    public Zork1GUE()
    {
        Name = "Zork I: The Great Underground Empire";
        Title = "Zork I";
    }

    protected override void Start()
    {
        Output.Print(Messages.Version);

        State.Verbose = false;
        State.SuperBrief = false;

        MeleeDefinitions.Initialize();

        Clock.Queue<Sword>();
        Clock.Queue<FightDaemon>();
        Clock.Queue<Thief>();

        var adventurer = Objects.Get<Adventurer>();
        Player.Set(adventurer);
        Context.Winner = adventurer; // haven't implemented this yet

        MovePlayer.To<WestOfHouse>();

        SetLast.Object<Mailbox>();

        ////TESTING
        //var lamp = Objects.Get<BrassLantern>();
        //lamp.On = true;
        //lamp.Light = true;
        //Player.Add(lamp);
        //Player.Add(Objects.Get<AirPump>());
        //Flags.DamOpen = true;
        //Flags.LowTide = true;
        //MovePlayer.To<DeepCanyon>();

        //// --------------------  END GAME TEST
        //var window = Objects.Get<KitchenWindow>();
        //window.Open = true;
        //var trophy_case = Objects.Get<TrophyCase>();
        //trophy_case.Open = true;

        //var treasures = Objects.All.Where(x => x.TakeValue > 0 && x is not Room).ToList();

        //var rooms = Objects.All.Where(x => x.TakeValue > 0 && x is Room).ToList();

        //foreach (var room in rooms)
        //{
        //    Score.ScoreObject(room);
        //}

        //var score = State.Score;

        //var inCase = treasures.Take(18).ToList();
        //foreach (var t in inCase)
        //{
        //    Score.ScoreObject(t);
        //    Score.AddTrophy(t);
        //    t.Move(trophy_case);
        //    t.Concealed = false;
        //    t.TakeValue = 0;
        //    t.Visited = true;
        //}

        //var inInv = treasures.Skip(18).ToList();
        //foreach (var t in inInv)
        //{
        //    Score.ScoreObject(t);
        //    t.Move(Player.Instance);
        //    t.Concealed = false;
        //    t.TakeValue = 0;
        //    t.Visited = true;
        //}

        //MovePlayer.To<LivingRoom>();

    }
}
