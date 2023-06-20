using _0._0.DataTransfer.DTO;
using _0._0.DataTransfer.DtoAdditional;
using _3._0.Business.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3._0.Business.Opening
{
    public partial class BusinessOpening:BusinessGeneric
    {
        public DtoMessage Insert(DtoOpening dto)
        {            
            dto.idOpening = Guid.NewGuid().ToString();
            _repoOpening.Insert(dto);
            _mo.listMessage.Add("operacion realizada");
            _mo.success();
            return _mo;
        }

        public (DtoMessage, List<DtoOpening>) GetAll()
        {
            List<DtoOpening> listDtoOpening = _repoOpening.GetAll();
            _mo.success();
            return (_mo, listDtoOpening);
        }

        public List<DtoOpening> GetById(string id)
        {
           return _repoOpening.GetById(id);
        }

        public DtoMessage Delete(string id){
            ValidationById(id);

            if (_mo.existsMessage())
            {
                return _mo;
            } 
            
            _repoOpening.Delete(id);
            _mo.listMessage.Add("Operacion exitosa");
            _mo.success();
            return _mo;
        }
        public DtoMessage Update(DtoOpening dto)
        {
            ValidationById(dto.idOpening);

            if (_mo.existsMessage())
            {
                    return _mo;
            }

            _repoOpening.Update(dto);
            _mo.listMessage.Add("Operacion exitosa");
            _mo.success();
            return _mo;
        }

    }
}