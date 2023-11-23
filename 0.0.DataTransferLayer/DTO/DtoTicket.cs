using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0._0.DataTransfer.DTO;

public record DtoTicket
{
    public int total { get; set; }
    public DateTime dateGo { get; set; }
    public string name { get; set; }
    public string lastName { get; set; }
    public string school { get; set; }
    public string faculty { get; set; }
    public string code { get; set; }
}
