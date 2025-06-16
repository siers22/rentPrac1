using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rentPrac1.Models
{
    public record PropertyDto(int Id, string Nmae, string TypeName, string address, int price);
}
