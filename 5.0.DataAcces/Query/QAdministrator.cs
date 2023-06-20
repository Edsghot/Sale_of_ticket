using _0._0.DataTransfer.DTO;
using _4._0.Repository.Repository;
using _5._0.DataAcces.Connection;
using _5._0.DataAcces.Entity;

namespace _5._0.DataAcces.Query
{
    public class QAdministrator : IRepoAdministrator

    //hoolaa
    {
        //Query para realizar la inserción de Administradores        
        public int Insert(DtoAdministrator dto)
        {
            using DataBaseContext dbc = new();
            dbc.Administrators.Add(InitAutoMapper.mapper.Map<Administrator>(dto));
            return dbc.SaveChanges();
        }

        //Query para realizar el listado de los estudiantes de la base de datos
        public List<DtoAdministrator> GetAll()
        {
            using DataBaseContext dbc = new();
            return InitAutoMapper.mapper.Map<List<DtoAdministrator>>(dbc.Administrators.OrderBy(ob => ob.name).ToList());
        }

        //Query para realizar el listado de los estudiantes por su id de estudiante
        public List<DtoAdministrator> GetById(string id) 
        { 
            using DataBaseContext dbc = new();
            return InitAutoMapper.mapper.Map<List<DtoAdministrator>>(dbc.Administrators.Where(w => w.idAdministrator == id).ToList());
        }

        //Query para verificar la existencia del estudiante por su código
        public bool ExistsByCode(string code)
        {
            using DataBaseContext dbc = new();
            return dbc.Administrators.Where(w => w.code == code).Any();
        }
        
        //Query para verificar la existencia del estudiante por su id
        public bool ExistsById(string idAdministrator)
        {
            using DataBaseContext dbc = new();
            return dbc.Administrators.Where(w => w.idAdministrator == idAdministrator).Any();
        }

        //Query para realizar la eliminación del estudiante
        public int Delete(string idAdministrator)
        {
            using DataBaseContext dbc = new();
            Administrator Administrator = dbc.Administrators.Find(idAdministrator);

            if (Administrator is null)
            {
                return 0;
            }

            dbc.Administrators.Remove(Administrator);
            return dbc.SaveChanges();
        }


        public string Login(string mail, string password)
        {
            using DataBaseContext dbc = new();
            return dbc.Administrators.Where(w => w.mail == mail && w.password == password).Select(s => s.idAdministrator).FirstOrDefault();
        }

        //Query para realizar la actualización de la información del administrador
        public int Update(DtoAdministrator dto)
        {
            using DataBaseContext dbc = new();
            Administrator admin = dbc.Administrators.Find(dto.idAdministrator);
            admin.name = dto.name;
            admin.lastName = dto.lastName;
            admin.code = dto.code;
            admin.mail = dto.mail;
            admin.password = dto.password;
            admin.phone = dto.phone;
            admin.dni = dto.dni;
            return dbc.SaveChanges();
        }
    }
}