using Day10;

var displaySignal = File.ReadAllLines("../../../DisplaySignal.txt");

const int crtHeight = 6;
const int crtWidth = 40;
var registerX = 1;
var cycleCounter = 0;
var crt = new List<char>(240);
var finalImage = string.Empty;

// PART 1
// var signalSamples = new Dictionary<int, int>();

foreach (var command in displaySignal)
{
    var parsedCommand = SignalParser.Parse(command);

    for (int i = 0; i < parsedCommand.CycleDuration; i++)
    {
        var isSpriteOverPixel = registerX == cycleCounter % crtWidth
                                || registerX - 1 == cycleCounter % crtWidth
                                || registerX + 1 == cycleCounter % crtWidth;
        
        crt.Add(isSpriteOverPixel ? '#' : '.');
        cycleCounter++;

        // PART 1
        // if ((cycleCounter - 20) % 40 == 0)
        // {
        //     signalSamples.Add(cycleCounter, cycleCounter * registerX);
        // }
    }
    registerX += parsedCommand.AddValue;
}

// Printing to Img
var tmpImage = string.Join("", crt);
for (var i = 0; i < crtHeight; i++)
{
    finalImage += string.Concat(tmpImage.AsSpan(i * crtWidth, crtWidth), "\n");
}

Console.WriteLine(finalImage);
