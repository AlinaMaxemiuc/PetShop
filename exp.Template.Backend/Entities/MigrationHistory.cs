﻿using System;
using System.Collections.Generic;

namespace exp.Template.Backend.Entities;

public partial class MigrationHistory
{
    public string MigrationId { get; set; } = null!;

    public string ContextKey { get; set; } = null!;

    public byte[] Model { get; set; } = null!;

    public string ProductVersion { get; set; } = null!;
}
