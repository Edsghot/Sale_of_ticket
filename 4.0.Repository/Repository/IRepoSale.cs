using _0._0.DataTransfer.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _4._0.Repository.Repository
{
    public interface IRepoSale
    {
        public string Insert(DtoSale dto);
        public string subirImagen(IFormFile file, String id);
        public List<DtoSaleView> GetSale();
        public List<DtoSale> GetAll();
        public bool ExistsById(string idSale);
        public List<DtoSale> GetById(string idSale);
        public List<DtoSale> GetByIdStudent(string idStudent);
        public int Update(DtoSale dto);
        public int checkState(string id);
        public int Delete(string idSale);
        public void ModifyStateFail(string idSale);
    }
}