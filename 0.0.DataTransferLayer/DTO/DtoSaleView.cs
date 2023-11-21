using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0._0.DataTransfer.DTO
{
    public class DtoSaleView
    {

        public string idSale { get; set; }
        public string couponImg { get; set; }
        public string code { get; set; }
        public string names { get; set; }
        public string school { get; set; }
        public int saleState { get; set; }

    }
}
