using System.ComponentModel.DataAnnotations;
namespace SWP_template.Models
{
    public class AccountViewModel
    {
    }
    public class LoginViewModel
    {
        [Required(ErrorMessage = "This is required field")]
        [Display(Name = "Account")]
        public string Account { get; set; }

        [Required(ErrorMessage = "Please fill your password")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    // public class UserConstant(){
    //     public static string USER_CONSTANT = "USER_CONSTANT";
    // }

public class RegisterViewModel
    {

        [Required(ErrorMessage = "This is required field")]
        [Display(Name = "Account")]
        public string Account { get; set; }
        
        [Required(ErrorMessage = "This is required field")]
        [EmailAddress(ErrorMessage = "You are not filling an email")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "This is required field")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        
        [Required(ErrorMessage = "This is required field")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
    
}
