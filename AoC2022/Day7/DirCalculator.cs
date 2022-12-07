namespace Day7;

public static class DirCalculator
{
    public static long CalculateDep(Dictionary<string, DirDependency> dirInfo, List<string> currentDirDep)
    {
        long depSize = 0;
        foreach (var dep in currentDirDep)
        {
            depSize += dirInfo[dep].Size + CalculateDep(dirInfo, dirInfo[dep].Dependencies);
        }

        return depSize;
    }
}