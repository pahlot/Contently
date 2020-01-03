using System.Collections.Generic;

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

        private string _path;
        public string Path {
            set { _path = value; }
            get
            {
                return (string.IsNullOrEmpty(_path) ? "/" : _path);
            }
        }

        public MenuItem Parent { get; set; }
        public IEnumerable<MenuItem> ChildMenuItems { get; set; }
    }
}
