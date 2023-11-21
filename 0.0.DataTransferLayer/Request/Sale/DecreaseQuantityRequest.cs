using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0._0.DataTransfer.Request.Sale;

public record DecreaseQuantityRequest
{
    public string? idOpening { get; set; }
    public string? idSale { get; set; }

}
