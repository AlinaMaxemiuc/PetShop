using System;
using System.Collections.Generic;

namespace exp.Template.Infrastructure.Entities;

public partial class Livrari
{
    public int Id { get; set; }

    public int? IdComanda { get; set; }

    public DateOnly? DataLivrare { get; set; }

    public string? AdresaLivrare { get; set; }

    public virtual Comanda? IdComandaNavigation { get; set; }
}
