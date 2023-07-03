
using System.ComponentModel.DataAnnotations;

namespace _0._0.DataTransfer.DTO
{
    public class DtoAdministrator
    {        
        public string idAdministrator { get; set; }        

        [Required(ErrorMessage = "El campo\"name\" es requerido.")]
        public string name { get; set; }

        [Required(ErrorMessage = "El campo\"lastName\" es requerido.")]
        public string lastName { get; set; }

        [Required(ErrorMessage = "El campo\"code\" es requerido.")]
        public string code { get; set; }

        [Required(ErrorMessage = "El campo\"mail\" es requerido.")]
        public string mail { get; set; }

        [Required(ErrorMessage = "El campo\"password\" es requerido.")]
        public string password { get; set; }

        [Required(ErrorMessage = "El campo\"phone\" es requerido.")]
        public string phone { get; set; }

        [Required(ErrorMessage = "El campo\"dni\" es requerido.")]
        public string dni { get; set; }

        #region Child
      //  public List<DtoAdministratorOpening> childAdministratorOpening { get; set; }//Hijo de la entidad        
        #endregion
    }
}
