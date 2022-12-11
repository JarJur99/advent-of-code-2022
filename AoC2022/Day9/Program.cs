using Day9;

var headMotions = File.ReadAllLines("../../../HeadMotion.txt");

var head = new Coordinates();

var knot1 = new Coordinates();
head.AttachTail(knot1);

var knot2 = new Coordinates();
knot1.AttachTail(knot2);

var knot3 = new Coordinates();
knot2.AttachTail(knot3);

var knot4 = new Coordinates();
knot3.AttachTail(knot4);

var knot5 = new Coordinates();
knot4.AttachTail(knot5);

var knot6 = new Coordinates();
knot5.AttachTail(knot6);

var knot7 = new Coordinates();
knot6.AttachTail(knot7);

var knot8 = new Coordinates();
knot7.AttachTail(knot8);

var tail = new Coordinates();
knot8.AttachTail(tail);
// head.AttachTail(tail);


foreach (var motion in headMotions)
{
    var parsedMotion = motion.Split(' ');
    var direction = parsedMotion[0];
    var distance = int.Parse(parsedMotion[1]);
    
    for (var i = 0; i < distance; i++)
    {
        head.SimulateAll(direction);
    }
}

Console.WriteLine(tail.Visited.Keys.Count);


















