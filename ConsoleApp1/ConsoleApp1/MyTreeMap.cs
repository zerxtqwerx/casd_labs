using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class MyTreeMap<K, V>
    {
        private class Node<K, V>
        {
            public K Key { get; set; }
            public V Value { get; set; }
            public Node<K, V> Next = null;

            public Node()
            {
                Key = default(K);
                Value = default(V);
            }

            public Node(K key, V value)
            {
                Key = key; Value = value;
            }
        }
        Comparer<K> comparator = Comparer<K>.Default;
        Node<K, V> root = null;
        int size = 0;

        //1
        public MyTreeMap()
        {
            comparator = Comparer<K>.Default;
            root = default;
            size = 0;
        }

        //2
        public MyTreeMap(Comparer<K> comparator)
        {
            root = null;
            size = 0;
            this.comparator = comparator;
        }

        //3
        public void Clear()
        {
            size = 0;
            root = null;
            comparator = Comparer<K>.Default;
        }

        //4
        public bool ContainsKey(object Key)
        {
            Node<K, V> current = root;
            while (current != null)
            {
                if (Equals(current.Key, Key) == true)
                    return true;
                current = current.Next;
            }
            return false;
        }

        //5
        public bool ContainsValue(object Value)
        {
            Node<K, V> current = root;
            while (current != null)
            {
                if (Equals(current.Value, Value) == true)
                    return true;
                current = current.Next;
            }
            return false;
        }

        //6
        public HashSet<KeyValuePair<K, V>> EntrySet()
        {
            HashSet<KeyValuePair<K, V>> hashSet = new HashSet<KeyValuePair<K, V>>();
            Node<K, V> current = root;
            while (current != null)
            {
                hashSet.Add(new KeyValuePair<K, V>(current.Key, current.Value));
                current = current.Next;
            }
            return hashSet;
        }

        //7
        public V Get(object Key)
        {
            Node<K, V> current = root;
            while (current != null)
            {
                if (Equals(current.Key, Key) == true)
                    return current.Value;
                current = current.Next;
            }
            return (V)default;
        }

        //8
        public bool IsEmpty()
        {
            return size == null;
        }

        //9
        public HashSet<K> KeySet()
        {
            HashSet<K> k = new HashSet<K>();
            Node<K, V> current = root;
            while(current != null)
            {
                k.Add(current.Key);
                current = current.Next;
            }
            return k;
        }

        //10
        public void Put(K Key, V Value)
        {
            Node<K, V> current = root;
            while( current != null)
            {
                if(comparator.Compare(current.Key, Key) >= 0)
                {
                    ////////
                }
            }
        }
        //11
        public void Remove(object Key)
        {
            Node<K, V> current = root;
            while (current != null)
            {
                if (comparator.Compare(current.Key, (K)Key) >= 0)
                {
                    ////////
                }
            }
        }

        //12
        public int Size()
        {
            return size;
        }

        //13
        public K FirstKey()
        {
            return root.Key;
        }

        //14
        public K LastKey()
        {
            Node<K, V> current = root;
            while (current.Next != null)
            {
                current = current.Next;
            }
            return current.Key;
        }

        //15
        

        //16

    }
}
