using Day4;

var cleanupIds = File.ReadAllLines("../../../cleanupIds.txt");

var partiallyContained = 0;
foreach (var rangeIds in cleanupIds)
{
    var (firstPair, secondPair) = PairExtractor.Extract(rangeIds, ',', '-');

    if (firstPair[0] > secondPair[1] || firstPair[1] < secondPair[0])
        continue;
    partiallyContained++;
}

Console.WriteLine(partiallyContained);
