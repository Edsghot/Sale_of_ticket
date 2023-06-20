

using System.ComponentModel.DataAnnotations;

namespace _0._0.DataTransfer.DTO
{
    public class DtoProduct
    {
        public string idProduct { get; set; }

        [Required(ErrorMessage = "El campo\"name\" es requerido.")]
        public string name { get; set; }

        [Required(ErrorMessage = "El campo\"price\" es requerido.")]
        public int price { get; set; }

        #region Child
        public List<DtoSaleDetail>? childSaleDetail { get; set; }//Hijo de la entidad
        //codigo olor: La anotación para tipos de referencia que aceptan valores NULL solo debe usarse en el código dentro de un contexto de anotaciones "#nullable".
        #endregion
    }
}
