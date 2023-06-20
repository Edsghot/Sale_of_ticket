using _3._0.Business.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _0._0.DataTransfer.DTO;

namespace _3._0.Business.Business.SaleDetail
{
    public partial class BusinessSaleDetail : BusinessGeneric
    {
        private void ValidationById(string id)
        {
            if (!_repoSaleDetail.ExistsById(id))
            {
                _mo.listMessage.Add("Error! El Estudiante no existe en la base de datos");
            }
        }
    }
}