using _0._0.DataTransfer.DTO;
using _2._0.Service.Generic;
using _2._0.Service.ServiceObject;
using _3._0.Business.Business.Period;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _2._0.Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PeriodController : ControllerGeneric<SoPeriod, BusinessPeriod>
    {
        [HttpPost]
        [Route("[action]")]
        public ActionResult<SoPeriod> Insert([FromForm] SoPeriod so)
        {
            try
            {
                _so.mo = ValidatePartDto(so.dtoPeriod, new string[] {
                //codigo olor: Posible argumento de referencia nulo para el parámetro "model" en "DtoMessage ControllerGeneric<SoPeriod, BusinessPeriod>. ValidatePartDto(modelo de objetos, string[] fieldList)".
                    "name"
                });

                if (_so.mo.existsMessage())
                {
                    return _so;
                }

                _so.mo = _business.Insert(so.dtoPeriod);
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
        public ActionResult<List<DtoPeriod>> GetById(string id)
        {
            BusinessPeriod businessPeriod = new();
            return businessPeriod.GetById(id);
        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult<SoPeriod> GetAll()
        {
            try
            {
                (_so.mo, _so.listDtoPeriod) = _business.GetAll();
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
        public ActionResult<SoPeriod> Delete(string id)
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
        public ActionResult<SoPeriod> Update([FromForm] SoPeriod so)
        {
            try
            {
                _so.mo = ValidatePartDto(so.dtoPeriod, new string[] {
                //codigo olor: Posible argumento de referencia nulo para el parámetro "model" en "DtoMessage ControllerGeneric<SoPeriod, BusinessPeriod>. ValidatePartDto(modelo de objetos, string[] fieldList)".
                    "idPeriod",
                    "name"
                });

                if (_so.mo.existsMessage())
                {
                    return _so;
                }

                _so.mo = _business.Update(so.dtoPeriod);
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