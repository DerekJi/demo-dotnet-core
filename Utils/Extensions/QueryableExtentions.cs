using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace Utils.Extensions
{
    public static class QueryableExtentions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="condition"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> 
            WhereIf<TSource>
            (this IEnumerable<TSource> source,
            bool condition,
            Func<TSource, bool> predicate)
        {
            return condition
                ? source.Where(predicate)
                : source;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="source"></param>
        /// <param name="condition"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static IQueryable<T> 
            IncludeIf<T, TProperty>
            (this IQueryable<T> source, 
            bool condition, 
            Expression<Func<T, TProperty>> path)
            where T : class
        {
            return condition
                ? source.Include(path)
                : source;
        }
    }
}
