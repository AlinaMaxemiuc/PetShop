using System.ComponentModel.DataAnnotations;

namespace exp.Template.Models.ViewModels
{
    public class BaseTenantViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool? IsDeleted { get; set; }
        public string? ConnectionString { get; set; }
        public bool? Active { get; set; }
    }

    public class CreateTenantViewModel
    {
        [StringLength(200)]
        public string? Name { get; set; }

        [Required]
        [StringLength(500)]
        public string? ConnectionString { get; set; }
        public bool? Active { get; set; }
    }

    public class UpdateTenantViewModel : TenantActionsBy
    {
        [Required]
        public int Id { get; set; }

        [StringLength(200)]
        public string? Name { get; set; }

        [Required]
        [StringLength(500)]
        public string? ConnectionString { get; set; }
        public bool? Active { get; set; }
    }

    public class TenantActionsBy
    {
        public string? UserId { get; set; }
    }
}
