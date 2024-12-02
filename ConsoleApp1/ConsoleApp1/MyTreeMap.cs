using System;
using System.Collections.Generic;
using System.Collections;

namespace ConsoleApp1
{
    internal class MyTreeMap<K, V> : IEnumerable<KeyValuePair<K, V>>
    {
        private class Node
        {
            public K Key { get; set; }
            public V Value { get; set; }
            public Node Next = null;
            public Node Left;
            public Node Right;

            public Node()
            {
                Key = default(K);
                Value = default(V);
            }

            public Node(K key, V value)
            {
                Key = key; Value = value;
                Left = Right = null;
            }
        }
        IComparer<K> comparator = Comparer<K>.Default;
        Node root = null;
        int size = 0;

        public IEnumerator<KeyValuePair<K, V>> GetEnumerator()
        {
            return EntrySet().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        //1
        public MyTreeMap()
        {
            comparator = Comparer<K>.Default;
            root = default;
            size = 0;
        }

        //2
        public MyTreeMap(IComparer<K> comparator)
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
        public bool ContainsKey(K key)
        {
            return GetNode(root, key) != null;
        }

        //5
        public bool ContainsValue(V value)
        {
            return FindValue(root, value);
        }

        private bool FindValue(Node node, V value)
        {
            if (node == null) return false;
            if (EqualityComparer<V>.Default.Equals(node.Value, value)) return true;
            return FindValue(node.Left, value) || FindValue(node.Right, value);
        }

        //6
        public IEnumerable<KeyValuePair<K, V>> EntrySet()
        {
            foreach (var entry in InOrderTraversal(root))
            {
                yield return entry;
            }
        }
        private IEnumerable<KeyValuePair<K, V>> InOrderTraversal(Node node)
        {
            if (node != null)
            {
                foreach (var entry in InOrderTraversal(node.Left))
                    yield return entry;
                yield return new KeyValuePair<K, V>(node.Key, node.Value);
                foreach (var entry in InOrderTraversal(node.Right))
                    yield return entry;
            }
        }

        //7
        public V Get(K Key)
        {
            var node = GetNode(root, Key);
            return node != null ? node.Value : default(V);
        }

        private Node GetNode(Node node, K key)
        {
            if (node == null) return null;

            int cmp = comparator.Compare(key, node.Key);
            if (cmp < 0)
                return GetNode(node.Left, key);
            else if (cmp > 0)
                return GetNode(node.Right, key);
            else
                return node;
        }
        //8
        public bool IsEmpty()
        {
            return size == null;
        }

        //9
        public IEnumerable<K> KeySet()
        {
            foreach (var entry in EntrySet())
            {
                yield return entry.Key;
            }
        }

        //10
        public void Put(K key, V value)
        {
            root = PutNode(root, key, value);
            size++;
        }

        //тут не связываются правые и левые элементы с корнем
        private Node PutNode(Node node, K key, V value)
        {
            if (node == null) return new Node(key, value);

            int cmp = comparator.Compare(key, node.Key);
            if (cmp < 0)
                node.Left = PutNode(node.Left, key, value);
            else if (cmp > 0)
                node.Right = PutNode(node.Right, key, value);
            else
            {
                node.Value = value;
            }

            return node;
        }
        //11
        public bool Remove(K key)
        {
            int initialSize = size;
            root = RemoveNode(root, key);
            return initialSize != size;
        }
        private Node RemoveNode(Node node, K key)
        {
            if (node == null) return null;

            int cmp = comparator.Compare(key, node.Key);
            if (cmp < 0)
                node.Left = RemoveNode(node.Left, key);
            else if (cmp > 0)
                node.Right = RemoveNode(node.Right, key);
            else
            {
                size--;

                if (node.Left == null) return node.Right;
                if (node.Right == null) return node.Left;

                Node minNode = GetMin(node.Right);
                minNode.Right = RemoveMin(node.Right);
                minNode.Left = node.Left;
                return minNode;
            }

            return node;
        }

        private Node GetMin(Node node)
        {
            while (node.Left != null) node = node.Left;
            return node;
        }

        private Node RemoveMin(Node node)
        {
            if (node.Left == null) return node.Right;
            node.Left = RemoveMin(node.Left);
            return node;
        }

        //12
        public int Size()
        {
            return size;
        }

        //13
        public K FirstKey()
        {
            if (IsEmpty()) throw new InvalidOperationException("TreeMap is empty");
            return GetMin(root).Key;
        }

        //14
        public K LastKey()
        {
            if (IsEmpty()) throw new InvalidOperationException("TreeMap is empty");
            return GetMax(root).Key;
        }
        private Node GetMax(Node node)
        {
            while (node.Right != null) node = node.Right;
            return node;
        }
        //15
        public MyTreeMap<K, V> HeadMap(K end)
        {
            MyTreeMap<K, V> resultMap = new MyTreeMap<K, V>(comparator);
            K start = GetMin(root).Key;
            HeadMapHelper(root, resultMap, start, end);
            return resultMap;
        }
        //16
        public MyTreeMap<K, V> SubMap(K start, K end)
        {
            MyTreeMap<K, V> resultMap = new MyTreeMap<K, V>(comparator);
            HeadMapHelper(root, resultMap, start, end);
            return resultMap;
        }

        //17
        public MyTreeMap<K, V> TailMap(K start)
        {
            MyTreeMap<K, V> resultMap = new MyTreeMap<K, V>(comparator);
            K end = GetMax(root).Key;
            HeadMapHelper(root, resultMap, start, end);
            return resultMap;
        }

        private void HeadMapHelper(Node node, MyTreeMap<K, V> resultMap, K start, K end)
        {
            if (node == null) return;
            int cmpStart = comparator.Compare(node.Key, start);
            int cmpEnd = comparator.Compare(node.Key, end);

            if (cmpStart < 0)
            {
                HeadMapHelper(node.Right, resultMap, start, end);
            }

            else if (cmpEnd > 0)
            {
                HeadMapHelper(node.Left, resultMap, start, end);
            }


            else if (cmpStart >= 0 && cmpEnd <= 0)
            {
                resultMap.Put(node.Key, node.Value);

                HeadMapHelper(node.Left, resultMap, start, end);
                HeadMapHelper(node.Right, resultMap, start, end);
            }
        }

        private KeyValuePair<K, V>? FindEntry(K key, Func<int, bool> condition)
        {
            return FindEntryHelper(root, key, null, condition);
        }

        private KeyValuePair<K, V>? FindEntryHelper(Node node, K key, KeyValuePair<K, V>? bestEntry, Func<int, bool> condition)
        {
            if (node == null) return bestEntry;

            int cmp = comparator.Compare(node.Key, key);

            if (condition(cmp))
            {
                bestEntry = new KeyValuePair<K, V>(node.Key, node.Value);
                return FindEntryHelper(node.Right, key, bestEntry, condition);
            }
            else
            {
                return FindEntryHelper(node.Left, key, bestEntry, condition);
            }
        }
        //18
        public KeyValuePair<K, V>? LowerEntry(K key)
        {
            return FindEntry(key, cmp => cmp < 0);
        }

        //19
        public KeyValuePair<K, V>? FloorEntry(K key)
        {
            return FindEntry(key, cmp => cmp <= 0);
        }

        //20
        public KeyValuePair<K, V>? HigherEntry(K key)
        {
            return FindEntry(key, cmp => cmp > 0);
        }

        //21
        public KeyValuePair<K, V>? CeilingEntry(K key)
        {
            return FindEntry(key, cmp => cmp >= 0);
        }
        //22
        public K LowerKey(K key)
        {
            var entry = LowerEntry(key);
            return entry.HasValue ? entry.Value.Key : default(K);
        }

        //23
        public K FloorKey(K key)
        {
            var entry = FloorEntry(key);
            return entry.HasValue ? entry.Value.Key : default(K);
        }

        //24
        public K HigherKey(K key)
        {
            var entry = HigherEntry(key);
            return entry.HasValue ? entry.Value.Key : default(K);
        }

        //25
        public K CeilingKey(K key)
        {
            var entry = CeilingEntry(key);
            return entry.HasValue ? entry.Value.Key : default(K);
        }

        //26
        public KeyValuePair<K, V>? PollFirstEntry()
        {
            if (root == null) return null;

            KeyValuePair<K, V> firstEntry = FirstEntry().Value;
            root = Remove(root, firstEntry.Key);
            return firstEntry;
        }

        //27
        public KeyValuePair<K, V>? PollLastEntry()
        {
            if (root == null) return null;

            KeyValuePair<K, V> lastEntry = LastEntry().Value;
            root = Remove(root, lastEntry.Key);
            return lastEntry;
        }

        //28
        public KeyValuePair<K, V>? FirstEntry()
        {
            if (root == null) return null;
            Node current = root;
            while (current.Left != null)
                current = current.Left;
            return new KeyValuePair<K, V>(current.Key, current.Value);
        }

        //29
        public KeyValuePair<K, V>? LastEntry()
        {
            if (root == null) return null;
            Node current = root;
            while (current.Right != null)
                current = current.Right;
            return new KeyValuePair<K, V>(current.Key, current.Value);
        }

        private Node Remove(Node node, K key)
        {
            if (node == null) return null;

            int cmp = comparator.Compare(key, node.Key);
            if (cmp < 0)
            {
                node.Left = Remove(node.Left, key);
            }
            else if (cmp > 0)
            {
                node.Right = Remove(node.Right, key);
            }
            else
            {

                if (node.Left == null) return node.Right;
                if (node.Right == null) return node.Left;

                Node t = node;
                node = Min(t.Right);
                node.Right = RemoveMin(t.Right);
                node.Left = t.Left;
            }
            return node;
        }

        private Node Min(Node node)
        {
            if (node.Left != null)
                return Min(node.Left);
            return node;
        }
    }
}