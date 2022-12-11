namespace Day9;

public class Coordinates
{
    public int i { get; set; }
    public int j { get; set; }

    public Coordinates()
    {
        i = 0;
        j = 0;
    }

    public Coordinates(Coordinates other)
    {
        i = other.i;
        j = other.j;
    }

    public void Move(string direction)
    {
        switch (direction)
        {
            case "R":
                j++;
                break;
            case "L":
                j--;
                break;
            case "U":
                i++;
                break;
            case "D":
                i--;
                break;
        }
    }

    public void MoveTo(Coordinates other)
    {
        i = other.i;
        j = other.j;
    }

    public bool IsInRange(Coordinates other, int range)
    {
        return Math.Abs(i - other.i) <= range && Math.Abs(j - other.j) <= range;
    }

    public bool IsDiagonalTo(Coordinates other)
    {
        return Math.Abs(i - other.i) == 1 && Math.Abs(j - other.j) == 1;
    }

    public override string ToString()
    {
        return $"{i},{j}";
    }
}