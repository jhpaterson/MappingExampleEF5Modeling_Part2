using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MappingExample
{
    public class Right
    {
        public int RightId { get; set; }
        public string Name { get; set; }
        public Left Left { get; set; }
    }
}
