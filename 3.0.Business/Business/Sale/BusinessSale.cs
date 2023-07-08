using _0._0.DataTransfer.DTO;
using _0._0.DataTransfer.DtoAdditional;
using _3._0.Business.Generic;
using _4._0.Repository.Repository;
using _5._0.DataAcces.Connection;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;


namespace _3._0.Business.Business.Sale
{
    public partial class BusinessSale : BusinessGeneric
    {
        public string Insert(DtoSale dto)
        {
            dto.idSale = Guid.NewGuid().ToString();
            dto.saleState = false;
            dto.dateGo = DateTime.Now;
            dto.couponImg = "error al subir imagen";


            return _repoSale.Insert(dto); 
        }

        public string subirImagen(IFormFile file, string id)
        {
            return _repoSale.subirImagen(file, id);
        }




        public (DtoMessage, List<DtoSale>) GetAll()
        {
            List<DtoSale> listDtoSale = _repoSale.GetAll();
            _mo.success();
            return (_mo, listDtoSale);
        }


        public (DtoMessage, List<DtoSaleView>) GetSale()
        {
            try
            {
                List<DtoSaleView> listDtoSale = _repoSale.GetSale();
                _mo.success();
                return (_mo, listDtoSale);
            }
            catch (Exception e)
            {
                _mo.listMessage.Add(e.Message);
                _mo.exception();
                return (_mo, null);
            }
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
        public DtoMessage checkState(string id)
        {
            ValidationById(id);

            if (_mo.existsMessage())
            {
                return _mo;
            }

            _repoSale.checkState(id);
            _mo.listMessage.Add("Operacion exitosa");
            _mo.success();
            return _mo;
        }

    }
}