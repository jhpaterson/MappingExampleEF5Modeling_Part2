using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MappingExample
{
    public class Left
    {
        public int LeftId { get; set; }
        public string Name { get; set; }
        public Right Right { get; set; }
    }
}
