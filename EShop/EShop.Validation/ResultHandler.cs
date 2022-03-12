namespace EShop.Validation
{
    using Contracts;
    using Common.Result;

    public abstract class ResultHandler<TObject, TObjectResult> : IResultHandler<TObject, TObjectResult>
        where TObject : class
    {
        protected IResultHandler<TObject, TObjectResult> _next;

        public abstract Task<Result<TObjectResult>> Execute(TObject model);

        public IResultHandler<TObject, TObjectResult> SetNext(IResultHandler<TObject, TObjectResult> handler)
        {
            _next = handler;

            return _next;
        }
    }
}
