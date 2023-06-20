using _0._0.DataTransfer.DTO;
using _4._0.Repository.Repository;
using _5._0.DataAcces.Connection;
using _5._0.DataAcces.Entity;

namespace _5._0.DataAcces.Query
{
    public class QProduct : IRepoProduct
    {
        //Query para realizar la inserción del producto
        public int Insert(DtoProduct dto)
        {
            using DataBaseContext dbc = new();
            dbc.Products.Add(InitAutoMapper.mapper.Map<Product>(dto));
            return dbc.SaveChanges();
        }

        //Query para realizar el listado de los productos
        public List<DtoProduct> GetAll()
        {
            using DataBaseContext dbc = new();
            return InitAutoMapper.mapper.Map<List<DtoProduct>>(dbc.Products.ToList());
        }
        public List<DtoProduct> GetById(string id) 
        { 
            using DataBaseContext dbc = new();
            return InitAutoMapper.mapper.Map<List<DtoProduct>>(dbc.Products.Where(w => w.idProduct == id).ToList());
        }

        //Verificamos la existencia del producto por el nombre del mismo
        public bool ExistsByName(string name)
        {
            using DataBaseContext dbc = new();
            return dbc.Products.Where(w => w.name.Replace(" ", "") == name.Replace(" ", "")).Any();
        }

        //Verificamos la existencia por el id del producto
        public bool ExistsById(string idProduct)
        {
            using DataBaseContext dbc = new();
            return dbc.Products.Where(w => w.idProduct.Replace(" ", "") == idProduct.Replace(" ", "")).Any();
        }

        //Query para realizar la eliminación del producto
        public int Delete(string idProduct)
        {
            using DataBaseContext dbc = new();
            Product product = dbc.Products.Find(idProduct);

            if (product is null)
            {
                return 0;
            }

            dbc.Products.Remove(product);
            return dbc.SaveChanges();
        }

        //Query para realizar la actualización de la información del producto
        public int Update(DtoProduct dto)
        {
            using DataBaseContext dbc = new();
            Product product = dbc.Products.Find(dto.idProduct);
            product.name = dto.name;
            product.price = dto.price;
            return dbc.SaveChanges();
        }
    }
}