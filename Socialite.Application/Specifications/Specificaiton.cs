using Socialite.Application.Filters;
using Socialite.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Socialite.Application.Specifications
{
    public abstract class Specification<TEntity> where TEntity : BaseEntity
    {
        public Expression<Func<TEntity, bool>>? Criteria { get; }
        public List<Expression<Func<TEntity, object>>> IncludeExpressions { get; } = new();
        public Expression<Func<TEntity, object>>? OrderByExpression { get; private set; }
        public Expression<Func<TEntity, object>>? OrderByDescendingExpression { get; private set; }

        public IFilter<TEntity>[]? Filters { get; set; }

        public Specification(Expression<Func<TEntity, bool>>? criteria)
            => Criteria = criteria;

        protected void AddInclude(
            Expression<Func<TEntity, object>> includeExpression
            ) => IncludeExpressions.Add(includeExpression);

        protected void AddOrderBy(
            Expression<Func<TEntity, object>> orderbyExpression
            ) => OrderByExpression = orderbyExpression;

        protected void AddOrderByDescending(
            Expression<Func<TEntity, object>> orderbyDescendingExpression
            ) => OrderByDescendingExpression = orderbyDescendingExpression;
        protected void SetFilters(params IFilter<TEntity>[] filters)
            => Filters = filters;
    }
}
