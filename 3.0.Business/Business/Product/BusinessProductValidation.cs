
using _0._0.DataTransfer.DTO;
using _4._0.Repository.Repository;

namespace _3._0.Business.Producto
{
    public partial class BusinessProduct
    {
        private void ValidationInsertP(DtoProduct dto)
        {
            if (_repoProduct.ExistsByName(dto.name))
            //codigo olor: Posible argumento de referencia nulo para el parámetro "name" en "bool RepoProduct.ExistsByName(string name)".
            {
                _mo.listMessage.Add("Error! El producto ya esta registrado");
            }
        }
        private void ValidationDelete(string id)
        {
            if (!_repoProduct.ExistsById(id))
            {
                _mo.listMessage.Add("Error! El producto no existe en la base de datos");
            }
        }
        private void ValidationUpdate(string id)
        {
            if (!_repoProduct.ExistsById(id))
            {
                _mo.listMessage.Add("Error! El producto no existe en la base de datos");
            }
        }
    }
}
