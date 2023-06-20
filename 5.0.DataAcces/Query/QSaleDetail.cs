using _0._0.DataTransfer.DTO;
using _4._0.Repository.Repository;
using _5._0.DataAcces.Connection;
using _5._0.DataAcces.Entity;

namespace _5._0.DataAcces.Query
{
    public class QSaleDetail : IRepoSaleDetail
    {
        //Query para realizar la inserción del detalle de la venta
        public int Insert(DtoSaleDetail dto)
        {
            using DataBaseContext dbc = new();
            dbc.SaleDetails.Add(InitAutoMapper.mapper.Map<SaleDetail>(dto));
            return dbc.SaveChanges();
        }

        //Query para realizar el listado de los detalles de la venta
        public List<DtoSaleDetail> GetAll()
        {
            using DataBaseContext dbc = new();
            return InitAutoMapper.mapper.Map<List<DtoSaleDetail>>(dbc.SaleDetails.OrderBy(ob => ob.idSaleDetail).ToList());
        }

        //Query para verificar la existencia del detalle de la venta
        public bool ExistsById(string idSaleDetail)
        {
            using DataBaseContext dbc = new();
            return dbc.SaleDetails.Where(w => w.idSaleDetail == idSaleDetail).Any();
        }

        //Query para realizar el listado por el id
        public List<DtoSaleDetail> GetById(string id)
        {
            using DataBaseContext dbc = new();
            return InitAutoMapper.mapper.Map<List<DtoSaleDetail>>(dbc.SaleDetails.Where(w => w.idSaleDetail == id).ToList());
        }

        //Query para realizar la eliminación del producto
        public int Delete(string idSaleDetail)
        {
            using DataBaseContext dbc = new();

            SaleDetail detail = dbc.SaleDetails.Find(idSaleDetail);

            if (detail is null)
            {
                return 0;
            }

            dbc.SaleDetails.Remove(detail);
            return dbc.SaveChanges();
        }

        //Query para realizar la actualización de la información del producto
        public int Update(DtoSaleDetail dto)
        {
            using DataBaseContext dbc = new();
            SaleDetail detail = dbc.SaleDetails.Find(dto.idSaleDetail);
            detail.idProduct = dto.idProduct;
            detail.idSale = dto.idSale;
            detail.date = dto.date;
            detail.total = dto.total;
            return dbc.SaveChanges();
        }
    }
}