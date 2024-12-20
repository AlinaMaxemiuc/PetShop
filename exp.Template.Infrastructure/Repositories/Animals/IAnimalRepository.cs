using exp.Template.Infrastructure.Entities;
using exp.Template.Infrastructure.Repositories.Generic;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exp.Template.Infrastructure.Repositories.Animals
{
    public interface IAnimalRepository: IGenericRepository<Animale>
    {
    }
}
