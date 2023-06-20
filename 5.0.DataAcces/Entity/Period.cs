using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _5._0.DataAcces.Entity
{
    [Table("Period")]
    public class Period
    {
        #region Properties
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string idPeriod { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public string name { get; set; }
        #endregion

        #region Child
        //Declarando inversa de relacion y hijo de la entidad Periodo
        [InverseProperty("parentPeriod")]//Inversa de la relacion
        public List<Opening> childOpening { get; set; }//Hijo de la entidad
        #endregion
    }
}
