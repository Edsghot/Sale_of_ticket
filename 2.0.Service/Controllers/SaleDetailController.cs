using _0._0.DataTransfer.DTO;
using _2._0.Service.Generic;
using _2._0.Service.ServiceObject;
using _3._0.Business.Business.SaleDetail;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _2._0.Service.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class SaleDetailController : ControllerGeneric<SoSaleDetail, BusinessSaleDetail>
    {

        [HttpPost]
        [Route("[action]")]
        public ActionResult<SoSaleDetail> Insert([FromForm] SoSaleDetail so)
        {
            try
            {
                _so.mo = ValidatePartDto(so.dtoSaleDetail, new string[] {
                    "name"
                });

                if (_so.mo.existsMessage())
                {
                    return _so;
                }

                _so.mo = _business.Insert(so.dtoSaleDetail);
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
        public ActionResult<List<DtoSaleDetail>> GetById(string id)
        {
            BusinessSaleDetail businessSaleDetail = new();
            return businessSaleDetail.GetById(id);
        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult<SoSaleDetail> GetAll()
        {
            try
            {
                (_so.mo, _so.listDtoSaleDetail) = _business.GetAll();

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
        public ActionResult<SoSaleDetail> Delete(string id)
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
        public ActionResult<SoSaleDetail> Update([FromForm] SoSaleDetail so)
        {
            try
            {
                _so.mo = ValidatePartDto(so.dtoSaleDetail, new string[] {
                    "idSaleDetail",
                    "name"
                });

                if (_so.mo.existsMessage())
                {
                    return _so;
                }

                _so.mo = _business.Update(so.dtoSaleDetail);
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