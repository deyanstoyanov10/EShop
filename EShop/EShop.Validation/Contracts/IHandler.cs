namespace EShop.Validation.Contracts
{
    using Common.Result;

    public interface IHandler<TObject>
        where TObject : class
    {
        Task<Result> Execute(TObject model);

        IHandler<TObject> SetNext(IHandler<TObject> handler);
    }
}
