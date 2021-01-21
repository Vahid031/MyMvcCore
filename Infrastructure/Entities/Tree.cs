using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Infrastructure.Entities
{
    public class Tree
    {
        public int? id { get; set; }
        public string title { get; set; }
        public bool? @checked { get; set; }
        public string icon { get; set; }
        public bool? disabled { get; set; }
        public int? order { get; set; }
        public int? parentId { get; set; }
    }
}