using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exp.Template.Models.ViewModels
{
    public class ComandaViewModel
    {
        public int Id { get; set; }
        public int? IdUtilizator { get; set; }
        public string? UtilizatorDetails { get; set; }
        public int? IdAbonament { get; set; }
        public string? AbonamentDetails { get; set; }
        public DateOnly? DataComenzii { get; set; }
        public decimal? Total { get; set; }
        public bool? Discount { get; set; }
    }
}
