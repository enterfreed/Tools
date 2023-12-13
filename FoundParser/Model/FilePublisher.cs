namespace FoundParser;

public class FilePublisher
{
    public List<string> PathElems = new ();
    public int LineAddress;
    public int Sourceline;

    //public FilePublisher(string rootPath)
    //{
        //PathElems.Add(rootPath);
   // }
   public string GetFullPath()
    {
        return Path.Combine(PathElems.ToArray());
    }
}