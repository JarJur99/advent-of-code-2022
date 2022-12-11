namespace Day8;

public static class TimberElf
{
    public static List<string> RotateForest(IEnumerable<string> forest)
    {
        var rotetedForest = new List<string>();

        foreach (var treeRow in forest)
        {
            for (var i = 0; i < treeRow.Length; i++)
            {
                var tree = treeRow[i];
                if (rotetedForest.Count != treeRow.Length)
                    rotetedForest.Add(tree.ToString());
                else
                    rotetedForest[i] += tree;
            }
        }

        return rotetedForest;
    }
    public static bool IsTreeVisible(int treePos, string treeLine)
    {
        var tree = int.Parse(treeLine[treePos].ToString());
        var maxBeforeTree = treeLine.Substring(0, treePos).Select(tree => int.Parse(tree.ToString())).Max();
        var maxAfterTree = treeLine.Substring(treePos + 1).Select(tree => int.Parse(tree.ToString())).Max();
        return tree > maxBeforeTree || tree > maxAfterTree;
    }

    public static int CalcTreeViewScore(int treePos, string treeLine)
    {
        var currentTree = int.Parse(treeLine[treePos].ToString());
        var viewBeforeTree = treeLine
            .Substring(0, treePos)
            .Select(tree => int.Parse(tree.ToString()))
            .Reverse()
            .ToList();
        var viewAfterTree = treeLine
            .Substring(treePos + 1)
            .Select(tree => int.Parse(tree.ToString()))
            .ToList();
        
        var beforeScore = 0;
        var afterScore = 0;
        foreach (var tree in viewBeforeTree)
        {
            beforeScore++;
            if (currentTree <= tree)
                break;
        }
        
        foreach (var tree in viewAfterTree)
        {
            afterScore++;
            if (currentTree <= tree)
                break;
        }

        return beforeScore * afterScore;
    }
}