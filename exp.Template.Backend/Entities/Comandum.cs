﻿using System;
using System.Collections.Generic;

namespace exp.Template.Backend.Entities;

public partial class Comandum
{
    public int Id { get; set; }

    public int? IdUtilizator { get; set; }

    public int? IdAbonament { get; set; }

    public DateOnly? DataComenzii { get; set; }

    public decimal? Total { get; set; }

    public bool? Discount { get; set; }

    public virtual Abonament? IdAbonamentNavigation { get; set; }

    public virtual Utilizator? IdUtilizatorNavigation { get; set; }

    public virtual ICollection<Livrari> Livraris { get; set; } = new List<Livrari>();
}