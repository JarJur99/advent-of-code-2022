using Day9;

var headMotions = File.ReadAllLines("../../../HeadMotion.txt");

var head = new Coordinates();
var tail = new Coordinates();
var visited = new Dictionary<string, int> { { tail.ToString(), 1 } };

foreach (var motion in headMotions)
{
    var parsedMotion = motion.Split(' ');
    var direction = parsedMotion[0];
    var distance = int.Parse(parsedMotion[1]);
    
    for (var i = 0; i < distance; i++)
    {
        var wasDiagonal = head.IsDiagonalTo(tail);
        var oldHead = new Coordinates(head);

        head.Move(direction);
        if (!head.IsInRange(tail, 1) && !wasDiagonal)
        {
            tail.Move(direction);
        }

        if (!head.IsInRange(tail, 1) && wasDiagonal)
        {
            tail.MoveTo(oldHead);
        }
        
        if (!visited.ContainsKey(tail.ToString()))
        {
            visited.Add(tail.ToString(), 0);
        }

        visited[tail.ToString()]++;
    }
}

Console.WriteLine(visited.Keys.Count);