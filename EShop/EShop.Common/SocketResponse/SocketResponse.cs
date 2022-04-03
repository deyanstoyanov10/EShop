namespace EShop.Common.SocketResponse
{
    public class SocketResponse<T>
    {
        public SocketResponse() { }

        public SocketResponse(T data) => this.Data = data;

        public SocketResponse(IEnumerable<Error> errors)
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

        public T Data { get; set; }

        public IEnumerable<Error> Errors { get; set; } = new List<Error>();

        public bool Succeeded => !this.Errors.Any();

        public bool Failure => !this.Succeeded;
    }
}
