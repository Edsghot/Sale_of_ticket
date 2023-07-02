

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _5._0.DataAcces.Entity
{
    [Table("Opening")]
    public class Opening
    {
        #region Properties
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string idOpening { get; set; }
        public string idPeriod { get; set; }
        public int priorityQuantity { get; set; }
        public int quantity { get; set; }
        public Boolean openState { get; set; }
        #endregion

        #region Parent
        //Declarando lo Foreigkey de la entidad Administrador_Apertura
    //    [ForeignKey(nameof(idPeriod))]
     //   public Period parentPeriod { get; set; }
        #endregion

        #region Child
        //Declarando inversa de relacion y hijo de la entidad Apertura
     //   [InverseProperty("parentOpening")]//Inversa de la relacion Apertura -Administrador_Apertura
       // public List<AdministratorOpening> childAdministratorOpening { get; set; }//Hijo de la entidad
       
      //  [InverseProperty("parentOpening")]//Inversa de la relacion Apertura -Venta
      //  public List<Sale> childSale { get; set; }//Hijo de la entidad
        #endregion
    }
}
