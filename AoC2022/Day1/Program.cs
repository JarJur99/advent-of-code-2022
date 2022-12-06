using System.Diagnostics;

// CLEANER SOLUTION
//
// var allCalories = File.ReadAllText("../../../calories.txt")
//     .Split("\n\n", StringSplitOptions.RemoveEmptyEntries)
//     .Select(line => line.Split('\n', StringSplitOptions.RemoveEmptyEntries).Sum(int.Parse))
//     .OrderByDescending(x => x)
//     .Take(3)
//     .Sum();
//
// Console.WriteLine(sw.ElapsedMilliseconds);


// FASTER SOLUTION
var allCalories = File.ReadLines("../../../calories.txt");
var maxCalorySum = new List<int>(new[] { 0, 0, 0 });
int currentElfCalory = 0;

foreach (var calory in allCalories)
{

    if (calory != "")
    {
        currentElfCalory += int.Parse(calory);
    }
    else
    {
        if (maxCalorySum.Any(backpak => backpak < currentElfCalory))
        {
            var index = maxCalorySum.FindIndex(x => x == maxCalorySum.Min());
            maxCalorySum[index] = currentElfCalory;
        }
        currentElfCalory = 0;
    }
}

Console.WriteLine(maxCalorySum.Sum());