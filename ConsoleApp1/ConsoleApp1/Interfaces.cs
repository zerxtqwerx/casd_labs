using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public interface MyCollection<T>
    {
        void Add(T e);
        void AddAll(T[] a);
        void Clear();
        bool Contains(object o);
        bool ContainsAll(T[] a);
        bool IsEmpty();
        void Remove(object o);
        void RemoveAll(T[] a);
        void RetainAll(T[] a);
        int Size();
        //void ToArray();
        //void ToArray(T[] a);
    }
    public interface MyList<T> : MyCollection<T>
    {
        void Add(T e);
        void AddAll(T[] a);
        T Get(int index);
        int IndexOf(object o);
        int LastIndexOf(object o);
        MyIterator2<T> ListIterator();
        MyIterator2<T> ListIterator(int index);
        void Remove(int index);
        T Set(int index, T e);
    }
    public interface MyQueue<T> : MyCollection<T>
    {
        T Element();
        bool Offer(T obj);
        T Peek();
        T Poll();
    }
    public interface MyDeque<T> : MyCollection<T>
    {
        void AddFirst(T obj);
        void AddLast(T obj);
        T GetFirst();
        T GetLast();
        bool OfferFirst(T obj);
        bool OfferLast(T obj);
        T Pop();
        void Push(T obj);
        T PeekFirst();
        T PeekLast();
        T PollFirst();
        T PollLast();
        T RemoveLast();
        T RemoveFirst();
        bool RemoveLastOccurrence(object obj);
        bool RemoveFirstOccurrence(object obj);
    }
    public interface MySet<T> : MyCollection<T>
    {
        T First();
        T Last();
        MyHashSet<T> SubSet(T FromElement, T ToElement);
        MyHashSet<T> HeadSet(T toElement);
        MyHashSet<T> TailSet(T fromElement);
    }
    public interface MySortedSet<T> 
    {
        T First();
        T Last();
        MyTreeSet<T> SubSet(T FromElement, bool a, T ToElement, bool b);
        MyTreeSet<T> HeadSet(T toElement, bool a);
        MyTreeSet<T> TailSet(T fromElement, bool a);
    }
    public interface MyNavigableSet<T> : MySortedSet<T>
    {
        T Lower(T key);
        T Floor(T key);
        T Higher(T key);
        T Ceiling(T key);
        T PollFirst();
        T PollLast();
    }
    public interface MyMap<K, V>
    {
        void Clear();
        bool ContainsKey(object key);
        bool ContainsValue(object value);
        HashSet<KeyValuePair<K, V>> EntrySet();
        V Get(K key);
        bool IsEmpty();
        HashSet<K> KeySet();
        void Put(K key, V value);
        void Remove(K key);
        int Size();
    }
    public interface MySortedMap<K, V>
    {
        K FirstKey();
        K LastKey();
        MyTreeMap<K, V> HeadMap(K end);
        MyTreeMap<K, V> SubMap(K start, K end);
        MyTreeMap<K, V> TailMap(K start);
    }
    public interface MyNavigableMap<K, V> : MySortedMap<K, V>
    {
        K LowerKey(K key);
        K FloorKey(K key);
        K HigherKey(K key);
        K CeilingKey(K key);
        KeyValuePair<K, V>? PollFirstEntry();
        KeyValuePair<K, V>? PollLastEntry();
        KeyValuePair<K, V>? FirstEntry();
        KeyValuePair<K, V>? LastEntry();
    }
}
