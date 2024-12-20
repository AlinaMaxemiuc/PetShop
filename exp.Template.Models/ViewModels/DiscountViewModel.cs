using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exp.Template.Models.ViewModels
{
    public class DiscountViewModel
    {
        public int Id { get; set; }
        public int? NumarComenzi { get; set; }
        public decimal? ProcentDiscount { get; set; }
    }
}
