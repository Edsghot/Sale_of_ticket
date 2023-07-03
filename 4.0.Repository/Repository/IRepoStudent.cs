using _0._0.DataTransfer.DTO;

namespace _4._0.Repository.Repository
{
    public interface IRepoStudent
    {

    
        public int Insert(DtoStudent dto);
        
        public bool ExistsByCode(string code);
        
        public bool ExistsById(string idStudent);
        
        public List<DtoStudent> GetAll();
        
        public List<DtoStudent> GetById(string id);
        
        public int Update(DtoStudent dto);
        
        public int Delete(string idStudent);
        
        public string Login(string mail, string password);
    }
}