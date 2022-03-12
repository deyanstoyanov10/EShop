namespace EShop.Validation.Contracts
{
    using Common.Result;

    public interface IResultHandler<TObject, TObjectResult>
            where TObject : class
    {
        Task<Result<TObjectResult>> Execute(TObject model);

        IResultHandler<TObject, TObjectResult> SetNext(IResultHandler<TObject, TObjectResult> handler);
    }
}