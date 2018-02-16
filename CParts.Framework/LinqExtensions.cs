using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

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

        public static IQueryable<TEntity> Paginate<TEntity>(this IQueryable<TEntity> dbSet,
            Expression<Func<TEntity, IComparable>> keySelector, 
            OrderDirection direction = OrderDirection.Ascending,
            int page = 1,
            int pageSize = int.MaxValue)
        {
            if (direction == OrderDirection.Ascending)
            {
                dbSet.OrderBy(keySelector);
            }
            else
            {
                dbSet.OrderByDescending(keySelector);
            }
            
            return dbSet.Skip((page - 1) * pageSize).Take(pageSize);
        }
    }

    public enum OrderDirection
    {
        Ascending,
        Descending
    }
}