using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Dictionary
{
    public class MyDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        public struct Entry
        {
            public int hashCode;
            public int posInElements;
            public int next;
            public TKey key;
            public TValue value;

            public TValue Value { get; internal set; }
        }

        private Entry[] elements;
        private int[] buckets;
        private int freeIndex = -1;
        private readonly IEqualityComparer<TKey> comparer;

        public MyDictionary(int numItems, int numBuckets)
        {
            elements = new Entry[numItems];
            buckets = Enumerable.Repeat(-1, numBuckets).ToArray(); 
        }

        public TValue this[TKey key] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public ICollection<TKey> Keys { get; internal set; }

        public ICollection<TValue> Values { get; internal set; }

        public int Count { get; private set; } = 0;

        public bool IsReadOnly => false;

        public void Add(TKey key, TValue value)
        {
            Entry newItem = new Entry();
            newItem.key = key;
            newItem.value = value;
            int bucketIndex = Math.Abs(key.GetHashCode()) % buckets.Length;
            newItem.hashCode = bucketIndex;
            newItem.posInElements = Count;

            if (key == null)
            {
                throw new ArgumentNullException("key is null");
            }

            if (buckets[bucketIndex] == -1)
            {
                newItem.next = -1;
                elements[Count] = newItem;
                buckets[bucketIndex] = Count;
            }
            else if (buckets[bucketIndex] != -1 && freeIndex == -1)
            {
                newItem.next = buckets[bucketIndex];
                elements[Count] = newItem;
                buckets[bucketIndex] = Count;
            }
            else  //freeIndex > -1
            {
                int temp = elements[freeIndex].next;
                elements[freeIndex].key = newItem.key;
                elements[freeIndex].value = newItem.value;
                elements[freeIndex].next = buckets[bucketIndex];
                buckets[bucketIndex] = freeIndex;

                freeIndex = temp;
            }
            
            Count++;
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            if (Count > 0)
            {
                buckets = Enumerable.Repeat(-1, buckets.Length).ToArray();
            }
            Array.Clear(elements, 0, Count);
            Count = 0;
            freeIndex = -1;
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            //Determines whether the ICollection<T> contains a specific value.
            throw new NotImplementedException();
        }

        public bool ContainsKey(TKey key)
        {
            return FindEntry(key) > -1;
        }

        private int FindEntry(TKey key)
        {
            if (key == null)
            {
                throw new ArgumentNullException();
            }

            int hashCode = Math.Abs(key.GetHashCode()) % buckets.Length;

            if (buckets[hashCode] == -1)
            {
                return -1;
            }

            Entry temp = elements[buckets[hashCode]];

            do
            {
                if (comparer.Equals(temp.key, key))
                {
                    return temp.posInElements;
                }
                else
                {
                    temp = elements[temp.next];
                }
            }
            while (temp.next != -1);

            return -1;
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }

            if (arrayIndex < 0 || arrayIndex > array.Length)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (array.Length - arrayIndex < Count)
            {
                throw new ArgumentException();
            }

            for (int i = arrayIndex; i < Count; i++)
            {
                if (elements[i].hashCode >= 0)
                {
                    array[arrayIndex++] = new KeyValuePair<TKey, TValue>(elements[i].key, elements[i].value);
                }
            }
        }

        public bool Remove(TKey key)
        {
            if (key == null)
            {
                throw new ArgumentNullException();
            }
            
            int position = FindEntry(key);
            if (position > -1)
            {

                //freeIndex = elements[position].posInElements;
                
                elements[position].key = default(TKey);
                elements[position].value = default(TValue);
                int hashCode = Math.Abs(key.GetHashCode()) % buckets.Length;
                if (elements[position].posInElements == buckets[hashCode])
                {
                    buckets[hashCode] = elements[position].next;
                    elements[position].next = -1;
                    _ = freeIndex == -1 ? freeIndex == elements[position].posInElements : elements[position].next == freeIndex && freeIndex == elements[position].posInElements;
                }
                else
                {
                    Entry temp = elements[buckets[hashCode]];

                    do
                    {
                        if (temp.next == position)
                        {
                            temp.next = elements[position].next;
                            elements[position].next = -1;
                        }
                        else
                        {
                            temp = elements[temp.next];
                        }
                    }
                    while (temp.next != -1);

                    _ = freeIndex == -1 ? freeIndex == elements[position].posInElements : elements[position].next == freeIndex && freeIndex == elements[position].posInElements;
                }

            }

            Count--;

            return false;
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value)
        {
            int i = FindEntry(key);
            if (i >= 0)
            {
                value = elements[i].Value;
                return true;
            }
            value = default(TValue);
            
            return false;
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
