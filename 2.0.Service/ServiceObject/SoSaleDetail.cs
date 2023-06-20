using _0._0.DataTransfer.DTO;
using _2._0.Service.Generic;
namespace _2._0.Service.ServiceObject
{
    public class SoSaleDetail : SoGeneric
    {
        public DtoSaleDetail dtoSaleDetail { get; set; }
        //codigo olor: El elemento propiedad "dtoSaleDetail" que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declarar el elemento propiedad como que admite un valor NULL.
        public List<DtoSaleDetail> listDtoSaleDetail { get; set; }
        //codigo olor: El elemento propiedad "listDtoSaleDetail" que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declarar el elemento propiedad como que admite un valor NULL.
    }
}