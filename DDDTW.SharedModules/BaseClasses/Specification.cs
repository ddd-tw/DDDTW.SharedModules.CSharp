using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DDDTW.SharedModules.BaseClasses
{
    public class Specification<T>
    {
        protected Specification()
        {
        }

        public Specification(Expression<Func<T, bool>> predicate)
        {
            this.Prediction = predicate;
        }

        public Specification(T entity, Expression<Func<T, bool>> predicate)
        {
            this.Instance = entity;
            this.Prediction = predicate;
        }

        public Expression<Func<T, bool>> Prediction { get; protected set; }

        public T Instance { get; protected set; }

        public static Specification<T> operator &(Specification<T> left, Specification<T> right)
        {
            Expression<Func<T, bool>> leftPredicate = left.Prediction;
            Expression<Func<T, bool>> rightPredicate = right.Prediction;

            BinaryExpression andAlsoExpression =
                Expression.AndAlso(
                    leftPredicate.Body,
                    new ParameterExpressionReWriter(leftPredicate.Parameters, rightPredicate.Parameters).Visit(rightPredicate.Body) ?? throw new InvalidOperationException());

            Expression<Func<T, bool>> predicateExpression =
                Expression.Lambda<Func<T, bool>>(andAlsoExpression, leftPredicate.Parameters);

            return new Specification<T>(predicateExpression);
        }

        public static Specification<T> operator |(Specification<T> left, Specification<T> right)
        {
            Expression<Func<T, bool>> leftPredicate = left.Prediction;
            Expression<Func<T, bool>> rightPredicate = right.Prediction;

            BinaryExpression orElseExpression =
                Expression.OrElse(
                    leftPredicate.Body,
                    new ParameterExpressionReWriter(leftPredicate.Parameters, rightPredicate.Parameters).Visit(rightPredicate.Body) ?? throw new InvalidOperationException());

            Expression<Func<T, bool>> predicateExpression =
                Expression.Lambda<Func<T, bool>>(orElseExpression, left.Prediction.Parameters.Single());

            return new Specification<T>(predicateExpression);
        }

        public static implicit operator Expression<Func<T, bool>>(Specification<T> specification)
        {
            return specification.Prediction;
        }

        public bool IsSatisfy()
        {
            return this.Prediction.Compile()(this.Instance);
        }
    }

    public class ParameterExpressionReWriter : ExpressionVisitor
    {
        private readonly Dictionary<ParameterExpression, ParameterExpression> parameterExpressionMap;

        public ParameterExpressionReWriter(IEnumerable<ParameterExpression> firstParams, IEnumerable<ParameterExpression> secondParams)
        {
            this.parameterExpressionMap =
                firstParams
                    .Zip(secondParams, (firstParam, secondParam) => new { firstParam, secondParam })
                    .ToDictionary(key => key.secondParam, value => value.firstParam);
        }

        protected override Expression VisitParameter(ParameterExpression parameterExpression)
        {
            if (this.parameterExpressionMap.TryGetValue(parameterExpression, out var replacement))
            {
                parameterExpression = replacement;
            }

            return base.VisitParameter(parameterExpression);
        }
    }
}