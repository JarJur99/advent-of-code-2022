using System.Text.RegularExpressions;

var cratesInput = File.ReadAllText("../../../crates.txt").Split("\n\n");
var cratesState = cratesInput[0].Split('\n');
var crateInstructions = cratesInput[1].Split('\n');

// Parsing crates input
var cratesSlotsIdx = cratesState
    .Last()
    .Select((slot, i) => int.TryParse(slot.ToString(), out var parsedSlot)
        ? (slot: parsedSlot, idx: i)
        : (slot: -1, idx: -1))
    .Where(pair => pair.slot != -1)
    .ToList();

var cratesParsed = new List<List<char>>();

foreach (var cratesLvl in cratesState.Where(cratesLvl => cratesLvl != cratesState.Last()))
{
    foreach (var cratesPosition in cratesSlotsIdx)
    {
        if (cratesParsed.Count < cratesPosition.slot)
            cratesParsed.Add(new List<char>());
        
        if (cratesLvl[cratesPosition.idx] != ' ')
            cratesParsed[cratesPosition.slot-1].Add(cratesLvl[cratesPosition.idx]);
    }
}

// Parsing Commands
var commandPattern = new Regex(@"move ([0-9]*) from ([1-9]*) to ([1-9]*)");
var instructions = crateInstructions
    .Select(move => commandPattern.Match(move))
    .Select(move =>
            (count: int.Parse(move.Groups[1].Value),
            from: int.Parse(move.Groups[2].Value),
            to: int.Parse(move.Groups[3].Value)))
    .ToList();

foreach (var command in instructions)
{
    var cratesToMove = cratesParsed[command.from - 1].GetRange(0, command.count);
    cratesParsed[command.from - 1].RemoveRange(0, command.count);
    // uncomment for part 1
    //cratesToMove.Reverse();
    cratesParsed[command.to - 1].InsertRange(0, cratesToMove);
}

foreach (var stock in cratesParsed)
{
    Console.Write(stock[0]);
}
Console.WriteLine();