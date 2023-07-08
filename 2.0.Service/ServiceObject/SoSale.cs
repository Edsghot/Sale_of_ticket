using _0._0.DataTransfer.DTO;
using _2._0.Service.Generic;
namespace _2._0.Service.ServiceObject
{
    public class SoSale:SoGeneric
    {        
        public DtoSale dtoSale { get; set; }
        //codigo olor: El elemento propiedad "dtoSale" que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declarar el elemento propiedad como que admite un valor NULL.
        public List<DtoSale> listDtoSale { get; set; }
        public List<string> listGetSale { get; set; }
        //codigo olor: El elemento propiedad "listDtoSale" que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declarar el elemento propiedad como que admite un valor NULL.
    }
}