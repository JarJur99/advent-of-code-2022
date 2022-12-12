namespace Day11;

public class Monkey
{
    public List<ulong> Items { get; set; }
    public ulong DivisionTest { get; set; }
    public int TrueMonkeyId { get; set; }
    public int FalseMonkeyId { get; set; }
    public string WorryOperator { get; set; }
    public string WorryOperand { get; set; }

    public long InspectedItems { get; set; }

    public Monkey(string monkeyEntry)
    {
        var monkeyAttr = monkeyEntry.Split("\n ");
        var monkeyOperation = monkeyAttr[2].Split(" ");
        Items = new List<ulong>();
        Items.AddRange(monkeyAttr[1].Split(":").Last().Split(", ").Select(ulong.Parse));
        
        WorryOperand = monkeyOperation.Last();
        WorryOperator = monkeyOperation[^2];
        DivisionTest = ulong.Parse(monkeyAttr[3].Split(" ").Last());
        TrueMonkeyId = int.Parse(monkeyAttr[4].Last().ToString());
        FalseMonkeyId = int.Parse(monkeyAttr[5].Last().ToString());
        InspectedItems = 0;
    }

    public ulong InspectItem(ulong item)
    {
        var operand = GetOperand(item);
        return PerformOperation(item, operand);
    }

    private ulong GetOperand(ulong item)
    {
        return ulong.TryParse(WorryOperand, out var operand) ? operand : item;
    }

    private ulong PerformOperation(ulong item, ulong operand)
    {
        switch (WorryOperator)
        {
            case "+":
                return item + operand;
            case "*":
                return item * operand;
            default:
                throw new NotImplementedException("Not supported operation type");
        }
    }
    
}