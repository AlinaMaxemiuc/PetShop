using System;
using System.Collections.Generic;

namespace exp.Template.Backend.Entities;

public partial class Abonament
{
    public int Id { get; set; }

    public int? IdUtilizator { get; set; }

    public int? IdHrana { get; set; }

    public int? Frecventa { get; set; }

    public DateOnly? DataIncepere { get; set; }

    public DateOnly? DataSfarsit { get; set; }

    public virtual ICollection<Comandum> Comanda { get; set; } = new List<Comandum>();

    public virtual Hrana? IdHranaNavigation { get; set; }

    public virtual Utilizator? IdUtilizatorNavigation { get; set; }
}
