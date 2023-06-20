using _0._0.DataTransfer.DTO;
using _0._0.DataTransfer.DtoAdditional;
using _2._0.Service.Generic;
using _2._0.Service.ServiceObject;
using _3._0.Business;
using _3._0.Business.Administrator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace _2._0.Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdministratorController : ControllerGeneric<SoAdministrator, BusinessAdministrator>
    {
        private readonly string secretkey;

        public AdministratorController(IConfiguration config){
            secretkey = config.GetSection("settings").GetSection("secretkey").ToString();
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult Login(string mail,string password)
        {

            BusinessAdministrator businessAdministrator = new();

            if (businessAdministrator.Login(mail, password) != null)
            {
                var keyBytes = Encoding.ASCII.GetBytes(secretkey);
                var claims = new ClaimsIdentity();
                claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, mail));

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = claims,
                    Expires = DateTime.UtcNow.AddMinutes(5),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenconfig = tokenHandler.CreateToken(tokenDescriptor);
                string tokenCreate = tokenHandler.WriteToken(tokenconfig);
                var codeAdmin = businessAdministrator.Login(mail, password);
                return StatusCode(StatusCodes.Status200OK, new { codeAdmin, token = tokenCreate });

            }else
            {
                return StatusCode(StatusCodes.Status401Unauthorized, new { token = " " });
            }
        }

        [HttpPost]
        [Route("[action]")]
        public ActionResult<SoAdministrator> Insert([FromForm] SoAdministrator so)
        {
            try
            {
                _so.mo = ValidatePartDto(so.dtoAdministrator, new string[] {
                    "name"
                });
                if (_so.mo.existsMessage())
                {
                    return _so;
                }
                _so.mo = _business.Insert(so.dtoAdministrator);
                return _so;
            }
            catch (Exception e)
            {
                _so.mo.listMessage.Add(e.Message);
                _so.mo.exception();
                return _so;
            }
        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult<SoAdministrator> GetAll()
        {
            try
            {
                (_so.mo, _so.listDtoAdministrator) = _business.GetAll();

                return _so;
            }
            catch (Exception e)
            {
                _so.mo.listMessage.Add(e.Message);
                _so.mo.exception();

                return _so;
            }

        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult<List<DtoAdministrator>> GetById(string id)
        {
            BusinessAdministrator businessAdministrator = new();
            return businessAdministrator.GetById(id);
        }

        [HttpDelete]
        [Route("[action]")]
        public ActionResult<SoAdministrator> Delete(string idEAdministrator)
        {
            try
            {
                _so.mo = _business.Delete(idEAdministrator);
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
        public ActionResult<SoAdministrator> Update([FromForm] SoAdministrator so)
        {
            try
            {
                _so.mo = ValidatePartDto(so.dtoAdministrator, new string[] {
                    "idService",
                    "name"
                });

                if (_so.mo.existsMessage())
                {
                    return _so;
                }

                _so.mo = _business.Update(so.dtoAdministrator);
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