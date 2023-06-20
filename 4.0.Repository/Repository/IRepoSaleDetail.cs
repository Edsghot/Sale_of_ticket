using _0._0.DataTransfer.DTO;

namespace _4._0.Repository.Repository
{
    public interface IRepoSaleDetail
    {
        public int Insert(DtoSaleDetail dto);

        public List<DtoSaleDetail> GetAll();

        public bool ExistsById(string idSaleDetail);

        public List<DtoSaleDetail> GetById(string id);

        public int Update(DtoSaleDetail dto);

        public int Delete(string idSaleDetail);
    }
}