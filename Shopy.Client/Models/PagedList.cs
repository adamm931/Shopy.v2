using System.Collections.Generic;

namespace Shopy.Client.Models
{
    public class PagedList<T> : List<T>
    {
        public int Index { get; set; }

        public int Size { get; set; }

        public int TotalCount { get; set; }
    }
}
