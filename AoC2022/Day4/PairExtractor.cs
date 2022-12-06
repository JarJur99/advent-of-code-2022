namespace Day4;

public static class PairExtractor
{
    public static Tuple<List<int>, List<int>> Extract(string pair, char pairSeparator, char valSeparator)
    {
        var pairs = pair.Split(pairSeparator);
        var firstPair = pairs[0].Split(valSeparator).Select(int.Parse).ToList();
        var secondPair = pairs[1].Split(valSeparator).Select(int.Parse).ToList();
        return new Tuple<List<int>, List<int>>(firstPair, secondPair);
    }
}