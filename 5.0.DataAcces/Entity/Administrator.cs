
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _5._0.DataAcces.Entity
{
    [Table("Administrator")]
    public class Administrator
    {
        #region Properties
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string idAdministrator { get; set; }
        public string name { get; set; }
        public string lastName { get; set; }
        public string code { get; set; }
        public string mail { get; set; }
        public string password { get; set; }
        public string phone { get; set; }
        public string dni { get; set; }
        #endregion

        #region Child
        //Declarando inversa de relacion y hijo de la entidad Administrador
        [InverseProperty("parentAdministrator")]//Inversa de la relacion
        public List<AdministratorOpening> childAdministratorOpening { get; set; }//Hijo de la entidad
        #endregion

    }
}
