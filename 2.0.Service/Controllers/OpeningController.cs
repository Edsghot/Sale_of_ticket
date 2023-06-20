using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using _0._0.DataTransfer.DTO;
using _2._0.Service.Generic;
using _2._0.Service.ServiceObject;
using _3._0.Business.Opening;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace _2._0.Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OpeningController : ControllerGeneric<SoOpening, BusinessOpening>
    {
        [HttpPost]
        [Route("[action]")]
        public ActionResult<SoOpening> Insert([FromForm] SoOpening so)
        {
            try
            {
                _so.mo = ValidatePartDto(so.dtoOpening, new string[] {
                    "name"
                });

                if (_so.mo.existsMessage())
                {
                    return _so;
                }

                _so.mo = _business.Insert(so.dtoOpening);
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
        public ActionResult<List<DtoOpening>> GetById(string id)
        {
            BusinessOpening businessOpening = new();
            return businessOpening.GetById(id);
        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult<SoOpening> GetAll()
        {
            try
            {
                (_so.mo, _so.listDtoOpening) = _business.GetAll();
                return _so;
            }catch (Exception e)
            {
                _so.mo.listMessage.Add(e.Message);
                _so.mo.exception();
                return _so;
            }

        }

        [HttpDelete]
        [Route("[action]")]
        public ActionResult<SoOpening> Delete(string id)
        {
            try
            {
                _so.mo = _business.Delete(id);

                return _so;
            }catch (Exception e)
            {
                _so.mo.listMessage.Add(e.Message);
                _so.mo.exception();
                return _so;
            }
        }

        [HttpPost]
        [Route("[action]")]
        public ActionResult<SoOpening> Update([FromForm] SoOpening so)
        {
            try
            {
                _so.mo = ValidatePartDto(so.dtoOpening, new string[] {
                    "idOpening",
                    "name"
                });

                if (_so.mo.existsMessage())
                {
                    return _so;
                }

                _so.mo = _business.Update(so.dtoOpening);
                return _so;
            }catch (Exception e)
            {
                _so.mo.listMessage.Add(e.Message);
                _so.mo.exception();
                return _so;
            }
        }
    }
}