

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _5._0.DataAcces.Entity
{
    [Table("SaleDetail")]
    public class SaleDetail
    {
        #region Properties
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string idSaleDetail { get; set; }
        public string idProduct { get; set; }
        public DateTime date { get; set; }
        #endregion

        #region Parent
        //Declarando lo Foreigkey de la entidad Venta_detalle
   //     [ForeignKey(nameof(idProduct))]
   //     public Product parentProduct { get; set; }

        #endregion
    }
}
