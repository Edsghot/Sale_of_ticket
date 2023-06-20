

using System.ComponentModel.DataAnnotations;

namespace _0._0.DataTransfer.DTO
{
    public class DtoSaleDetail
    {
        public string idSaleDetail { get; set; }

        [Required(ErrorMessage = "El campo\"idProduct\" es requerido.")]
        public string idProduct { get; set; }

        [Required(ErrorMessage = "El campo\"idSale\" es requerido.")]
        public string idSale { get; set; }

        [Required(ErrorMessage = "El campo\"date\" es requerido.")]
        public DateTime date { get; set; }

        [Required(ErrorMessage = "El campo\"total\" es requerido.")]
        public float total { get; set; }

        #region Parent   

        public DtoProduct parentProduct { get; set; }
        public DtoSale parentSale { get; set; }
        #endregion
    }
}
