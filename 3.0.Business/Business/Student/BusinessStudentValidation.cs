using _0._0.DataTransfer.DTO;

namespace _3._0.Business.Student;

public partial class BusinessStudent
{
    private void ValidationInsertE(DtoStudent dto)
    {
        if(_repoStudent.ExistsByCode(dto.code))
        {
            _mo.listMessage.Add("El estudiante que se trata de registrar ya existe ");
        }
    }
    private void ValidationById(string id)
    {
        if (!_repoStudent.ExistsById(id))
        {
            _mo.listMessage.Add("Error! El Estudiante no existe en la base de datos");
        }
    }
}