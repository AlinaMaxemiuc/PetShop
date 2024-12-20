using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exp.Template.Models.ViewModels
{
    public class AbonamentViewModel
    {
        public int Id { get; set; }
        public int? IdUtilizator { get; set; }
        public string? UtilizatorDetails { get; set; }
        public int? IdHrana { get; set; }
        public string? HranaDetails { get; set; }
        public int? Frecventa { get; set; }
        public DateOnly? DataIncepere { get; set; }
        public DateOnly? DataSfarsit { get; set; }
    }
}
