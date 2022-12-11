namespace Day10;

public static class SignalParser
{
    public static ProgramInstruction Parse(string command)
    {
        var parsedCommand = command.Split(" ");
        int seqDuration = CommandSeqDuration(parsedCommand[0]);
        
        return seqDuration == 1
            ? new ProgramInstruction(seqDuration, 0)
            : new ProgramInstruction(seqDuration, int.Parse(parsedCommand[1]));
    }

    private static int CommandSeqDuration(string command)
    {
        switch (command)
        {
            case "noop":
                return 1;
            case "addx":
                return 2;
            default:
                throw new ArgumentException($"Don't understand command:{command}");
        }
    }
}