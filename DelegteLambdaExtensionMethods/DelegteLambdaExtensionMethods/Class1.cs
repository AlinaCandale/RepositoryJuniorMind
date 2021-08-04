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
            EnsureIsNotNull<IEnumerable<TSource>>(source, "In function All parameter 'source' is null");
            EnsureIsNotNull<Func<TSource, bool>>(predicate, "In function All parameter 'predicate' is null");

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
            EnsureIsNotNull<IEnumerable<TSource>>(source, "In function Any parameter 'source' is null");
            EnsureIsNotNull<Func<TSource, bool>>(predicate, "In function Any parameter 'predicate' is null");

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
            EnsureIsNotNull<IEnumerable<TSource>>(source, "In function First parameter 'source' is null");
            EnsureIsNotNull<Func<TSource, bool>>(predicate, "In function First parameter 'predicate' is null");

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
            EnsureIsNotNull<IEnumerable<TSource>>(source, "In function Select parameter 'source' is null");
            EnsureIsNotNull< Func<TSource, TResult>> (selector, "In function Select parameter 'selector' is null");

            foreach (var item in source)
            {
                yield return selector(item);
            }
        }

        public static IEnumerable<TResult> SelectMany<TSource, TResult>(
            this IEnumerable<TSource> source, 
            Func<TSource, IEnumerable<TResult>> selector)
        {
            EnsureIsNotNull<IEnumerable<TSource>>(source, "In function SelectMany parameter 'source' is null");
            EnsureIsNotNull<Func<TSource, IEnumerable<TResult>>>(selector, "In function SelectMany parameter 'selector' is null");

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
            EnsureIsNotNull<IEnumerable<TSource>>(source, "In function Where parameter 'source' is null");
            EnsureIsNotNull<Func<TSource, bool>>(predicate, "In function Where parameter 'predicate' is null");

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
            EnsureIsNotNull<IEnumerable<TSource>>(source, "In function ToDictionary parameter 'source' is null");
            EnsureIsNotNull<Func<TSource, TKey>>(keySelector, "In function ToDictionary parameter 'keySelector' is null");
            EnsureIsNotNull<Func<TSource, TElement>>(elementSelector, "In function ToDictionary parameter 'elementSelector' is null");

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
            EnsureIsNotNull<IEnumerable<TFirst>>(first, "In function Zip parameter 'first' is null");
            EnsureIsNotNull<IEnumerable<TSecond>>(second, "In function Zip parameter 'second' is null");

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
            EnsureIsNotNull<IEnumerable<TSource>>(source, "In function Aggregate parameter 'source' is null");
            EnsureIsNotNull<TAccumulate>(seed, "In function Aggregate parameter 'seed' is null");
            EnsureIsNotNull<Func<TAccumulate, TSource, TAccumulate>>(func, "In function Aggregate parameter 'func' is null");

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
            EnsureIsNotNull<IEnumerable<TOuter>>(outer, "In function Join parameter 'outer' is null");
            EnsureIsNotNull<IEnumerable<TInner>>(inner, "In function Join parameter 'inner' is null");
            EnsureIsNotNull<Func<TOuter, TKey>>(outerKeySelector, "In function Join parameter 'outerKeySelector' is null");
            EnsureIsNotNull<Func<TInner, TKey>>(innerKeySelector, "In function Join parameter 'innerKeySelector' is null");
            EnsureIsNotNull<Func<TOuter, TInner, TResult>>(resultSelector, "In function Join parameter 'resultSelector' is null");

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
            EnsureIsNotNull<IEnumerable<TSource>>(source, "In function Distinct parameter 'source' is null");

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
            EnsureIsNotNull<IEnumerable<TSource>>(first, "In function Union parameter 'first' is null");
            EnsureIsNotNull<IEnumerable<TSource>>(second, "In function Union parameter 'second' is null");

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
            EnsureIsNotNull<IEnumerable<TSource>>(first, "In function Intersect parameter 'first' is null");
            EnsureIsNotNull<IEnumerable<TSource>>(second, "In function Intersect parameter 'second' is null");

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
            EnsureIsNotNull<IEnumerable<TSource>>(first, "In function Except parameter 'first' is null");
            EnsureIsNotNull<IEnumerable<TSource>>(second, "In function Except parameter 'second' is null");

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
            EnsureIsNotNull<IEnumerable<TSource>>(source, "In function GroupBy parameter 'source' is null");
            EnsureIsNotNull<Func<TSource, TKey>>(keySelector, "In function GroupBy parameter 'keySelector' is null");
            EnsureIsNotNull<Func<TSource, TElement>>(elementSelector, "In function GroupBy parameter 'elementSelector' is null");
            EnsureIsNotNull<Func<TKey, IEnumerable<TElement>, TResult>>(resultSelector, "In function GroupBy parameter 'resultSelector' is null");

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
        //    EnsureIsNotNull<IEnumerable<TSource>>(source, "In function OrderBy parameter 'source' is null");
        //    EnsureIsNotNull<Func<TSource, TKey>>(keySelector, "In function OrderBy parameter 'keySelector' is null");
        //    
        //}

        //public static IOrderedEnumerable<TSource> ThenBy<TSource, TKey>(
        //this IOrderedEnumerable<TSource> source,
        //Func<TSource, TKey> keySelector,
        //IComparer<TKey> comparer)
        //{
        //    EnsureIsNotNull<IEnumerable<TSource>>(source, "In function ThenBy parameter 'source' is null");
        //    EnsureIsNotNull<Func<TSource, TKey>>(keySelector, "In function ThenBy parameter 'keySelector' is null");
        //    
        //}


    }
}
