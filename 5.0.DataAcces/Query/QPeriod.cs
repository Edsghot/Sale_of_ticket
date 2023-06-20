using _0._0.DataTransfer.DTO;
using _4._0.Repository.Repository;
using _5._0.DataAcces.Connection;
using _5._0.DataAcces.Entity;

namespace _5._0.DataAcces.Query
{
    public class QPeriod : IRepoPeriod
    {
        //Query para realizar la inserción de la duración del comedor
        public int Insert(DtoPeriod dto)
        {
            using DataBaseContext dbc = new();
            dbc.Periods.Add(InitAutoMapper.mapper.Map<Period>(dto));
            return dbc.SaveChanges();
        }

        //Query para realizar el listado de los periodos
        public List<DtoPeriod> GetAll()
        {
            using DataBaseContext dbc = new();
            return InitAutoMapper.mapper.Map<List<DtoPeriod>>(dbc.Periods.OrderBy(ob => ob.idPeriod).ToList());
        }

        //Query para verificar la existencia del periodo por su id
        public bool ExistsById(string idPeriod)
        {
            using DataBaseContext dbc = new();
            return dbc.Periods.Where(w => w.idPeriod == idPeriod).Any();
        }

        //Query para realizar el listado de lso periodos por su id
        public List<DtoPeriod> GetById(string id)
        {
            using DataBaseContext dbc = new();
            return InitAutoMapper.mapper.Map<List<DtoPeriod>>(dbc.Periods.Where(w => w.idPeriod == id).ToList());
        }

        //Query para realizar la eliminación del periodo
        public int Delete(string idPeriod)
        {
            using DataBaseContext dbc = new();
            Period period = dbc.Periods.Find(idPeriod);

            if (period is null)
            {
                return 0;
            }

            dbc.Periods.Remove(period);
            return dbc.SaveChanges();
        }

        //Query para realizar la actualización de la información del periodo
        public int Update(DtoPeriod dto)
        {
            using DataBaseContext dbc = new();
            var period = dbc.Periods.Find(dto.idPeriod);
            period.startDate = dto.startDate;
            period.endDate = dto.endDate;
            period.name = dto.name;
            return dbc.SaveChanges();
        }
    }
}