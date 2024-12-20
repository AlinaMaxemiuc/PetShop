using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exp.Template.Services.Animals
{
    public interface IAnimalService
    {
        Task DeleteVirtual(int id);
    }
}
