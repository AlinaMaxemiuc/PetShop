using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exp.Template.Models.ViewModels
{
    public class HranaViewModel
    {
        public int Id { get; set; }

        public string? Nume { get; set; }

        public string? Descriere { get; set; }

        public decimal? Pret { get; set; }

        public int? Stoc { get; set; }

       // public virtual ICollection<Abonament> Abonaments { get; set; } = new List<Abonament>();
    }
    public class CreateHranaViewModel
    {
        [Required(ErrorMessage = "Name is required")]
        public string? Nume { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string? Descriere { get; set; } = null!;

        [Required(ErrorMessage = "Price is required")]
        public decimal? Pret { get; set; } = null!; 

        [Required(ErrorMessage = "Available quantity is required")]
        public int? Stoc { get; set; } = null!;

    }
    public class UpdateHranaViewModel : CreateHranaViewModel{ }
}
