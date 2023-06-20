using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3._0.Business.Opening;

public partial class BusinessOpening{
   
    private void ValidationById(string id)
    {
        if (!_repoOpening.ExistsById(id))
        {
            _mo.listMessage.Add("Error! El Estudiante no existe en la base de datos");
        }
    }        
}
