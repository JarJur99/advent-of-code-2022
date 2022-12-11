namespace Day9;

public class Coordinates
{
    public int i { get; set; }
    public int j { get; set; }
    public Dictionary<string, int> Visited { get; set; }
    
    public Coordinates? Tail { get; set; }

    public Coordinates()
    {
        i = 0;
        j = 0;
        Visited = new Dictionary<string, int> { { $"{i},{j}", 1 } };
    }

    public Coordinates(Coordinates other)
    {
        i = other.i;
        j = other.j;
        Tail = other?.Tail;
    }
    
    public void AttachTail(Coordinates tail)
    {
        Tail = tail;
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

    public void SimulateAll(string direction, Coordinates? diagonalMove = null)
    {
        var wasDiagonal = false;
        if (Tail is not null)
        {
            wasDiagonal = IsDiagonalTo(Tail);
        }
        
        var oldHead = new Coordinates(this);

        if (diagonalMove is not null)
        {
            MoveTo(diagonalMove);
        }
        else
        {
            Move(direction);
        }
        
        if (!IsInRange(Tail, 1) && !wasDiagonal)
        {
            if (Tail.Tail is not null)
            {
                Tail.SimulateAll(direction);
            }
            else
            {
                Tail.Move(direction);
            }
        }

        if (!IsInRange(Tail, 1) && wasDiagonal)
        {
            if (Tail.Tail is not null)
            {
                Tail.SimulateAll(direction, oldHead);
            }
            else
            {
                Tail.MoveTo(oldHead);
            }
        }
        
        Tail.MarkVisited();
    }

    public bool IsInRange(Coordinates other, int range)
    {
        return Math.Abs(i - other.i) <= range && Math.Abs(j - other.j) <= range;
    }

    public bool IsDiagonalTo(Coordinates other)
    {
        return Math.Abs(i - other.i) == 1 && Math.Abs(j - other.j) == 1;
    }

    public void MarkVisited()
    {
        if (!Visited.ContainsKey(ToString()))
        {
            Visited.Add(ToString(), 0);
        }

        Visited[ToString()]++;
    }

    public override string ToString()
    {
        return $"{i},{j}";
    }
}