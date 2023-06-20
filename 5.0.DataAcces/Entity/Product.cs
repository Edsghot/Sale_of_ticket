

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _5._0.DataAcces.Entity
{
    [Table("Product")]
    public class Product
    {
        #region Properties
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string idProduct { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        #endregion

        #region Child
        //Declarando inversa de relacion y hijo de la entidad Producto
        [InverseProperty("parentProduct")]//Inversa de la relacion Producto - Venta_detalle
        public List<SaleDetail> childSaleDetail { get; set; }//Hijo de la entidad
        #endregion
    }
}
