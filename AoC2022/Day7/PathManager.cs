namespace Day7;

public class PathManager
{
    public string Path { get; set; }

    public PathManager()
    {
        this.Path = "/";
    }

    public void Up()
    {
        var deepestDir = this.Path.Split("/", StringSplitOptions.RemoveEmptyEntries).Last();
        var idx = this.Path.LastIndexOf(deepestDir);
        this.Path = this.Path.Substring(0, idx);
    }

    public void Down(string dirName)
    {
        if (dirName == "/")
            return;
        this.Path += dirName + "/";
    }

    public override string ToString()
    {
        return this.Path;
    }
}