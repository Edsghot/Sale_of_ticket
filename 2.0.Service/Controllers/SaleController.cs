using _0._0.DataTransfer.DTO;
using _2._0.Service.Generic;
using _2._0.Service.ServiceObject;
using _3._0.Business.Business.Sale;
using Microsoft.AspNetCore.Mvc;

namespace _2._0.Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SaleController : ControllerGeneric<SoSale, BusinessSale>
    {
        [HttpPost]
        [Route("[action]")]
        public IActionResult Insert([FromForm] SoSale so, IFormFile file)
        {
            try
            {
                string id = _business.Insert(so.dtoSale);
                string url = _business.subirImagen(file, id);
                return StatusCode(StatusCodes.Status200OK, new { url = url });
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status417ExpectationFailed, new { msg = e.InnerException?.Message ?? e.Message });
            }
        }
        [HttpGet]
        [Route("[action]")]
        public ActionResult<List<DtoSaleView>> GetSale()
        {
            try
            {
                var (mo, listDtoSale) = _business.GetSale();
                return Json(listDtoSale);
            }
            catch (Exception e)
            {
                return Json(new List<DtoSaleView>());
            }
        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult<List<DtoSale>> GetByIdStudent(string idStudent)
        {
            return _business.GetByIdStudent(idStudent);
        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult<List<DtoSale>> GetById(string id)
        {
            return _business.GetById(id);
        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult<DtoTicket> GetTicket(string idStudent)
        {  
            try
            {
                return _business.GetTicket(idStudent);

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status417ExpectationFailed, new { msg = e.InnerException?.Message ?? e.Message });
            }
        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult<List<DtoSale>> ModifyStateFail(string idSale)
        {
            try
            {
                _business.ModifyStateFail(idSale);

                return Ok("Se realizo correctamente");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status417ExpectationFailed, new { msg = e.InnerException?.Message ?? e.Message });
            }
            
        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult<SoSale> GetAll()
        {
            try
            {
                (_so.mo, _so.listDtoSale) = _business.GetAll();
                return _so;
            }
            catch (Exception e)
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
            }
            catch (Exception e)
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
            }
            catch (Exception e)
            {
                _so.mo.listMessage.Add(e.Message);
                _so.mo.exception();
                return _so;
            }
        }
        [HttpPost]
        [Route("[action]")]
        public ActionResult<SoSale> CheckState([FromForm] string id)
        {
            try
            {
                _so.mo = ValidatePartDto(id, new string[] {
                    "idSale"
                });

                if (_so.mo.existsMessage())
                {
                    return _so;
                }

                _so.mo = _business.checkState(id);
                return _so;
            }
            catch (Exception e)
            {
                _so.mo.listMessage.Add(e.Message);
                _so.mo.exception();
                return _so;
            }
        }
    }
}