namespace Day7;

public class DirDependency
{
    public long Size { get; set; }
    public List<string> Dependencies { get; set; }

    public DirDependency()
    {
        Dependencies = new List<string>();
    }
}