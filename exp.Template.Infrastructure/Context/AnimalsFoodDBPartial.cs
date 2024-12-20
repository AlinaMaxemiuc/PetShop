using exp.Template.Infrastructure.Entities;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exp.Template.Infrastructure.Context
{
    public partial class AnimalsFoodDB : DbContext
    {
       /* partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animale>().HasQueryFilter(x => !x.IsDeleted);
        }
       */
    }
}
