using _0._0.DataTransfer.DTO;
using _0._0.DataTransfer.DtoAdditional;
using _3._0.Business.Generic;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3._0.Business.Business.Sale
{
    public partial class BusinessSale : BusinessGeneric
    {
        public DtoMessage Insert(DtoSale dto)
        {
            dto.idSale = Guid.NewGuid().ToString();
            dto.saleState = false;
            _repoSale.Insert(dto);
            _mo.listMessage.Add("operacion realizada");
            _mo.success();
            return _mo;
        }

        private async Task<string> Upload(string base64)
        {
            Account account = new Account("dgbtcphdn", "728643729924779", "DMdxKePAodC3cJ8tXQTxUeOT1mY");
            Cloudinary cloudinary = new Cloudinary(account);
            cloudinary.Api.Secure = true;

            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(Guid.NewGuid().ToString(), new MemoryStream(Convert.FromBase64String(base64))),
                PublicId = "olympic_flag"
            };
            var respuesta = await cloudinary.UploadAsync(uploadParams);

            return respuesta.SecureUrl.AbsoluteUri;
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