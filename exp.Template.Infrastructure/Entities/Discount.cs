﻿using System;
using System.Collections.Generic;

namespace exp.Template.Infrastructure.Entities;

public partial class Discount
{
    public int Id { get; set; }

    public int? NumarComenzi { get; set; }

    public decimal? ProcentDiscount { get; set; }
}