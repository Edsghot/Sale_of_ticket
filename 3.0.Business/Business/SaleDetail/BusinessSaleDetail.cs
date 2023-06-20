using _3._0.Business.Generic;
using _0._0.DataTransfer.DTO;
using _0._0.DataTransfer.DtoAdditional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3._0.Business.Business.SaleDetail
{
    public partial class BusinessSaleDetail : BusinessGeneric
    {
       public DtoMessage Insert(DtoSaleDetail dto){
            dto.idSaleDetail = Guid.NewGuid().ToString();
            _repoSaleDetail.Insert(dto);
            _mo.listMessage.Add("operacion realizada");
            _mo.success();
            return _mo;
        }

        public (DtoMessage, List<DtoSaleDetail>) GetAll()
        {
            List<DtoSaleDetail> listDtoSaleDetail = _repoSaleDetail.GetAll();
            _mo.success();
            return (_mo, listDtoSaleDetail);
        }

        public List<DtoSaleDetail> GetById(string id)
        {
           return _repoSaleDetail.GetById(id);
        }

        public DtoMessage Delete(string id)
        {
            ValidationById(id);

            if (_mo.existsMessage())
            {
                return _mo;
            }
            
            _repoSaleDetail.Delete(id);
            _mo.listMessage.Add("Operacion exitosa");
            _mo.success();
            return _mo;
        }
        public DtoMessage Update(DtoSaleDetail dto)
        {
            ValidationById(dto.idSaleDetail);

            if (_mo.existsMessage())
            {
                return _mo;
            }

            _repoSaleDetail.Update(dto);
            _mo.listMessage.Add("Operacion exitosa");
            _mo.success();
            return _mo;
        }
    }
}