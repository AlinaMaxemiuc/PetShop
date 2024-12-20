using exp.Template.Infrastructure.Context;
using exp.Template.Infrastructure.Entities;
using exp.Template.Infrastructure.Repositories.Comenzi;
using exp.Template.Infrastructure.Repositories.Generic;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exp.Template.Infrastructure.Repositories.Discounts
{
    public class DiscountRepository : GenericRepository<Discount>, IDiscountRepository
    {
        public DiscountRepository(AnimalsFoodContext context) : base(context) { }

    }
}
