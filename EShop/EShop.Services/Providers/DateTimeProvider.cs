namespace EShop.Services.Providers
{
    using Contracts;

    using System;

    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime GetDateTimeNow()
            => DateTime.UtcNow;
    }
}
