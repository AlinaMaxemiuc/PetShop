using System;
using System.Collections.Generic;

namespace exp.Template.Infrastructure.Entities;

public partial class Animale
{
    public int Id { get; set; }

    public string? Gen { get; set; }

    public string? Specie { get; set; }

    public int? Varsta { get; set; }

    public decimal? Greutate { get; set; }
   // public bool? IsDeleted { get; set; }
}
