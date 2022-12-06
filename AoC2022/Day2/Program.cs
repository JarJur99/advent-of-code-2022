var shapeScore = new Dictionary<char, int>()
{
    {'A', 1}, // A rock
    {'B', 2}, // B paper
    {'C', 3} // C scissors
};

var scoreBoard = new Dictionary<char, int>()
{
    { 'X', 0 }, // Lose
    { 'Y', 3 }, // Draw
    { 'Z', 6 } // Win
};

var winPower = new Dictionary<char, char>()
{
    { 'A', 'C' }, // rock wins with scissors etc..
    { 'B', 'A' },
    { 'C', 'B' }
};

int score = 0;
var strategyGuide = File.ReadAllLines("../../../gameData.txt");

foreach (var game in strategyGuide)
{
    var enemyMove = game.First();
    var outcome = game.Last();

    var myMoveScore = shapeScore[enemyMove]; // Default - Draw
    if (outcome == 'X') // Lose
        myMoveScore = shapeScore[winPower[enemyMove]];
    if (outcome == 'Z') // Win
        myMoveScore = shapeScore[winPower[winPower[enemyMove]]];

    score += scoreBoard[outcome] + myMoveScore;
}

Console.WriteLine(score);
