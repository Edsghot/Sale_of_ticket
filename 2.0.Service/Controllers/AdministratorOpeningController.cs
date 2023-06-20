using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _0._0.DataTransfer.DTO;
using _2._0.Service.Generic;
using _2._0.Service.ServiceObject;
using _3._0.Business.AdministratorOpening;
using Microsoft.AspNetCore.Mvc;

namespace _2._0.Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdministratorOpeningController : ControllerGeneric<SoAdministratorOpening, BusinessAdministratorOpening>
    {        
        [HttpPost]
        [Route("[action]")]
        public ActionResult<SoAdministratorOpening> Insert([FromForm] SoAdministratorOpening so)
        {
            try
            {
                _so.mo = ValidatePartDto(so.dtoAdministratorOpening, new string[] {
                    "name"
                });

                if (_so.mo.existsMessage())
                {
                    return _so;
                }
                _so.mo = _business.Insert(so.dtoAdministratorOpening);
                return _so;
            }catch (Exception e)
            {
                _so.mo.listMessage.Add(e.Message);
                _so.mo.exception();
                return _so;
            }
        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult<SoAdministratorOpening> GetAll()
        {
            try
            {
                (_so.mo, _so.listDtoAdministratorOpening) = _business.GetAll();
                return _so;
            }catch (Exception e)
            {
                _so.mo.listMessage.Add(e.Message);
                _so.mo.exception();
                return _so;
            }

        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult<List<DtoAdministratorOpening>> GetById(string id)
        {
            BusinessAdministratorOpening businessAdministratorOpening = new();
            return businessAdministratorOpening.GetById(id);
        }

    }
}