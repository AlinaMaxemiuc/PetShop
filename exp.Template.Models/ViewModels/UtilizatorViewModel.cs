using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exp.Template.Models.ViewModels
{
    public class UtilizatorViewModel
    {
        public int Id { get; set; }

        public string? Nume { get; set; }

        public string? Prenume { get; set; }

        public string? Email { get; set; }

        public string? Parola { get; set; }
        public bool? IsDeleted { get; set; }
    }
    public class SimpleUserViewModel
    {
        public string Id { get; set; }
        public string? Nume { get; set; }
        public string? Prenume { get; set; }
        public string? Email { get; set; }
    }
    public class UpdateUserViewModel
    {
        [Required]
        [Display(Name = "Id")]
        public string Id { get; set; } = null!;

        [Required(ErrorMessage = "FirstName is required")]
        [StringLength(30, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        [RegularExpression(@"^[a-zA-Z][a-zA-Z0-9 _-]*$",
            ErrorMessage = "The firstName must consists of 2 to 30 characters inclusive, can only have alphanumeric characters, underscores (_) and hyphens (-)!")]
        [Display(Name = "FirstName")]
        public string Nume { get; set; } = null!;

        [Required(ErrorMessage = "LastName is required")]
        [StringLength(30, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        [RegularExpression(@"^[a-zA-Z][a-zA-Z0-9 _-]*$",
           ErrorMessage = "The lastName must consists of 2 to 30 characters inclusive, can only have alphanumeric characters, underscores (_) and hyphens (-)!")]
        [Display(Name = "LastName ")]
        public string Prenume { get; set; } = null!;

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        [Display(Name = "Email")]
        public string? Email { get; set; } = null!;

    }
    public class CreateClientViewModel
    {
        [Required(ErrorMessage = "Client first name is required")]
        public string? Nume { get; set; }

        [Required(ErrorMessage = "Client last name is required")]
        public string? Prenume { get; set; }

        [Required(ErrorMessage = "Client email is required")]
        public string? Email { get; set; }
    }
    public class UserList
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
    }
}
