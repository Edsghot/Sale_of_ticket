

using System.ComponentModel.DataAnnotations;

namespace _0._0.DataTransfer.DTO
{
    public class DtoStudent
    {
        public string idStudent{ get; set; }

        public string profileImg { get; set; }

        public string dni { get; set; }
         
        public string name { get; set; }

        public string lastName { get; set; }
        public Boolean condition { get; set; }
        public string school { get; set; }
        public string faculty { get; set; }
        public Boolean disability { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string sex { get; set; }
        
        public Boolean studentState { get; set; }
        public string password { get; set; }
        public string mail { get; set; }
        public string code { get; set; }        
     //   public List<DtoSale> childSale { get; set; }//Hijo de la entidad  
    }
}
