using System;
using System.Collections.Generic;
using System.Text;

namespace ToDo.Models
{
    public class LookupItem : Entity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Tag { get; set; }
        public short SortIndex { get; set; }
    }
}
