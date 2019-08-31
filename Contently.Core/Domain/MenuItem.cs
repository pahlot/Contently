namespace Contently.Core.Domain
{
    /// <summary>
    /// Represents a basic FLAT menu structure
    /// TODO: Think about how this might work in a hierarchy by parsing the paths
    ///     This could be tricky as /foo/bar might not necessarily mean /foo exists
    /// </summary>
    public class MenuItem
    {
        public string Name { get; set; }
        public string Path { get; set; }
    }
}
