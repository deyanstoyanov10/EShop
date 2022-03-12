namespace EShop.Services.Providers.Contracts
{
    using System;

    public interface IDateTimeProvider
    {
        DateTime GetDateTimeNow();
    }
}
