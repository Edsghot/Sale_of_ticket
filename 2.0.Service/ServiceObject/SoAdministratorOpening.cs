using _0._0.DataTransfer.DTO;
using _2._0.Service.Generic;
namespace _2._0.Service.ServiceObject
{
    public class SoAdministratorOpening : SoGeneric
    {
        public DtoAdministratorOpening dtoAdministratorOpening { get; set; }
        //codigo olor: El elemento propiedad "dtoAdministratorOpening" que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declarar el elemento propiedad como que admite un valor NULL.
        public List<DtoAdministratorOpening> listDtoAdministratorOpening { get; set; }
        //codigo olor: El elemento propiedad "listDtoAdministratorOpening" que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declarar el elemento propiedad como que admite un valor NULL.
    }
}