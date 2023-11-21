

using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace _0._0.DataTransfer.DTO
{
    public class DtoSale
    {

       
        public string idSale { get; set; }
        [Required(ErrorMessage = "El campo\"idStudent\" es requerido.")]
        public string idStudent { get; set; }

        [Required(ErrorMessage = "El campo\"idPeriod\" es requerido.")]
        public string idPeriod { get; set; }

        [Required(ErrorMessage = "El campo\"total\" es requerido.")]
        public int total { get; set; }
        public DateTime dateGo { get; set; }
        public string couponImg { get; set; }

        public int saleState { get; set; }
       


        #region Parent
       // public DtoStudent parentStudent { get; set; }

       // public DtoOpening parentOpening { get; set; }
        #endregion

        #region Child
       // public List<DtoSaleDetail> childSaleDetail { get; set; }
        #endregion
    }
}
