using Newtonsoft.Json;
using System.Collections.Generic;

namespace ViewModels.Entities
{
    public class Paging
    {
        public Paging()
        {
            order = "";
            filter = "";
            values = new List<object>();
            searchItems = new Dictionary<string, object>();
        }

        public int? pageNumber { get; set; }

        public int? pageSize { get; set; }

        public string order { get; set; }

        public string group { get; set; }

        public int rowCount { get; set; }

        public Dictionary<string, object> searchItems { get; set; }

        public List<object> values;

        public string filter;
    }
}