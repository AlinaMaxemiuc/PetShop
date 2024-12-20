using System;
using System.Collections.Generic;

namespace exp.Template.Infrastructure.Entities;

public partial class Abonament
{
    public int Id { get; set; }

    public int? IdUtilizator { get; set; }

    public int? IdHrana { get; set; }

    public int? Frecventa { get; set; }

    public DateOnly? DataIncepere { get; set; }

    public DateOnly? DataSfarsit { get; set; }

    public virtual ICollection<Comanda> Comandas { get; set; } = new List<Comanda>();

    public virtual Hrana? IdHranaNavigation { get; set; }
}
