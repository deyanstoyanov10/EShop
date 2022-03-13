namespace EShop.Common.Authentication
{
    using System.ComponentModel.DataAnnotations;

    public class AuthenticationRecords
    {
        public record RegisterUserInputModel([Required] string firstName, [Required] string lastName, [Required] string username, [Required][EmailAddress] string email, [Required] string password);

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
    }
}
