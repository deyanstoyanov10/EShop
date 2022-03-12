namespace EShop.Common.ApiResponse
{
    public sealed class ApiResponse<T>
    {
        public ApiResponse() { }

        public ApiResponse(T data) => this.Data = data;

        public ApiResponse(IEnumerable<Error> errors)
        {
            if (errors.Any())
            {
                this.Errors = errors;
            }
            else
            {
                this.Errors = new List<Error>()
                {
                    new Error()
                };
            }
        }

        public T Data { get; private set; }

        public IEnumerable<Error> Errors { get; private set; } = new List<Error>();

        public bool Succeeded => !this.Errors.Any();

        public bool Failure => !this.Succeeded;
    }
}
