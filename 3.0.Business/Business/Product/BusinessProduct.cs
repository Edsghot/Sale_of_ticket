
using _0._0.DataTransfer.DTO;
using _0._0.DataTransfer.DtoAdditional;
using _3._0.Business.Generic;
using _4._0.Repository.Repository;

namespace _3._0.Business.Producto
{
    public partial class BusinessProduct: BusinessGeneric
    {
        public DtoMessage Insert(DtoProduct dto)
        {
            
            dto.idProduct = Guid.NewGuid().ToString();            
            ValidationInsertP(dto);
            
            if (_mo.existsMessage())
            {
                return _mo;
            }

            _repoProduct.Insert(dto);
            _mo.listMessage.Add("operacion realizada");
            _mo.success();
            return _mo;
        }

        public (DtoMessage, List<DtoProduct>) GetAll()
        {
            List<DtoProduct> listDtoProduct = _repoProduct.GetAll();
            _mo.success();
            return (_mo, listDtoProduct);
        }

        public DtoMessage Delete(string id)
        {
            ValidationDelete(id);

            if (_mo.existsMessage())
            {
                return _mo;
            }  
            
            _repoProduct.Delete(id);
            _mo.listMessage.Add("Operacion exitosa");
            _mo.success();
            return _mo;
        }

        public List<DtoProduct> GetById(string id)
        {
           return _repoProduct.GetById(id);
        }

        public DtoMessage Update(DtoProduct dto)
        {
            ValidationUpdate(dto.idProduct);

            if (_mo.existsMessage())
            {
                return _mo;
            }

            _repoProduct.Update(dto);
            _mo.listMessage.Add("Operación realizada correctamente.");
            _mo.success();
            return _mo;
        }
    }
}
