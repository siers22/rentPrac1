using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rentPrac1.Models
{
    public record ContractDto(int Id, string ClientName, string PropertyName, string ContractStartDate, string ContractEndDate, int RentTime);
    
}
