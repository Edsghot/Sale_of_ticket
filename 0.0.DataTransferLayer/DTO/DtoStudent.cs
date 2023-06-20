

using System.ComponentModel.DataAnnotations;

namespace _0._0.DataTransfer.DTO
{
    public class DtoStudent
    {
        public string? idStudent{ get; set; }

        [Required(ErrorMessage = "El campo\"dni\" es requerido.")]
        [RegularExpression("^[0-9]{8}$", ErrorMessage = " \"El campo \"dni\\\" no cumple el formato correcto\"")]
        public string dni { get; set; }
         
        [Required(ErrorMessage = "El campo\"name\" es requerido.")]
        [RegularExpression("^([ÑA-Za-z]{1}[a-zñ]{1,50})(\\s[A-Za-z]{1}[a-zA-Z]{1,50})?$", ErrorMessage = " \"El campo \"name\" no cumple el formato correcto\"")]
        public string name { get; set; }

        [Required(ErrorMessage = "El campo\"lastName\" es requerido.")]
        [RegularExpression("^([ÑA-Za-z]{1}[a-zñ]{1,50})(\\s[A-Za-z]{1}[a-zA-Z]{1,50})$", ErrorMessage = " \"El campo \"lastName\" no cumple el formato correcto\"")]
        public string lastName { get; set; }

        [Required(ErrorMessage = "El campo\"condition\" es requerido.")]
        public Boolean condition { get; set; }

        [Required(ErrorMessage = "El campo\"school\" es requerido.")]
        public string school { get; set; }

        [Required(ErrorMessage = "El campo\"faculty\" es requerido.")]
        public string faculty { get; set; }

        [Required(ErrorMessage = "El campo\"disability\" es requerido.")]
        public Boolean disability { get; set; }

        [Required(ErrorMessage = "El campo\"phone\" es requerido.")]
        [RegularExpression("^(9[0-9]{8})$", ErrorMessage = " \"El campo \"phone\" no cumple el formato correcto\"")]
        public string phone { get; set; }

        [Required(ErrorMessage = "El campo\"address\" es requerido.")]
        [RegularExpression("^([A-Za-z0-9]\\.?\\s?){1,50}$", ErrorMessage = " \"El campo \"address\" no cumple el formato correcto\"")]
        public string address { get; set; }

        [Required(ErrorMessage = "El campo\"sex\" es requerido.")]
        [RegularExpression("^((M||F)||(m||f))$", ErrorMessage = " \"El campo \"sex\" no cumple el formato correcto\"")]
        public string sex { get; set; }
        
        public Boolean studentState { get; set; }
        public string password { get; set; }
        public string mail { get; set; }

        [Required(ErrorMessage = "El campo\"code\" es requerido.")]
        [RegularExpression("^[0-9]{6}$", ErrorMessage = " \"El campo \"code\" no cumple el formato correcto\"")]
        public string code { get; set; }        
        public List<DtoSale> childSale { get; set; }//Hijo de la entidad  
    }
}
