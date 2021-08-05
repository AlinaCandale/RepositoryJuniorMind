using System;
using System.Collections.Generic;
using System.Linq;

namespace DelegteLambdaExtensionMethods
{
    public static class Class1
    {
        public static void EnsureIsNotNull<TSource>(TSource param, string nameOfParam)
        {
            if (param == null)
            {
                throw new ArgumentNullException(nameOfParam);
            }
        }

        public static bool All<TSource>(
            this IEnumerable<TSource> source, 
            Func<TSource, bool> predicate)
        {
            EnsureIsNotNull(source, nameof(source));
            EnsureIsNotNull(predicate, nameof(predicate));

            foreach (TSource current in source)
            {
                if (!predicate(current))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool Any<TSource>(
            this IEnumerable<TSource> source, 
            Func<TSource, bool> predicate)
        {
            EnsureIsNotNull(source, nameof(source));
            EnsureIsNotNull(predicate, nameof(predicate));

            foreach (TSource current in source)
            {
                if (predicate(current))
                {
                    return true;
                }
            }

            return false;
        }

        public static TSource First<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, bool> predicate)
        {
            EnsureIsNotNull(source, nameof(source));
            EnsureIsNotNull(predicate, nameof(predicate));

            foreach (TSource current in source)
            {
                if (predicate(current))
                {
                    return current;
                }
            }

            throw new InvalidOperationException("No items matched the predicate");
        }

        public static IEnumerable<TResult> Select<TSource, TResult>(
            this IEnumerable<TSource> source, 
            Func<TSource, TResult> selector)
        {
            EnsureIsNotNull(source, nameof(source));
            EnsureIsNotNull(selector, nameof(selector));

            foreach (var item in source)
            {
                yield return selector(item);
            }
        }

        public static IEnumerable<TResult> SelectMany<TSource, TResult>(
            this IEnumerable<TSource> source, 
            Func<TSource, IEnumerable<TResult>> selector)
        {
            EnsureIsNotNull(source, nameof(source));
            EnsureIsNotNull(selector, nameof(selector));

            foreach (TSource item in source)
            {
                foreach (TResult result in selector(item))
                {
                    yield return result;
                }
            }
        }

        public static IEnumerable<TSource> Where<TSource>(
            this IEnumerable<TSource> source, 
            Func<TSource, bool> predicate)
        {
            EnsureIsNotNull(source, nameof(source));
            EnsureIsNotNull(predicate, nameof(predicate));

            foreach (TSource item in source)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }

        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            Func<TSource, TElement> elementSelector)
        {
            EnsureIsNotNull(source, nameof(source));
            EnsureIsNotNull(keySelector, nameof(keySelector));
            EnsureIsNotNull(elementSelector, nameof(elementSelector));

            Dictionary<TKey, TElement> dict = new Dictionary<TKey, TElement>();
            foreach (TSource item in source)
            {
                if (dict.ContainsKey(keySelector(item)))
                {
                    continue;
                }

                dict.Add(keySelector(item), elementSelector(item));
            }
         
            return dict;
        }

        public static IEnumerable<TResult> Zip<TFirst, TSecond, TResult>(
            this IEnumerable<TFirst> first,
            IEnumerable<TSecond> second,
            Func<TFirst, TSecond, TResult> resultSelector)
        {
            EnsureIsNotNull(first, nameof(first));
            EnsureIsNotNull(second, nameof(second));

            using (IEnumerator<TFirst> iterator1 = first.GetEnumerator())
            using (IEnumerator<TSecond> iterator2 = second.GetEnumerator())
            {
                while (iterator1.MoveNext() && iterator2.MoveNext())
                {
                    yield return resultSelector(iterator1.Current, iterator2.Current);
                }
            }
        }

        public static TAccumulate Aggregate<TSource, TAccumulate>(
            this IEnumerable<TSource> source,
            TAccumulate seed,
            Func<TAccumulate, TSource, TAccumulate> func)
        {
            EnsureIsNotNull(source, nameof(source));
            EnsureIsNotNull(seed, nameof(seed));
            EnsureIsNotNull(func, nameof(func));

            foreach (TSource item in source)
            {
                seed = func(seed, item);
            }
            
            return seed;
        }

