using _0._0.DataTransfer.DTO;
using _0._0.DataTransfer.DtoAdditional;
using _2._0.Service.Generic;
using _2._0.Service.ServiceObject;
using _3._0.Business;
using _3._0.Business.Producto;
using Microsoft.AspNetCore.Mvc;

namespace _2._0.Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerGeneric<SoProduct, BusinessProduct>
    {

        [HttpPost]
        [Route("[action]")]
        public ActionResult<SoProduct> Insert([FromForm] SoProduct so)
        {
            try
            {
                _so.mo = ValidatePartDto(so.dtoProduct, new string[] {
                    "name"
                });

                if (_so.mo.existsMessage())
                {
                    return _so;
                }

                _so.mo = _business.Insert(so.dtoProduct);
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
        public ActionResult<List<DtoProduct>> GetById(string id)
        {
            BusinessProduct businessProduct = new();
            return businessProduct.GetById(id);
        }


        [HttpGet]
        [Route("[action]")]
        public ActionResult<SoProduct> GetAll()
        {
            try
            {
                (_so.mo, _so.listDtoProduct) = _business.GetAll();
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
        public ActionResult<SoProduct> Delete(string id)
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
        public ActionResult<SoProduct> Update([FromForm] SoProduct so)
        {
            try
            {
                _so.mo = ValidatePartDto(so.dtoProduct, new string[] {
                    "idProduct",
                    "name"
                });

                if (_so.mo.existsMessage())
                {
                    return _so;
                }

                _so.mo = _business.Update(so.dtoProduct);
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
