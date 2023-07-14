using _0._0.DataTransfer.DTO;
using _0._0.DataTransfer.DtoAdditional;
using _3._0.Business.Generic;
using Microsoft.AspNetCore.Http;

namespace _3._0.Business.Student;
public partial class BusinessStudent : BusinessGeneric
{
        public DtoMessage Insert(DtoStudent dto)
        {
            dto.idStudent = Guid.NewGuid().ToString();
            dto.password = dto.dni;
            dto.mail = dto.code+"@unamba.edu.pe";
            dto.studentState = false;
            dto.profileImg = "https://e7.pngegg.com/pngimages/640/228/png-clipart-user-profile-computer-icons-others-miscellaneous-black.png";
        ValidationInsertE(dto);

            if(_mo.existsMessage()){
                return _mo;
            }

            _repoStudent.Insert(dto);
            _mo.listMessage.Add("operacion realizada");
            _mo.success();
            return _mo;
        }

        public (DtoMessage, List<DtoStudent>) GetAll()
        {
            List<DtoStudent> listDtoStudent = _repoStudent.GetAll();
            _mo.success();
            return (_mo, listDtoStudent);
        }

        public List<DtoStudent> GetById(string id)
        {
           return _repoStudent.GetById(id);
        }

        public DtoMessage Delete(string id)
        {
            ValidationById(id);

            if (_mo.existsMessage())
            {
                return _mo;
            }    
            _repoStudent.Delete(id);
            _mo.listMessage.Add("Operacion exitosa");
            _mo.success();
            return _mo;
        }
        public DtoMessage Update(DtoStudent dto)
        {
            ValidationById(dto.idStudent);

            if (_mo.existsMessage())
            {
                return _mo;
            }

            _repoStudent.Update(dto);
            _mo.listMessage.Add("Operacion exitosa");
            _mo.success();
            return _mo;
        }

    public string Login(string mail, string password)
    {
        return _repoStudent.Login(mail, password);
    }

    public string subirImagen(IFormFile file,string id)
    {
        return _repoStudent.subirImagen(file,id);
    }

}