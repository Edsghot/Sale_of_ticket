
using System.ComponentModel.DataAnnotations;

namespace _0._0.DataTransfer.DTO
{
    public class DtoAdministratorOpening
    {
        
        public string idOpeningAdministrator { get; set; }        

        [Required(ErrorMessage = "El campo\"idAdministrator\" es requerido.")]
        public string idAdministrator { get; set; }

        [Required(ErrorMessage = "El campo\"idOpening\" es requerido.")]
        public string idOpening{ get; set; }

        #region Parent
        public DtoAdministrator parentAdministrator { get; set; }
        public DtoOpening parentOpening { get; set; }
        #endregion

    }
}
