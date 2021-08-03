using System;
using System.Collections.Generic;
using System.Linq;

namespace DelegteLambdaExtensionMethods
{
    public static class Class1
    {

        //EnsureIsNotNull<TSource>(IEnumerable<TSource> source)
        

        public static bool All<TSource>(
            this IEnumerable<TSource> source, 
            Func<TSource, bool> predicate)
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

        public static bool Any<TSource>(
            this IEnumerable<TSource> source, 
            Func<TSource, bool> predicate)
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

        public static TSource First<TSource>(
            this IEnumerable<TSource> source, 
            Func<TSource, bool> predicate)
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

        public static IEnumerable<TResult> Select<TSource, TResult>(
            this IEnumerable<TSource> source, 
            Func<TSource, TResult> selector)
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

        public static IEnumerable<TResult> SelectMany<TSource, TResult>(
            this IEnumerable<TSource> source, 
            Func<TSource, IEnumerable<TResult>> selector)
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

        public static IEnumerable<TSource> Where<TSource>(
            this IEnumerable<TSource> source, 
            Func<TSource, bool> predicate)
        {
            if (source == null || predicate == null)
            {
                throw new ArgumentNullException();
            }

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
            if (source == null || keySelector == null || elementSelector == null)
            {
                throw new ArgumentNullException();
            }

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
            if (first == null || second == null)
            {
                throw new ArgumentNullException();
            }

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
            if (source == null || seed == null || func == null)
            {
                throw new ArgumentNullException();
            }

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
            if (outer == null || inner == null || outerKeySelector == null
                || innerKeySelector == null || resultSelector == null)
            {
                throw new ArgumentNullException();
            }
            
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
            if (source == null)
            {
                throw new ArgumentNullException();
            }
            
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
            if (first == null || second == null)
            {
                throw new ArgumentNullException();
            }

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
            if (first == null || second == null)
            {
                throw new ArgumentNullException();
            }

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
            if (first == null || second == null)
            {
                throw new ArgumentNullException();
            }

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
            if (source == null || keySelector == null ||
                elementSelector == null || resultSelector == null)
            {
                throw new ArgumentNullException();
            }

            ILookup<TKey, TElement> lookup = source.ToLookup(keySelector, elementSelector, comparer);
            foreach (IGrouping<TKey, TElement> group in lookup)
            {
                yield return resultSelector(group.Key, group); 
            }
        }

        //public static IOrderedEnumerable<TSource> OrderBy<TSource, TKey>(
        //    this IEnumerable<TSource> source,
        //    Func<TSource, TKey> keySelector,
        //    IComparer<TKey> comparer)
        //{
        //    if (source == null || keySelector == null)
        //    {
        //        throw new ArgumentNullException();
        //    }
        //}

        //public static IOrderedEnumerable<TSource> ThenBy<TSource, TKey>(
        //this IOrderedEnumerable<TSource> source,
        //Func<TSource, TKey> keySelector,
        //IComparer<TKey> comparer)
        //{
        //    if (source == null || keySelector == null)
        //    {
        //        throw new ArgumentNullException();
        //    }
        //}


    }
}
