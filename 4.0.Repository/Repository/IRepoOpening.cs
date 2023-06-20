using _0._0.DataTransfer.DTO;

namespace _4._0.Repository.Repository
{
    public interface IRepoOpening
    {
        public int Insert(DtoOpening dto);

        public List<DtoOpening> GetAll();

        public bool ExistsById(string idOpening);

        public List<DtoOpening> GetById(string id);

        public int Update(DtoOpening dto);

        public int Delete(string idOpening);
    }
}