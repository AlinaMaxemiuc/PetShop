using exp.Template.Infrastructure.Context;
using exp.Template.Infrastructure.Entities;
using exp.Template.Infrastructure.Repositories.Abonaments;
using exp.Template.Infrastructure.Repositories.Generic;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exp.Template.Infrastructure.Repositories.Foods
{
    public class HranaRepository : GenericRepository<Hrana>, IHranaRepository
    {
        public HranaRepository(AnimalsFoodContext context) : base(context) { }

    }
}
