using _0._0.DataTransfer.DTO;
using _4._0.Repository.Repository;
using _5._0.DataAcces.Connection;
using _5._0.DataAcces.Entity;

namespace _5._0.DataAcces.Query
{
    public class QSale : IRepoSale
    {
        //Query para realizar la inserción de venta 
        public int Insert(DtoSale dto)
        {
            using DataBaseContext dbc = new();
            dbc.Sales.Add(InitAutoMapper.mapper.Map<Sale>(dto));
            return dbc.SaveChanges();
        }

        //Query para realizar el listado de las ventas realizadas
        public List<DtoSale> GetAll()
        {
            using DataBaseContext dbc = new();
            return InitAutoMapper.mapper.Map<List<DtoSale>>(dbc.Sales.OrderBy(ob => ob.idSale).ToList());
        }

        //Query para verificar la existencia de la venta por su id
        public bool ExistsById(string idSale)
        {
            using DataBaseContext dbc = new();
            return dbc.Sales.Where(w => w.idSale == idSale).Any();
        }

        //Query para realizar el listado de las ventas por del Id
        public List<DtoSale> GetById(string idSale)
        {
            using DataBaseContext dbc = new();
            return InitAutoMapper.mapper.Map<List<DtoSale>>(dbc.Sales.Where(w => w.idSale == idSale).ToList());
        }

        //Query para realizar la eliminación de la venta
        public int Delete(string idSale)
        {
            using DataBaseContext dbc = new();
            Sale sale = dbc.Sales.Find(idSale);

            if (sale is null)
            {
                return 0;
            }

            dbc.Sales.Remove(sale);
            return dbc.SaveChanges();
        }

        //Query para realizar la actualización de la información del producto
        public int Update(DtoSale dto)
        {
            using DataBaseContext dbc = new();
            Sale sale = dbc.Sales.Find(dto.idSale);
            sale.idStudent = dto.idStudent;
            sale.idOpening = dto.idOpening;
            sale.couponImg = dto.couponImg;
            sale.saleState = dto.saleState;
            return dbc.SaveChanges();
        }
    }
}