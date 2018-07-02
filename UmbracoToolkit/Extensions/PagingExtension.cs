using System;
using System.Linq;

namespace UmbracoToolkit.Extensions
{
    public static class PagingExtension
    {
        /// <summary>
        /// Pagings the specified current.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query">The query.</param>
        /// <param name="current">The current.</param>
        /// <param name="take">The take.</param>
        /// <returns>The IQueryable after paging</returns>
        public static IQueryable<T> Paging<T>(this IQueryable<T> query, int? current, int? take) where T : class
        {
            if (current.HasValue && take.HasValue)
            {
                var t = (int)take;
                var skip = (Math.Max(1, (int)current) - 1) * t; // (current - 1) * take

                return query.Skip(skip).Take(t);
            }

            return query;
        }

        public static IQueryable<T> Paging<T>(this IOrderedEnumerable<T> query, int? current, int? take) where T : class
            => query.AsQueryable().Paging(current, take);
    }
}
