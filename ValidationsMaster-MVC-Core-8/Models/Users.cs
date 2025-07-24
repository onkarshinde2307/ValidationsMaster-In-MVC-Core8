using System.ComponentModel.DataAnnotations;

namespace ValidationsMaster_MVC_Core_8.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "👤 Full name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters")]
        [Display(Name = "Full Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "📧 Email is required")]
        [EmailAddress(ErrorMessage = "Enter a valid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "🔒 Password is required")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "🔒 Confirm your password")]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "📱 Mobile number is required")]
        [Phone(ErrorMessage = "Enter a valid phone number")]
        [RegularExpression(@"^[6-9]\d{9}$", ErrorMessage = "Mobile number must start with 6-9 and be 10 digits")]
        public string Mobile { get; set; }

        [Required(ErrorMessage = "🎂 Date of Birth is required")]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "⚧️ Please select gender")]
        public string Gender { get; set; }

        [Range(18, 60, ErrorMessage = "Age must be between 18 and 60")]
        public int Age { get; set; }

        [Required(ErrorMessage = "🗺️ Country is required")]
        public string Country { get; set; }

        [MustAcceptTerms(ErrorMessage = "📜 You must accept the terms and conditions")]
        [Display(Name = "Accept Terms & Conditions")]
        public bool AcceptTerms { get; set; }
    }

    // Custom validation attribute for Terms checkbox
    public class MustAcceptTermsAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return value is bool accepted && accepted;
        }
    }
}
