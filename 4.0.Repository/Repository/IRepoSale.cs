using _0._0.DataTransfer.DTO;
using Microsoft.AspNetCore.Http;

namespace _4._0.Repository.Repository
{
    public interface IRepoSale
    {
        public int Insert(DtoSale dto);

        public List<DtoSale> GetAll();

        public bool ExistsById(string idSale);

        public List<DtoSale> GetById(string idSale);

        public int Update(DtoSale dto);

        public int Delete(string idSale);
    }
}