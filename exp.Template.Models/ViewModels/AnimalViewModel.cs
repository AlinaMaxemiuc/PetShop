using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exp.Template.Models.ViewModels
{
    public class AnimalViewModel
    {
            public int Id { get; set; }
            public string? Gen { get; set; }

            public string? Specie { get; set; }

            public int? Varsta { get; set; }

            public decimal? Greutate { get; set; }
  
    }
}
