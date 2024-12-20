using exp.Template.Infrastructure.Context;
using exp.Template.Infrastructure.Entities;
using exp.Template.Infrastructure.Repositories.Animals;
using exp.Template.Infrastructure.Repositories.Generic;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exp.Template.Infrastructure.Repositories.Abonaments
{
    public class AbonamentRepository : GenericRepository<Abonament>, IAbonamentRepository
    {
        public AbonamentRepository(AnimalsFoodContext context) : base(context) { }

    }
}
