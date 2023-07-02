
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _5._0.DataAcces.Entity
{
    public class AdministratorOpening
    {
        #region Properties
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string idOpeningAdministrator { get; set; }
        public string idAdministrator { get; set; }
        public string idOpening { get; set; }
        #endregion

        #region Parent
        //Declarando lo Foreigkey de la entidad Administrador_Apertura
       // [ForeignKey(nameof(idAdministrator))]
       // public Administrator parentAdministrator { get; set; }
       
     //   [ForeignKey(nameof(idOpening))]
      //  public Opening parentOpening { get; set; }
        #endregion
    }
}
