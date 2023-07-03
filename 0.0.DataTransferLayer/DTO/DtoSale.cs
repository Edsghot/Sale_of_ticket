

using System.ComponentModel.DataAnnotations;

namespace _0._0.DataTransfer.DTO
{
    public class DtoSale
    {

       
        public string idSale { get; set; }
        [Required(ErrorMessage = "El campo\"idStudent\" es requerido.")]
        public string idStudent { get; set; }

        [Required(ErrorMessage = "El campo\"idOpening\" es requerido.")]
        public string idOpening { get; set; }


        [Required(ErrorMessage = "El campo\"idSaleDetail\" es requerido.")]
        public string idSaleDetail { get; set; }

        [Required(ErrorMessage = "El campo\"couponImg\" es requerido.")]
        public string couponImg { get; set; }

        public Boolean saleState { get; set; }
        [Required(ErrorMessage = "El campo\"total\" es requerido.")]

        public int total { get; set; }


        #region Parent
       // public DtoStudent parentStudent { get; set; }

       // public DtoOpening parentOpening { get; set; }
        #endregion

        #region Child
       // public List<DtoSaleDetail> childSaleDetail { get; set; }
        #endregion
    }
}
