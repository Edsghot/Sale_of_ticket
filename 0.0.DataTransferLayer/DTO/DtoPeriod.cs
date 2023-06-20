

using System.ComponentModel.DataAnnotations;

namespace _0._0.DataTransfer.DTO
{
    public class DtoPeriod
    {
        [Required(ErrorMessage = "El campo\"idPeriod\" es requerido.")]
        public string idPeriod { get; set; }
        [Required(ErrorMessage = "El campo\"startDate\" es requerido.")]
        public DateTime startDate { get; set; }
        [Required(ErrorMessage = "El campo\"endDate\" es requerido.")]
        public DateTime endDate { get; set; }
        [Required(ErrorMessage = "El campo\"name\" es requerido.")]
        public string name { get; set; }  
        #region Child
        public List<DtoOpening> childOpening { get; set; }//Hijo de la entidad
        #endregion
    }
}
