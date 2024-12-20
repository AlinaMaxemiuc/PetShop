using System;
using System.Collections.Generic;

namespace exp.Template.Backend.Entities;

public partial class Hrana
{
    public int Id { get; set; }

    public string? Nume { get; set; }

    public string? Descriere { get; set; }

    public decimal? Pret { get; set; }

    public int? Stoc { get; set; }

 //   public virtual ICollection<Abonament> Abonaments { get; set; } = new List<Abonament>();
}
