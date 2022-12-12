using Day11;

var monkeys = File.ReadAllText("../../../Monkeys.txt")
    .Split("\n\n")
    .Select(monkeyEntry => new Monkey(monkeyEntry))
    .ToList();
    
    
const int roundCount = 10000;

var dividers = monkeys.Select(monkey => monkey.DivisionTest);
ulong normalizer = 1;
foreach (var divider in dividers)
{
    normalizer *= divider;
}

for (var i = 0; i < roundCount; i++)
{
    foreach (var monkey in monkeys)
    {
        foreach (var item in monkey.Items)
        {
            monkey.InspectedItems++;
            var inspectedItem = monkey.InspectItem(item);
            inspectedItem %= normalizer;
            var throwId = monkey.FalseMonkeyId;
            if (inspectedItem % monkey.DivisionTest == 0)
            {
                throwId = monkey.TrueMonkeyId;
            }
            monkeys[throwId].Items.Add(inspectedItem);
        }
        monkey.Items = new List<ulong>();
    }
}

var buissiestMonkeys = monkeys
    .Select(monkey => monkey.InspectedItems)
    .OrderByDescending(x => x)
    .Take(2)
    .ToList();

Console.WriteLine(buissiestMonkeys.First() * buissiestMonkeys.Last());