        public static IEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(
            this IEnumerable<TOuter> outer,
            IEnumerable<TInner> inner,
            Func<TOuter, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TOuter, TInner, TResult> resultSelector)
        {
            EnsureIsNotNull(outer, nameof(outer));
            EnsureIsNotNull(inner, nameof(inner));
            EnsureIsNotNull(outerKeySelector, nameof(outerKeySelector));
            EnsureIsNotNull(innerKeySelector, nameof(innerKeySelector));
            EnsureIsNotNull(resultSelector, nameof(resultSelector));

            var lookup = inner.ToLookup(innerKeySelector);
            foreach (var outerElement in outer)
            {
                var key = outerKeySelector(outerElement);
                foreach (var innerElement in lookup[key])
                {
                    yield return resultSelector(outerElement, innerElement);
                }
            }
        }

        public static IEnumerable<TSource> Distinct<TSource>(
            this IEnumerable<TSource> source,
            IEqualityComparer<TSource> comparer)
        {
            EnsureIsNotNull(source, nameof(source));

            HashSet<TSource> seenElements = new HashSet<TSource>(comparer);
            foreach (TSource item in source)
            {
                if (seenElements.Add(item))
                {
                    yield return item;
                }
            }
        }

        public static IEnumerable<TSource> Union<TSource>(
            this IEnumerable<TSource> first,
            IEnumerable<TSource> second,
            IEqualityComparer<TSource> comparer)
        {
            EnsureIsNotNull(first, nameof(first));
            EnsureIsNotNull(second, nameof(second));

            HashSet<TSource> seenElements = new HashSet<TSource>(comparer);
            foreach (TSource item in first)
            {
                if (seenElements.Add(item))
                {
                    yield return item;
                }
            }
            foreach (TSource item in second)
            {
                if (seenElements.Add(item))
                {
                    yield return item;
                }
            }
        }

        public static IEnumerable<TSource> Intersect<TSource>(
            this IEnumerable<TSource> first,
            IEnumerable<TSource> second,
            IEqualityComparer<TSource> comparer)
        {
            EnsureIsNotNull(first, nameof(first));
            EnsureIsNotNull(second, nameof(second));

            HashSet<TSource> intersectedElements = new HashSet<TSource>(second, comparer);
            foreach (TSource item in first)
            {
                if (intersectedElements.Remove(item))
                {
                    yield return item;
                }
            }
        }

        public static IEnumerable<TSource> Except<TSource>(
            this IEnumerable<TSource> first,
            IEnumerable<TSource> second,
            IEqualityComparer<TSource> comparer)
        {
            EnsureIsNotNull(first, nameof(first));
            EnsureIsNotNull(second, nameof(second));

            HashSet<TSource> bannedElements = new HashSet<TSource>(second, comparer);
            foreach (TSource item in first)
            {
                if (bannedElements.Add(item))
                {
                    yield return item;
                }
            }
        }

        public static IEnumerable<TResult> GroupBy<TSource, TKey, TElement, TResult>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            Func<TSource, TElement> elementSelector,
            Func<TKey, IEnumerable<TElement>, TResult> resultSelector,
            IEqualityComparer<TKey> comparer)
        {
            EnsureIsNotNull(source, nameof(source));
            EnsureIsNotNull(keySelector, nameof(keySelector));
            EnsureIsNotNull(elementSelector, nameof(elementSelector));
            EnsureIsNotNull(resultSelector, nameof(resultSelector));

            ILookup<TKey, TElement> lookup = source.ToLookup(keySelector, elementSelector, comparer);
            foreach (IGrouping<TKey, TElement> group in lookup)
            {
                yield return resultSelector(group.Key, group); 
            }
        }

        public static IOrderedEnumerable<TSource> OrderBy<TSource, TKey>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            IComparer<TKey> comparer)
        {
            EnsureIsNotNull(source, nameof(source));
            EnsureIsNotNull(keySelector, nameof(keySelector));

            return source.OrderBy(keySelector);
        }

        //public static IOrderedEnumerable<TSource> ThenBy<TSource, TKey>(
        //this IOrderedEnumerable<TSource> source,
        //Func<TSource, TKey> keySelector,
        //IComparer<TKey> comparer)
        //{
        //    EnsureIsNotNull(source, nameof(source));
        //    EnsureIsNotNull(keySelector, nameof(keySelector));
        //    
        //}


    }
}
