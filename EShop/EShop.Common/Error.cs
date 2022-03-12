namespace EShop.Common
{
    public class Error
    {
        private const string DEFAULT_ERROR_MESSAGE = "Server Error";

        public Error() => this.Description = DEFAULT_ERROR_MESSAGE;

        public Error(string message) => this.Description = message;

        public string Description { get; private set; }
    }
}
