namespace EShop.Common.Helpers
{
    using System.Linq.Expressions;

    public static class PredicateBuilder
    {
        public static Expression<Func<T, bool>> True<T>() => func => true;
        public static Expression<Func<T, bool>> False<T>() => func => false;

        public static Expression<Func<T, bool>> Or<T>(
            this Expression<Func<T, bool>> firstExpression,
            Expression<Func<T, bool>> secondExpression)
        {
            var invokedExpression = Expression.Invoke(secondExpression, firstExpression.Parameters.Cast<Expression>());
            return Expression.Lambda<Func<T, bool>>(Expression.OrElse(firstExpression.Body, invokedExpression), firstExpression.Parameters);
        }

        public static Expression<Func<T, bool>> And<T>(
            this Expression<Func<T, bool>> firstExpression,
            Expression<Func<T, bool>> secondExpression)
        {
            var invokedExpression = Expression.Invoke(secondExpression, firstExpression.Parameters.Cast<Expression>());
            return Expression.Lambda<Func<T, bool>>(Expression.AndAlso(firstExpression.Body, invokedExpression), firstExpression.Parameters);
        }
    }
}
