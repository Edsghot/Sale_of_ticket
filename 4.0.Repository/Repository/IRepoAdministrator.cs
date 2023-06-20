using _0._0.DataTransfer.DTO;

namespace _4._0.Repository.Repository
{
    public interface IRepoAdministrator
    {
        public int Insert(DtoAdministrator dto);

        public bool ExistsByCode(string code);
        
        public bool ExistsById(string idAdministrator);
        
        public List<DtoAdministrator> GetAll();
        
        public List<DtoAdministrator> GetById(string id);
        
        public int Update(DtoAdministrator dto);
        
        public int Delete(string idAdministrator);
        
        public string Login(string mail, string password);
    }
}