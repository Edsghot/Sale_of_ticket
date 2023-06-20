using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _0._0.DataTransfer.DTO;

namespace _3._0.Business.Administrator;

public partial class BusinessAdministrator
{
   private void ValidationInsertE(DtoAdministrator dto){
   //codigo olor: El miembro 'ValidationInsertE' no tiene acceso a los datos de la instancia y se puede marcar como est�tico

        /* if(_repoAdministrator.ExistsByCode(dto.code)){
             _mo.listMessage.Add("El estudiante que se trata de registrar ya existe ");
         }*/
        //codigo olor: Elimine este c�digo comentado.
    }
    private void ValidationById(string id)
    {
        if (!_repoAdministrator.ExistsById(id))
        {
            _mo.listMessage.Add("Error! El Estudiante no existe en la base de datos");
        }
    } 
}