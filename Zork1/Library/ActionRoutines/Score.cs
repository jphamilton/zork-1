namespace Zork1.Library.ActionRoutines;
public class Score : Routine
{
    public Score()
    {
        Verbs = ["score"];
        NoTurn = true;
    }

    public static bool Print()
    {
        var score = State.Score;
        var moves = State.Moves;
        var rank = "Beginner";

        if (score == 350)
        {
            rank = "Master Adventurer";
        }
        else if (score > 330)
        {
            rank = "Wizard";
        }
        else if (score > 300)
        {
            rank = "Master";
        }
        else if (score > 200)
        {
            rank = "Adventurer";
        }
        else if (score > 100)
        {
            rank = "Junior Adventurer";
        }
        else if (score > 50)
        {
            rank = "Novice Adventurer";
        }
        else if (score > 25)
        {
            rank = "Amateur Adventurer";
        }
        else
        {
            rank = "Beginner";
        }

        Print($"Your score is {score} (total of 350 points), in {moves} moves.");
        return Print($"This score gives you the rank of {rank}.");
    }

    public override bool Handler(Object _, Object __ = null)
    {
        return Print();
    }

    public static void Add(int value)
    {
        State.Score += value;
    }
}
