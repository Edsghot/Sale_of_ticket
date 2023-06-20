using _0._0.DataTransfer.DTO;
using _2._0.Service.Generic;
namespace _2._0.Service.ServiceObject
{
    public class SoAdministrator : SoGeneric
    {
        public DtoAdministrator dtoAdministrator { get; set; }
        //codigo olor: El elemento propiedad "dtoAdministrator" que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declarar el elemento propiedad como que admite un valor NULL.
        public List<DtoAdministrator> listDtoAdministrator { get; set; }
        //codigo olor: El elemento propiedad "listDtoAdministrator" que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declarar el elemento propiedad como que admite un valor NULL.
    }
}