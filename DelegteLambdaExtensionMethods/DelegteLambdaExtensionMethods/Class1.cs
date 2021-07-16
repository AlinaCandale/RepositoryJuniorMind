using System;
using System.Collections.Generic;

namespace DelegteLambdaExtensionMethods
{
    public static class Class1
    {
        public static bool All<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null || predicate == null)
            {
                throw new ArgumentNullException();
            }

            foreach (TSource current in source)
            {
                if (!predicate(current))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool Any<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null || predicate == null)
            {
                throw new ArgumentNullException();
            }

            foreach (TSource current in source)
            {
                if (predicate(current))
                {
                    return true;
                }
            }

            return false;
        }

        public static TSource First<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null || predicate == null)
            {
                throw new ArgumentNullException();
            }

            foreach (TSource current in source)
            {
                if (predicate(current))
                {
                    return current;
                }
            }

            throw new InvalidOperationException("No items matched the predicate");
        }

        public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            if (source == null || selector == null)
            {
                throw new ArgumentNullException();
            }

            foreach (var item in source)
            {
                yield return selector(item);
            }
        }

        public static IEnumerable<TResult> SelectMany<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, IEnumerable<TResult>> selector)
        {
            if (source == null || selector == null)
            {
                throw new ArgumentNullException();
            }

            foreach (TSource item in source)
            {
                foreach (TResult result in selector(item))
                {
                    yield return result;
                }
            }
        }

        public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null || predicate == null)
            {
                throw new ArgumentNullException();
            }

            return WhereImpl(source, predicate);
        }

        private static IEnumerable<TSource> WhereImpl<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            foreach (TSource item in source)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }

        
        //public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(
        //        this IEnumerable<TSource> source,
        //        Func<TSource, TKey> keySelector,
        //        Func<TSource, TElement> elementSelector);

        //    public static IEnumerable<TResult> Zip<TFirst, TSecond, TResult>(
        //this IEnumerable<TFirst> first,
        //IEnumerable<TSecond> second,
        //Func<TFirst, TSecond, TResult> resultSelector);

        //    public static IEnumerable<TResult> Zip<TFirst, TSecond, TResult>(
        //this IEnumerable<TFirst> first,
        //IEnumerable<TSecond> second,
        //Func<TFirst, TSecond, TResult> resultSelector);

        //    public static TAccumulate Aggregate<TSource, TAccumulate>(
        //this IEnumerable<TSource> source,
        //TAccumulate seed,
        //Func<TAccumulate, TSource, TAccumulate> func);

        //    public static IEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(
        //this IEnumerable<TOuter> outer,
        //IEnumerable<TInner> inner,
        //Func<TOuter, TKey> outerKeySelector,
        //Func<TInner, TKey> innerKeySelector,
        //Func<TOuter, TInner, TResult> resultSelector);

        //    public static IEnumerable<TSource> Distinct<TSource>(
        //this IEnumerable<TSource> source,
        //IEqualityComparer<TSource> comparer);

        //    public static IEnumerable<TSource> Union<TSource>(
        //this IEnumerable<TSource> first,
        //IEnumerable<TSource> second,
        //IEqualityComparer<TSource> comparer);

        //    public static IEnumerable<TSource> Intersect<Source>(
        //this IEnumerable<TSource> first,
        //IEnumerable<TSource> second,
        //IEqualityComparer<TSource> comparer);

        //    public static IEnumerable<TSource> Except<TSource>(
        //this IEnumerable<TSource> first,
        //IEnumerable<TSource> second,
        //IEqualityComparer<TSource> comparer);

        //    public static IEnumerable<TResult> GroupBy<TSource, TKey, TElement, TResult>(
        //this IEnumerable<TSource> source,
        //Func<TSource, TKey> keySelector,
        //Func<TSource, TElement> elementSelector,
        //Func<TKey, IEnumerable<TElement>, TResult> resultSelector,
        //IEqualityComparer<TKey> comparer);

        //    public static IOrderedEnumerable<TSource> OrderBy<TSource, TKey>(
        //this IEnumerable<TSource> source,
        //Func<TSource, TKey> keySelector,
        //IComparer<TKey> comparer);

        //    public static IOrderedEnumerable<TSource> ThenBy<TSource, TKey>(
        //this IOrderedEnumerable<TSource> source,
        //Func<TSource, TKey> keySelector,
        //IComparer<TKey> comparer);


    }
}
