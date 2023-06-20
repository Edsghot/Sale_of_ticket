using _0._0.DataTransfer.DTO;
using _4._0.Repository.Repository;
using _5._0.DataAcces.Connection;
using _5._0.DataAcces.Entity;

namespace _5._0.DataAcces.Query
{
    public class QAdministratorOpening : IRepoAdministratorOpening
    {
        //Query para realizar la inserción de Administrador apertura
        public int Insert(DtoAdministratorOpening dto)
        {
            using DataBaseContext dbc = new();
            dbc.AdministratorsOpening.Add(InitAutoMapper.mapper.Map<AdministratorOpening>(dto));
            return dbc.SaveChanges();
        }

        //Query para realizar el listado de la apertura
        public List<DtoAdministratorOpening> GetAll()
        {
            using DataBaseContext dbc = new();
            return InitAutoMapper.mapper.Map<List<DtoAdministratorOpening>>(dbc.AdministratorsOpening.OrderBy(ob => ob.idOpeningAdministrator).ToList());
        }

        
        public List<DtoAdministratorOpening> GetById(string id)
        {
            using DataBaseContext dbc = new();
            return InitAutoMapper.mapper.Map<List<DtoAdministratorOpening>>(dbc.AdministratorsOpening.Where(w => w.idOpeningAdministrator == id).ToList());
        }


        public bool ExistsById(string idAdministratorOpening)
        {
            using DataBaseContext dbc = new();
            return dbc.AdministratorsOpening.Where(w => w.idOpeningAdministrator == idAdministratorOpening).Any();
        }
    }
}
