namespace EShop.Common.Authentication
{
    using System.ComponentModel.DataAnnotations;

    public class AuthenticationRecords
    {
        public record RegisterUserInputModel([Required] string firstName, [Required] string lastName, [Required] string username, [Required][EmailAddress] string email, [Required] string password);

        public record LoginUserInputModel([Required] string username, [Required] string password);

        public record AppUserOutputModel(string token);
    }
}
