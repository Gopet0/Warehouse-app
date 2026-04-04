using System.ComponentModel.DataAnnotations;
namespace Warehouse.Models
{
        public class LoginViewModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; } = string.Empty;

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; } = string.Empty;

            [Display(Name = "Remember me")]
            public bool RememberMe { get; set; }
        }

        public class RegisterViewModel
        {
            [Required]
            [StringLength(50)]
            [Display(Name = "First Name")]
            public string FirstName { get; set; } = string.Empty;

            [Required]
            [StringLength(50)]
            [Display(Name = "Last Name")]
            public string LastName { get; set; } = string.Empty;

            [Required]
            [EmailAddress]
            public string Email { get; set; } = string.Empty;

            [Required]
            [DataType(DataType.Password)]
            [StringLength(100, MinimumLength = 6)]
            public string Password { get; set; } = string.Empty;

            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Confirm Password")]
            [Compare("Password", ErrorMessage = "Passwords do not match.")]
            public string ConfirmPassword { get; set; } = string.Empty;
        }

        public class UserViewModel
        {
            public string Id { get; set; } = string.Empty;
            public string FullName { get; set; } = string.Empty;
            public string Email { get; set; } = string.Empty;
            public bool IsActive { get; set; }
            public DateTime HireDate { get; set; }
            public List<string> Roles { get; set; } = new();
        }

        public class EditUserViewModel
        {
            public string Id { get; set; } = string.Empty;

            [Required]
            [StringLength(50)]
            [Display(Name = "First Name")]
            public string FirstName { get; set; } = string.Empty;

            [Required]
            [StringLength(50)]
            [Display(Name = "Last Name")]
            public string LastName { get; set; } = string.Empty;

            [EmailAddress]
            public string Email { get; set; } = string.Empty;

            [Display(Name = "Active")]
            public bool IsActive { get; set; }

            [Display(Name = "Hire Date")]
            [DataType(DataType.Date)]
            public DateTime HireDate { get; set; }

            public List<string> AvailableRoles { get; set; } = new();
            public List<string> SelectedRoles { get; set; } = new();
        }
    }

