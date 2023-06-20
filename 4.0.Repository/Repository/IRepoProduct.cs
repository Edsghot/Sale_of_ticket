using _0._0.DataTransfer.DTO;

namespace _4._0.Repository.Repository
{
    public interface IRepoProduct
    {
        public bool ExistsByName(string name);

        public bool ExistsById(string idProduct);

        public int Insert(DtoProduct dto);

        public List<DtoProduct> GetAll();

        public List<DtoProduct> GetById(string id);

        public int Update(DtoProduct dto);

        public int Delete(String idProduct);
    }
}