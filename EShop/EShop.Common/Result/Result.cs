namespace EShop.Common.Result
{
    public class Result
    {
        public Result() {}

        public Result(string error) => this.Errors = new List<Error>() { new Error(error) };

        public Result(List<string> errors) => this.Errors = errors.Select(error => new Error(error)).ToList();

        public Result(List<Error> errors) => this.Errors = errors;

        public List<Error> Errors { get; private set; } = new List<Error>();

        public bool Succeeded => !this.Errors.Any();

        public bool Failure => !this.Succeeded;

        public static implicit operator Result(bool status)
            => status == true ? new Result() : new Result("Server Error");

        public static implicit operator Result(string error)
            => new Result(error);

        public static implicit operator Result(List<string> errors)
            => new Result(errors);
    }

    public sealed class Result<TData> : Result
    {
        public Result(TData data) => this.Data = data;

        public Result(string error)
            : base(error) {}

        public Result(List<string> errors)
            : base(errors) {}

        public Result(List<Error> errors)
            : base(errors) {}

        public TData Data { get; private set; }

        public static implicit operator Result<TData>(TData data)
            => new Result<TData>(data);

        public static implicit operator Result<TData>(string error)
            => new Result<TData>(error);

        public static implicit operator Result<TData>(List<string> errors)
            => new Result<TData>(errors);

        public static implicit operator Result<TData>(List<Error> errors)
            => new Result<TData>(errors);
    }
}
