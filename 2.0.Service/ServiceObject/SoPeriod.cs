using _0._0.DataTransfer.DTO;
using _2._0.Service.Generic;

namespace _2._0.Service.ServiceObject
{
    public class SoPeriod : SoGeneric
    {        
        public DtoPeriod? dtoPeriod { get; set; }
        public List<DtoPeriod>? listDtoPeriod { get; set; }
    }
}