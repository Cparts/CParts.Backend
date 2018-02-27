using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CParts.Framework
{
    public static class LinqExtensions
    {
        public static IQueryable<TEntity> DistinctBy<TEntity, TKey>(this IQueryable<TEntity> set,
            Expression<Func<TEntity, TKey>> distinctProperty)
            where TKey : IEquatable<TKey>
        {
            //TODO: Fix. Can lead to deep performance problems
            return set.GroupBy(distinctProperty).Select(x => x.First());
//            return set.Distinct(
//                new DynamicLambdaComparer<TEntity>((e1, e2) => distinctProperty(e1).Equals(distinctProperty(e2))));
        }

        private class LambdaComparer<T> : IEqualityComparer<T>
        {
            private readonly Func<T, T, bool> _comparer;
            private readonly Func<T, int> _hasher;

            public LambdaComparer(Func<T, T, bool> comparisionFunc) : this(comparisionFunc, o => 0)
            {
            }

            public LambdaComparer(Func<T, T, bool> comparisionFunc, Func<T, int> hashFunc)
            {
                _comparer = comparisionFunc;
                _hasher = hashFunc;
            }

            public bool Equals(T x, T y)
            {
                return _comparer(x, y);
            }

            public int GetHashCode(T obj)
            {
                return _hasher(obj);
            }
        }

        public static IOrderedQueryable<TEntity> OrderBy<TEntity>(this IQueryable<TEntity> dbSet,
            Expression<Func<TEntity, IComparable>> keySelector,
            OrderDirection direction)
        {
            IOrderedQueryable<TEntity> resultingSequence;
            
            if (direction == OrderDirection.Ascending)
            {
                resultingSequence = dbSet.OrderBy(keySelector);
            }
            else
            {
                resultingSequence = dbSet.OrderByDescending(keySelector);
            }

            return resultingSequence;
        }

        public static async Task<PaginatedResult<TEntity>> PaginateAsync<TEntity>(this IQueryable<TEntity> query,
            int pageSize, int pageNumber,
            Expression<Func<TEntity, IComparable>> orderKeySelector,
            OrderDirection orderDirection) where TEntity : class
        {
            var elementOffset = (pageNumber - 1) * pageSize;
            var totalCount = await query.CountAsync();
            var orderedQuery = query.OrderBy(orderKeySelector, orderDirection);
            var pageContents = await orderedQuery.Skip(elementOffset).Take(pageSize).AsNoTracking().ToListAsync();
            var result = new PaginatedResult<TEntity>
            {
                TotalCount = totalCount,
                PageSize = pageSize,
                PageNumber = pageNumber,
                PageContent = pageContents
            };

            return result;
        }
    }

    public class PaginatedResult<TResult>
    {
        public int TotalCount { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public ICollection<TResult> PageContent { get; set; }
    }

    public enum OrderDirection
    {
        Ascending,
        Descending
    }
}