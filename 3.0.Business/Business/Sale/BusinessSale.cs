using _0._0.DataTransfer.DTO;
using _0._0.DataTransfer.DtoAdditional;
using _3._0.Business.Generic;
using _5._0.DataAcces.Connection;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;


namespace _3._0.Business.Business.Sale
{
    public partial class BusinessSale : BusinessGeneric
    {
        public DtoMessage Insert(DtoSale dto,IFormFile file)
        {
     
            dto.idSale = Guid.NewGuid().ToString();
            dto.saleState = false;
            dto.dateGo = DateTime.Now;
            dto.couponImg = subirImagen(file,dto.idSale);
            _repoSale.Insert(dto);
            _mo.listMessage.Add("operacion realizada");
            _mo.success();
            return _mo;
        }

        public string subirImagen(IFormFile file, string id)
        {
            Account account = new Account("dgbtcphdn", "728643729924779", "DMdxKePAodC3cJ8tXQTxUeOT1mY");
            Cloudinary cloudinary = new Cloudinary(account);
            cloudinary.Api.Secure = true;

            using (var stream = file.OpenReadStream())
            {
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(file.FileName, stream),
                    PublicId = id,
                    Folder = "venta_ticket/Sale"
                };

                var respuesta = cloudinary.Upload(uploadParams);

                if (respuesta.Error != null)
                {
                    // Manejar el error de carga de la imagen
                    // Puedes devolver un mensaje de error o lanzar una excepción según tus necesidades
                    return "Error al subir la imagen: " + respuesta.Error.Message;
                }

                var url = respuesta.SecureUrl?.AbsoluteUri;

                if (!string.IsNullOrEmpty(url))
                {
                    return url;
                }
                else
                {
                    return "No se pudo obtener la URL de la imagen subida";
                }
            }
        }




        public (DtoMessage, List<DtoSale>) GetAll()
        {
            List<DtoSale> listDtoSale = _repoSale.GetAll();
            _mo.success();
            return (_mo, listDtoSale);
        }

        public List<DtoSale> GetById(string id)
        {
           return _repoSale.GetById(id);
        }

        public DtoMessage Delete(string id)
        {
            ValidationById(id);

            if (_mo.existsMessage())
            {
                return _mo;
            }   
            
            _repoSale.Delete(id);
            _mo.listMessage.Add("Operacion exitosa");
            _mo.success();
            return _mo;
        }
        public DtoMessage Update(DtoSale dto)
        {
            ValidationById(dto.idSale);

            if (_mo.existsMessage())
            {
                return _mo;
            }

            _repoSale.Update(dto);
            _mo.listMessage.Add("Operacion exitosa");
            _mo.success();
            return _mo;
        }
    }
}