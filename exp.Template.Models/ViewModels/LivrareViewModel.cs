using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exp.Template.Models.ViewModels
{
    public class LivrareViewModel
    {
        public int Id { get; set; }
        public int? IdComanda { get; set; }

        public DateOnly? DataLivrare { get; set; }

        public string? AdresaLivrare { get; set; }
    }
}
