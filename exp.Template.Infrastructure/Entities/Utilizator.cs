using System;
using System.Collections.Generic;

namespace exp.Template.Infrastructure.Entities;

public partial class Utilizator
{
    public int Id { get; set; }

    public string? Nume { get; set; }

    public string? Prenume { get; set; }

    public string? Email { get; set; }

    public string? Parola { get; set; }
}
