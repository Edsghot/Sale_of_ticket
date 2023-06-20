using _0._0.DataTransfer.DTO;
using _0._0.DataTransfer.DtoAdditional;
using _3._0.Business.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3._0.Business.Business.Period
{
    public partial class BusinessPeriod :BusinessGeneric
    {
        public DtoMessage Insert(DtoPeriod dto){
            //prueba realizadas
            dto.idPeriod = Guid.NewGuid().ToString();

            if(_mo.existsMessage()){
                return _mo;
            }

            _repoPeriod.Insert(dto);
            _mo.listMessage.Add("operacion realizada");
            _mo.success();
            return _mo;
        }

        public (DtoMessage, List<DtoPeriod>) GetAll()
        {
            List<DtoPeriod> listDtoPeriod = _repoPeriod.GetAll();
            _mo.success();
            return (_mo, listDtoPeriod);
        }

        public List<DtoPeriod> GetById(string id)
        {
           return _repoPeriod.GetById(id);
        }

        public DtoMessage Delete(string id)
        {
            ValidationById(id);

            if (_mo.existsMessage())
            {
                return _mo;
            }  
            
            _repoPeriod.Delete(id);
            _mo.listMessage.Add("Operacion exitosa");
            _mo.success();
            return _mo;
        }
        public DtoMessage Update(DtoPeriod dto){

            ValidationById(dto.idPeriod);

            if (_mo.existsMessage())
            {
                return _mo;
            }

            _repoPeriod.Update(dto);
            _mo.listMessage.Add("Operacion exitosa");
            _mo.success();
            return _mo;
        }
    }
}