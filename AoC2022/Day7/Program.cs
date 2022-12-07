using System.Drawing;
using Day7;

var input = File.ReadAllLines("../../../input.txt");
var dirWithDependency = new Dictionary<string, DirDependency>();
var currentPath = new PathManager();
foreach (var cmd in input)
{
    if (cmd.StartsWith("$ cd") && cmd != "$ cd ..")
    {
        currentPath.Down(cmd.Split(" ")[2]);
        dirWithDependency.Add(currentPath.Path, new DirDependency());
    }

    if (cmd == "$ cd ..")
    {
        currentPath.Up();
    }

    if (cmd.StartsWith("dir"))
    {
        dirWithDependency[currentPath.Path].Dependencies.Add(currentPath.Path + cmd.Split(" ")[1] + "/");
    }

    if (long.TryParse(cmd.Split(" ")[0], out var size))
    {
        dirWithDependency[currentPath.Path].Size += size;
    }
}

var dirSizes = new Dictionary<string, long>();

foreach (var dir in dirWithDependency)
{
    dirSizes.Add(dir.Key, dir.Value.Size + DirCalculator.CalculateDep(dirWithDependency, dir.Value.Dependencies));
}

Console.WriteLine(dirSizes.Values.Where(size => size <= 100_000).Sum());

var fileSystemMaxSize = 70000000;
var updateSize = 30000000;
var freeSpace = fileSystemMaxSize - dirSizes["/"];
var needToFree = updateSize - freeSpace;

var fileSizeToDeleate = dirSizes.Values.OrderBy(x => x).First(x => x >= needToFree);

Console.WriteLine(fileSizeToDeleate);