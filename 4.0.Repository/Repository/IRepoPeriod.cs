using _0._0.DataTransfer.DTO;

namespace _4._0.Repository.Repository
{
    public interface IRepoPeriod
    {
        public int Insert(DtoPeriod dto);

        public List<DtoPeriod> GetAll();

        public int Delete(string idPeriod);

        public List<DtoPeriod> GetById(string id);

        public int Update(DtoPeriod dto);

        public bool ExistsById(string idPeriod);
    }
}