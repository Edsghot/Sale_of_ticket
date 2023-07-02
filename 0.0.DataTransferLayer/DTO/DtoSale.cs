

using System.ComponentModel.DataAnnotations;

namespace _0._0.DataTransfer.DTO
{
    public class DtoSale
    {
        public string idStudent { get; set; }

        [Required(ErrorMessage = "El campo\"idOpening\" es requerido.")]
        public string idOpening { get; set; }

        [Required(ErrorMessage = "El campo\"idSale\" es requerido.")]
        public string idSale { get; set; }

        [Required(ErrorMessage = "El campo\"couponImg\" es requerido.")]
        public string couponImg { get; set; }

        [Required(ErrorMessage = "El campo\"saleState\" es requerido.")]
        public Boolean saleState { get; set; }

        public int total { get; set; }


        #region Parent
        public DtoStudent parentStudent { get; set; }

        public DtoOpening parentOpening { get; set; }
        #endregion

        #region Child
        public List<DtoSaleDetail> childSaleDetail { get; set; }
        #endregion
    }
}
