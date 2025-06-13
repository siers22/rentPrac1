using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rentPrac1.Models
{
    public partial class PropertyDbo
    {
        public string Name { get; set; } = null!;

        public int TypeId { get; set; }

        public string Address { get; set; } = null!;

        public int Price { get; set; }

        
    }
}
