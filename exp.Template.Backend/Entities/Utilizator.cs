using System;
using System.Collections.Generic;

namespace exp.Template.Backend.Entities;

public partial class Utilizator
{
    public int Id { get; set; }

    public string? Nume { get; set; }

    public string? Prenume { get; set; }

    public string? Email { get; set; }

    public string? Parola { get; set; }

    public virtual ICollection<Abonament> Abonaments { get; set; } = new List<Abonament>();

    public virtual ICollection<Comandum> Comanda { get; set; } = new List<Comandum>();
}
