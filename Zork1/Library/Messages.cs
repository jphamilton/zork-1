namespace Zork1.Library;

public static class Messages
{
    public static string Version => $"Zork I: The Great Underground Empire^" +
        $"Infocom interactive fiction - a fantasy story^" +
        "(c) Copyright 1981, 1982, 1983, 1985, 1986 Infocom, Inc. All Rights Reserved.^" +
        "ZORK is a registered trademark of Infocom, Inc.^" +
        "Deluxe C# Edition release v.01a (based on Release 119/Serial number 880429)";

    public const string BegYourPardon = "I beg your pardon?";
    public const string NoVerbInSentence = "There was no verb in that sentence!";
    public const string DontRecognizeSentence = "That sentence isn't one I recognize.";
    public const string NotClear = "It's not clear what you are referring to.";
    public const string TooDarkToSee = "It's too dark to see!";
    public const string CantGoThatWay = "You can't go that way.";
    public const string DontHaveThat = "You don't have that!";

    public static Func<string, string> CantSeeThatHere = static (token) => $"You can't see any {token} here!";
    public static Func<string, string> DontKnowThatWord = static (token) => $"I don't know the word \"{token}\".";
}
