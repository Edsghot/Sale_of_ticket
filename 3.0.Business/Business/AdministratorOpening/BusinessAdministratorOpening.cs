using _0._0.DataTransfer.DTO;
using _0._0.DataTransfer.DtoAdditional;
using _3._0.Business.Generic;
using _4._0.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3._0.Business.AdministratorOpening
{
    public partial class BusinessAdministratorOpening : BusinessGeneric
    {
        public DtoMessage Insert(DtoAdministratorOpening dto)
        {           
            dto.idOpeningAdministrator = Guid.NewGuid().ToString();
            _repoAdministratorOpening.Insert(dto);
            _mo.listMessage.Add("operacion realizada");
            _mo.success();
            return _mo;
        }

        public (DtoMessage, List<DtoAdministratorOpening>) GetAll()
        {
            List<DtoAdministratorOpening> listDtoAdministratorOpening = _repoAdministratorOpening.GetAll();
            _mo.success();
            return (_mo, listDtoAdministratorOpening);
        }

        public List<DtoAdministratorOpening> GetById(string id)
        {
            return _repoAdministratorOpening.GetById(id);
        }
    }
}