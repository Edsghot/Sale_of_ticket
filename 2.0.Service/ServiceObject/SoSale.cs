using _0._0.DataTransfer.DTO;
using _2._0.Service.Generic;
namespace _2._0.Service.ServiceObject
{
    public class SoSale:SoGeneric
    {
        public DtoSale dtoSale { get; set; } = default!;
        public List<DtoSale> listDtoSale { get; set; } = default!;
        public List<string> listGetSale { get; set; } = default!;
    }
}