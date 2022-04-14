namespace EShop.Common.Authentication
{
    using System.ComponentModel.DataAnnotations;

    public class AuthenticationRecords
    {
        public record AppUserOutputModel(string token);

        public class LoginUserInputModel
        {
            public LoginUserInputModel() {}

            public LoginUserInputModel(string username, string password)
            {
                Username = username;
                Password = password;
            }

            [Required]
            public string Username { get; set; }

            [Required]
            public string Password { get; set; }
        }

        public class RegisterUserInputModel
        {
            [Required]
            public string FirstName { get; set; }

            [Required]
            public string LastName { get; set; }

            [Required]
            public string Username { get; set; }

            [Required]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }
    }
}
