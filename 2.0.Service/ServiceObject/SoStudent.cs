using _0._0.DataTransfer.DTO;
using _2._0.Service.Generic;

namespace _2._0.Service.ServiceObject
{
    public class SoStudent: SoGeneric
    {
        public DtoStudent dtoStudent { get; set; }
        //codigo olor: El elemento propiedad "dtoStudent" que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declarar el elemento propiedad como que admite un valor NULL.
        public List<DtoStudent> listDtoStudent { get; set; }
        //codigo olor: El elemento propiedad "listDtoStudent" que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declarar el elemento propiedad como que admite un valor NULL.
    }

}
