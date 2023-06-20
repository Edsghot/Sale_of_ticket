using _0._0.DataTransfer.DTO;

namespace _4._0.Repository.Repository
{
    public interface IRepoAdministratorOpening
    {
        public int Insert(DtoAdministratorOpening dto);

        public List<DtoAdministratorOpening> GetAll();

        public bool ExistsById(string idAdministratorOpening);

        public List<DtoAdministratorOpening> GetById(string id);
    }
}