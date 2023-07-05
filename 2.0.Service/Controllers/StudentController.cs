using _0._0.DataTransfer.DTO;
using _0._0.DataTransfer.DtoAdditional;
using _2._0.Service.Generic;
using _2._0.Service.ServiceObject;
using _3._0.Business;
using _3._0.Business.Student;
using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using _3._0.Business.Business.SaleDetail;

namespace _2._0.Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerGeneric<SoStudent, BusinessStudent>
    {
        private readonly string secretkey;

        public StudentController(IConfiguration config)
        //codigo olor: El elemento campo "secretkey" que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declarar el elemento campo como que admite un valor NULL.
        {
            secretkey = config.GetSection("settings").GetSection("secretkey").ToString();
            //codigo olor: Posible asignación de referencia nula.
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult Login(string mail,string password)
        {

            BusinessStudent businessStudent = new();

            if (businessStudent.Login(mail, password) != null)
            {
                var keyBytes = Encoding.ASCII.GetBytes(secretkey);
                var claims = new ClaimsIdentity();
                claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, mail));

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = claims,
                    Expires = DateTime.UtcNow.AddMinutes(15),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenconfig = tokenHandler.CreateToken(tokenDescriptor);
                string tokenCreate = tokenHandler.WriteToken(tokenconfig);
                var codeAdmin = businessStudent.Login(mail, password);
                return StatusCode(StatusCodes.Status200OK, new { codeAdmin, token = tokenCreate });

            }else
            {
                return StatusCode(StatusCodes.Status401Unauthorized, new { token = " " });
            }
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<String>> SubirImagen(IFormFile file)
        {
            // Llamar a la función Upload y obtener la URL
            
            String imageUrl = await Upload(file);


            // Devolver la URL como respuesta
            return imageUrl;
        }
        private async Task<string> Upload(IFormFile file)
        {
            Account account = new Account("dm2vlcipm", "937275526697616", "HeRqnltE8mTtAJRpPqc1udxv7Ro");
            Cloudinary cloudinary = new Cloudinary(account);
            cloudinary.Api.Secure = true;

            using (var stream = file.OpenReadStream())
            {
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(file.FileName, stream),
                    PublicId = "olympic_flag"
                };
                var respuesta = await cloudinary.UploadAsync(uploadParams);

                return respuesta.SecureUrl.AbsoluteUri;
            }
        }



        [HttpPost]
        [Route("[action]")]
        public ActionResult<SoStudent> Insert([FromForm] SoStudent so)
        {
            try
            {
                _so.mo = ValidatePartDto(so.dtoStudent, new string[] {
                    "name"
                });

                if (_so.mo.existsMessage())
                {
                    return _so;
                }

                _so.mo = _business.Insert(so.dtoStudent);
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
        public ActionResult<SoStudent> GetAll()
        {
            try
            {
                (_so.mo, _so.listDtoStudent) = _business.GetAll();
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
        public ActionResult<List<DtoStudent>> GetById(string id)
        {
            BusinessStudent businessStudent = new();
            return businessStudent.GetById(id);
        }

        [HttpDelete]
        [Route("[action]")]
        public ActionResult<SoStudent> Delete(string idEstudent)
        {
            try
            {
                _so.mo = _business.Delete(idEstudent);
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
        public ActionResult<SoStudent> Update([FromForm] SoStudent so)
        {
            try
            {
                _so.mo = ValidatePartDto(so.dtoStudent, new string[] {
                    "idService",
                    "name"
                });

                if (_so.mo.existsMessage())
                {
                    return _so;
                }

                _so.mo = _business.Update(so.dtoStudent);
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