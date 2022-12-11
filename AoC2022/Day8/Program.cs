using Day8;

var forestByRows = File.ReadAllLines("../../../forest.txt");
var borderTree = (forestByRows.Length * 2 + forestByRows[0].Length * 2) - 4;
var forestByCols = TimberElf.RotateForest(forestByRows);

// Part 1
// var visibleTreesRows = 0;
// for (var i = 1; i < forestByRows.Length - 1; i++)
// {
//     var row = forestByRows[i];
//     for (var j = 1; j < row.Length - 1; j++)
//     {
//         var col = forestByCols[j];
//         if (TimberElf.IsTreeVisible(j, row) || TimberElf.IsTreeVisible(i, col))
//             visibleTreesRows++;
//     }
// }

var bestViewScore = 0;
for (var i = 1; i < forestByRows.Length; i++)
{
    var row = forestByRows[i];
    for (var j = 1; j < row.Length; j++)
    {
        var col = forestByCols[j];
        var treeScore = TimberElf.CalcTreeViewScore(j, row) * TimberElf.CalcTreeViewScore(i, col);
        if ( treeScore > bestViewScore)
            bestViewScore = treeScore;
    }
}

Console.WriteLine(bestViewScore);