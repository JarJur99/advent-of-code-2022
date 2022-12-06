// var backpacks = File.ReadAllLines("../../../backpacks.txt")
//     .Select(backpack => new[]
//         { backpack.Substring(0, backpack.Length / 2), backpack.Substring(backpack.Length / 2) })
//     .Select(backpack => backpack.First().Intersect(backpack.Last()).First()).ToList()
//     .Select(item => item.ToString().ToUpper() == item.ToString() ? item - 38 : item - 96)
//     .Sum();
//
// Console.WriteLine(backpacks);

var backpacks = File.ReadAllLines("../../../backpacks.txt");
var groupBadges = new List<char>();
for (var i = 0; i < backpacks.Length - 2; i += 3)
{
    var b = backpacks[i].Intersect(backpacks[i + 1]).Intersect(backpacks[i + 2]);
    groupBadges.AddRange(b);
}
var answer = groupBadges
    .Select(item => item.ToString().ToUpper() == item.ToString() ? item - 38 : item - 96)
    .Sum();

Console.WriteLine(answer);