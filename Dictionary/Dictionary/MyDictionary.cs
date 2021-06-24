using System;
using System.Collections;
using System.Collections.Generic;

namespace Dictionary
{
    public class MyDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        public struct Entry
        {
            public TKey key;
            public TValue value;
            public int next;
        }

        TKey, TValue> dictionary;
        private Entry[] elements;
        private int[] buckets;
        private int freeIndex = -1;

        public MyDictionary(int numItems, int numBuckets)
        {
            elements = new Entry[numItems];
            buckets = new int[numBuckets];
            Array.Fill<int>(buckets, -1); 
        }

        public TValue this[TKey key] 
        {
            get
            {
                if (TryGetValue(key, out TValue value))
                {
                    return value;
                }
                else
                {
                    throw new KeyNotFoundException();
                }
            }

            set
            {
                if (TryGetValue(key, out TValue Value))
                {
                    value = Value;
                }
                else
                {
                    Add(key, value);
                }
            }
        }

        public ICollection<TKey> Keys 
        {
            get
            {
                TKey[] keys = new TKey[elements.Length];
                for (int n = 0; n < elements.Length; n++)
                {
                    keys[n] = elements[n].key;
                }

                return keys;
            }
        }

        public ICollection<TValue> Values 
        {
            get
            {
                TValue[] values = new TValue[elements.Length];
                for (int n = 0; n < elements.Length; n++)
                {
                    values[n] = elements[n].value;
                }
                
                return values;
            }
        }

        public int Count { get; private set; } = 0;

        public bool IsReadOnly => false;

        private int CalculateBucketIndex(TKey key)
        {
            return Math.Abs(key.GetHashCode()) % buckets.Length;
        }

        public void Add(TKey key, TValue value)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key is null");
            }

            if (ContainsKey(key))
            {
                throw new ArgumentException("An element with the same key already exists");
            }

            Entry newItem = new Entry();
            newItem.key = key;
            newItem.value = value;
            int bucketIndex = CalculateBucketIndex(key);

            if (freeIndex == -1)
            {
                newItem.next = buckets[bucketIndex];
                elements[Count] = newItem;
                buckets[bucketIndex] = Count;
            }
            else  
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
            Add(item.Key, item.Value);
        }

        public void Clear()
        {
            Array.Fill<int>(buckets, -1);
            Array.Clear(elements, 0, Count);
            Count = 0;
            freeIndex = -1;
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            int index = FindEntry(item.Key).Item1;
            if (index > -1 && elements[index].value.Equals(item.Value))
            {
                return true;
            }

            return false;
        }

        public bool ContainsKey(TKey key)
        {
            return FindEntry(key).Item1 > -1;
        }

        private (int, int) FindEntry(TKey key)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key is null");
            }

            int bucketIndex = CalculateBucketIndex(key);
            int previous = -1;
            for (int i = buckets[bucketIndex]; i != -1; i = elements[i].next)
            {
                if (elements[i].key.Equals(key))
                {
                    return (i, previous);
                }
                previous = i;
            }

            return (-1, -1);
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

            for (int i = 0 ; i < Count; i++)
            {
                if (elements[i].value != null)
                {
                    array[arrayIndex++] = new KeyValuePair<TKey, TValue>(elements[i].key, elements[i].value);
                }
            }
        }

        public bool Remove(TKey key)
        {
            int position, previous;
            (position, previous) = FindEntry(key);

            if (position > -1)
            {
                elements[position].key = default(TKey);
                elements[position].value = default(TValue);
                int bucketIndex = CalculateBucketIndex(key);
                if (position == buckets[bucketIndex])
                {
                    buckets[bucketIndex] = elements[position].next;
                }
                else
                {
                    elements[previous].next = elements[position].next;
                }
                elements[position].next = freeIndex;
                freeIndex = position;
                Count--;
                return true;
            }

            return false;
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            if (elements[FindEntry(item.Key).Item1].value.Equals(item.Value))
            {
                return Remove(item.Key); 
            }
            
            return false;
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            int i = FindEntry(key).Item1;
            if (i >= 0)
            {
                value = elements[i].value;
                return true;
            }
            value = default(TValue);
            
            return false;
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            for (int i = 0; i < buckets.Length; i++)
            {
                for (int j = buckets[i]; j != -1; j = elements[j].next)
                {
                    yield return new KeyValuePair<TKey, TValue>(elements[j].key, elements[j].value);
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
