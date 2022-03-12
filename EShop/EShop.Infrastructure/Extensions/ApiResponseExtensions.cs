namespace EShop.Infrastructure.Extensions
{
    using Common.Result;
    using Common.ApiResponse;

    public static class ApiResponseExtensions
    {
        public static ApiResponse<T> ToApiResponse<T>(this Result<T> result)
            => new ApiResponse<T>(result.Data);

        public static ApiResponse<T> ToErrorApiResponse<T>(this Result<T> result)
            => new ApiResponse<T>(result.Errors);
    }
}
