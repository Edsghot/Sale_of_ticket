
using System.ComponentModel.DataAnnotations;

namespace _0._0.DataTransfer.DTO
{
    public class DtoOpening
    {
        public string idOpening { get; set; }

        [Required(ErrorMessage = "El campo\"priorityQuantity\" es requerido.")]
        public int priorityQuantity { get; set; }

        [Required(ErrorMessage = "El campo\"quantity\" es requerido.")]
        public int quantity { get; set; }

        [Required(ErrorMessage = "El campo\"openState\" es requerido.")]
        public Boolean openState { get; set; }

        [Required(ErrorMessage = "El campo\"idPeriod\" es requerido.")]
        public string idPeriod { get; set; }        

        #region Parent
     //   public DtoPeriod parentPeriod { get; set; }
        #endregion

        #region Child

       // public List<DtoAdministratorOpening> childAministratorOpening { get; set; }//Hijo de la entidad        

       // public List<DtoSale>? childSale { get; set; }//Hijo de la entidad        
        //codigo olor: La anotación para tipos de referencia que aceptan valores NULL solo debe usarse en el código dentro de un contexto de anotaciones "#nullable".
        #endregion
    }
}
