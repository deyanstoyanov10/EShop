namespace EShop.Infrastructure.Extensions
{
    using Common.Result;
    using Common.SocketResponse;

    public static class SocketResponseExtensions
    {
        public static SocketResponse<T> ToSocketResponse<T>(this Result<T> result)
            => new SocketResponse<T>(result.Data);

        public static SocketResponse<T> ToErrorSocketResponse<T>(this Result<T> result)
            => new SocketResponse<T>(result.Errors);
    }
}
