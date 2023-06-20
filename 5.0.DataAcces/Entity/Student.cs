

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace _5._0.DataAcces.Entity
{
    [Table("Student")]
    public class Student
    {
        #region Properties
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string idStudent { get; set; }
        public string dni { get; set; }
        public string name { get; set; }
        public string lastName { get; set; }
        public Boolean condition { get; set; }
        public string school { get; set; }
        public string faculty { get; set; }
        public Boolean disability { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string sex { get; set; }
        public Boolean?studentState { get; set; }
        public string password { get; set; }
        public string mail { get; set; }
        public string code { get; set; }
        #endregion

        #region Child
        //Declarando inversa de relacion y hijo de la entidad Estudiante
        [InverseProperty("parentStudent")]//Inversa de la relacion Estudiante -Venta
        public List<Sale> childSale { get; set; }//Hijo de la entidad  
        #endregion
    }
}