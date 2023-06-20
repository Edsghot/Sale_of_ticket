using _0._0.DataTransfer.DTO;
using _4._0.Repository.Repository;
using _5._0.DataAcces.Connection;
using _5._0.DataAcces.Entity;

namespace _5._0.DataAcces.Query
{
    public class QOpening : IRepoOpening
    {
        //Query para realizar la inserción de apertura
        public int Insert(DtoOpening dto)
        {
            using DataBaseContext dbc = new();
            dbc.Openings.Add(InitAutoMapper.mapper.Map<Opening>(dto));
            return dbc.SaveChanges();
        }

        //Query para realizar el listado de la apertura
        public List<DtoOpening> GetAll()
        {
            using DataBaseContext dbc = new();
            return InitAutoMapper.mapper.Map<List<DtoOpening>>(dbc.Openings.OrderBy(ob => ob.idOpening).ToList());
        }

        //Query para verificar la existencia de la apertura por su id
        public bool ExistsById(string idOpening)
        {
            using DataBaseContext dbc = new();
            return dbc.Openings.Where(w => w.idOpening == idOpening).Any();
        }

        //Query para realizar el listado de las aperturas por su Id
        public List<DtoOpening> GetById(string id)
        {
            using DataBaseContext dbc = new();
            return InitAutoMapper.mapper.Map<List<DtoOpening>>(dbc.Openings.Where(w => w.idOpening == id).ToList());
        }

        //Query para realizar la eliminación de la apertura
        public int Delete(string idOpening)
        {
            using DataBaseContext dbc = new();
            Opening opening = dbc.Openings.Find(idOpening);

            if (opening  is null)
            {
                return 0;
            }

            dbc.Openings.Remove(opening);
            return dbc.SaveChanges();
        }

        //Query para realizar la actualización de la información de la apertura
        public int Update(DtoOpening dto)
        {
            using DataBaseContext dbc = new();
            Opening opening = dbc.Openings.Find(dto.idOpening);
            opening.priorityQuantity = dto.priorityQuantity;
            opening.quantity = dto.quantity;
            opening.openState = dto.openState;
            opening.idPeriod = dto.idPeriod;
            return dbc.SaveChanges();
        }
    }
}