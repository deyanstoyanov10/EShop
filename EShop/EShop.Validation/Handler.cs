namespace EShop.Validation
{
    using Common.Result;
    using Validation.Contracts;

    public abstract class Handler<TObject> : IHandler<TObject>
        where TObject : class
    {
        protected IHandler<TObject> _next;

        public abstract Task<Result> Execute(TObject model);

        public IHandler<TObject> SetNext(IHandler<TObject> handler)
        {
            _next = handler;

            return _next;
        }
    }
}
