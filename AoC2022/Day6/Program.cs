var signal = File.ReadAllText("../../../signal.txt");
// change to 4 to complete part 1
var seqLength = 14;
for (var i = 0; i < signal.Length - seqLength; i++)
{
    if (signal.Substring(i, seqLength).Distinct().Count() == seqLength)
    {
        Console.WriteLine(i + seqLength);
        break;
    }
}
