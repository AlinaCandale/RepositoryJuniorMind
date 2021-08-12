using System;
using System.Collections;
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

            using (IEnumerator<TFirst> firstInterator = first.GetEnumerator())
            using (IEnumerator<TSecond> secondInterator = second.GetEnumerator())
            {
                while (firstInterator.MoveNext() && secondInterator.MoveNext())
                {
                    yield return resultSelector(firstInterator.Current, secondInterator.Current);
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

            TAccumulate result = seed;
            foreach (TSource item in source)
            {
                result = func(result, item);
            }

            return result; 
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

            foreach (TOuter outerElement in outer)
            {
                TKey outerKey = outerKeySelector(outerElement);
                foreach (TInner innerElement in inner)
                {
                    TKey innerKey = innerKeySelector(innerElement);
                    if (Equals(outerKey, innerKey))
                    {
                        yield return resultSelector(outerElement, innerElement);
                    }
                }
            }
        }

        public static IEnumerable<TSource> Distinct<TSource>(
            this IEnumerable<TSource> source,
            IEqualityComparer<TSource> comparer)
        {
            EnsureIsNotNull(source, nameof(source));

            return new HashSet<TSource>(source, comparer);
        }

        public static IEnumerable<TSource> Union<TSource>(
            this IEnumerable<TSource> first,
            IEnumerable<TSource> second,
            IEqualityComparer<TSource> comparer)
        {
            EnsureIsNotNull(first, nameof(first));
            EnsureIsNotNull(second, nameof(second));

            HashSet<TSource> allUniqueElements = new HashSet<TSource>(first, comparer);
            allUniqueElements.UnionWith(second);
            foreach (TSource item in allUniqueElements)
            {
                yield return item;
            }
        }

        public static IEnumerable<TSource> Intersect<TSource>(
            this IEnumerable<TSource> first,
            IEnumerable<TSource> second,
            IEqualityComparer<TSource> comparer)
        {
            EnsureIsNotNull(first, nameof(first));
            EnsureIsNotNull(second, nameof(second));

            HashSet<TSource> intersectedElements = new HashSet<TSource>(first, comparer);
            intersectedElements.IntersectWith(second);
            foreach (TSource item in intersectedElements)
            {
                yield return item;
            }
        }

        public static IEnumerable<TSource> Except<TSource>(
            this IEnumerable<TSource> first,
            IEnumerable<TSource> second,
            IEqualityComparer<TSource> comparer)
        {
            EnsureIsNotNull(first, nameof(first));
            EnsureIsNotNull(second, nameof(second));

            HashSet<TSource> bannedElements = new HashSet<TSource>(first, comparer);
            bannedElements.ExceptWith(second);
            foreach (TSource item in bannedElements)
            {
                yield return item;
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

            var dictionary = new Dictionary<TKey, List<TElement>>(comparer);
            foreach (var item in source)
            {
                if (dictionary.Keys.Contains(keySelector(item)))
                {
                    dictionary[keySelector(item)].Add(elementSelector(item));
                }
                else
                {
                    dictionary.Add(keySelector(item), new List<TElement> { elementSelector(item) });
                }
            }

            foreach (var element in dictionary)
            {
                yield return resultSelector(element.Key, element.Value);
            }
        }

        public static IOrderedEnumerable<TSource> OrderBy<TSource, TKey>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            IComparer<TKey> comparer)
        {
            EnsureIsNotNull(source, nameof(source));
            EnsureIsNotNull(keySelector, nameof(keySelector));

            return new OrderedEnumerable<TSource>(source, new ProjectionComparer<TSource, TKey>(keySelector, comparer));
        }

        public static IOrderedEnumerable<TSource> ThenBy<TSource, TKey>(
        this IOrderedEnumerable<TSource> source,
        Func<TSource, TKey> keySelector,
        IComparer<TKey> comparer)
        {
            EnsureIsNotNull(source, nameof(source));
            EnsureIsNotNull(keySelector, nameof(keySelector));

            return source.CreateOrderedEnumerable(keySelector, comparer, false);
        }

        internal class OrderedEnumerable<TSource> : IOrderedEnumerable<TSource>
        {
            private readonly IEnumerable<TSource> source;
            private readonly IComparer<TSource> currentComparer;

            public OrderedEnumerable(IEnumerable<TSource> source, IComparer<TSource> comparer)
            {
                this.source = source;
                this.currentComparer = comparer;
            }

            public IOrderedEnumerable<TSource> CreateOrderedEnumerable<TKey>(
                Func<TSource, TKey> keySelector, IComparer<TKey> comparer, bool descending)
            {
                IComparer<TSource> secondaryComparer = new ProjectionComparer<TSource, TKey>(keySelector, comparer);

                return new OrderedEnumerable<TSource>(
                    source,
                    new CompoundComparer<TSource>(currentComparer, secondaryComparer));
            }

            public IEnumerator<TSource> GetEnumerator()
            {
                List<TSource> elements = source.ToList();
                elements.Sort(currentComparer);
                foreach (var element in elements)
                {
                    yield return element;
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }

        internal class ProjectionComparer<TSource, TKey> : IComparer<TSource>
        {
            private readonly Func<TSource, TKey> keySelector;
            private readonly IComparer<TKey> comparer;

            internal ProjectionComparer(Func<TSource, TKey> keySelector, IComparer<TKey> comparer)
            {
                this.keySelector = keySelector;
                this.comparer = comparer ?? Comparer<TKey>.Default;
            }

            public int Compare(TSource x, TSource y)
            {
                return comparer.Compare(keySelector(x), keySelector(y));
            }
        }

        internal class CompoundComparer<T> : IComparer<T>
        {
            private readonly IComparer<T> primary;
            private readonly IComparer<T> secondary;

            internal CompoundComparer(IComparer<T> primary, IComparer<T> secondary)
            {
                this.primary = primary;
                this.secondary = secondary;
            }

            public int Compare(T x, T y)
            {
                int primaryResult = primary.Compare(x, y);
                if (primaryResult != 0)
                {
                    return primaryResult;
                }

                return secondary.Compare(x, y);
            }
        }
    }
}
