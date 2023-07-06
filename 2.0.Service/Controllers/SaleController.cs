using _0._0.DataTransfer.DTO;
using _2._0.Service.Generic;
using _2._0.Service.ServiceObject;
using _3._0.Business.Business.Sale;
using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _2._0.Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SaleController : ControllerGeneric<SoSale, BusinessSale>
    {
        [HttpPost]
        [Route("[action]")]
        public ActionResult<SoSale> Insert([FromForm] SoSale so)
        {
            try
            {
               _so.mo = ValidatePartDto(so.dtoSale, new string[] {
                    "name"
                });

                if (_so.mo.existsMessage())
                {
                    return _so;
                }

                so.dtoSale.couponImg = "Hola ";
                _so.mo = _business.Insert(so.dtoSale);
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
        public ActionResult<List<DtoSale>> GetById(string id)
        {
            BusinessSale businessSale = new();
            return businessSale.GetById(id);
        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult<SoSale> GetAll()
        {
            try
            {
                (_so.mo, _so.listDtoSale) = _business.GetAll();
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
        public ActionResult<SoSale> Delete(string id)
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
        public ActionResult<SoSale> Update([FromForm] SoSale so)
        {
            try
            {
                _so.mo = ValidatePartDto(so.dtoSale, new string[] {
                    "idSale",
                    "name"
                });

                if (_so.mo.existsMessage())
                {
                    return _so;
                }

                _so.mo = _business.Update(so.dtoSale);
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