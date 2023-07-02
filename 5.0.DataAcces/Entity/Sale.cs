

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _5._0.DataAcces.Entity
{
    [Table("Sale")]
    public class Sale
    {
        #region Properties
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string idSale { get; set; }
        public string idStudent { get; set; }
        public string idOpening { get; set; }       
        public string couponImg { get; set; }
        public Boolean saleState { get; set; }
        public int total { get; set; }
        #endregion

        #region Parent
        //Declarando lo Foreigkey de la entidad Venta
        [ForeignKey(nameof(idStudent))]
        public Student parentStudent { get; set; }

        [ForeignKey(nameof(idOpening))]
        public Opening parentOpening { get; set; }
        #endregion

        #region Child
        //Declarando inversa de relacion y hijo de la entidad Venta
        [InverseProperty("parentSale")]//Inversa de la relacion Venta -Venta_detalle
        public List<SaleDetail> childSaleDetail { get; set; }//Hijo de la entidad
        #endregion
    }
}
