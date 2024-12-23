using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    public class MyTreeSet<E> : IEnumerable<E>, MyNavigableSet<E>
    {
        private MyTreeMap<E, object> m;
        private static readonly object PRESENT = new object();

        // Конструкторы
        //1
        public MyTreeSet()
        {
            m = new MyTreeMap<E, object>();
        }
        //2
        public MyTreeSet(MyTreeMap<E, object> m)
        {
            this.m = m.Copy();
        }
        //3
        public MyTreeSet(IComparer<E> comparator)
        {
            m = new MyTreeMap<E, object>(comparator);
        }
        //4
        public MyTreeSet(E[] a)
        {
            m = new MyTreeMap<E, object>();
            AddAll(a);
        }
        //5
        public MyTreeSet(SortedSet<E> s)
        {
            m = new MyTreeMap<E, object>();
            foreach (var e in s)
            {
                m.Put(e, PRESENT);
            }
        }

        // Методы
        //6
        public void Add(E e)
        {
            m.Put(e, PRESENT);
        }

        //7
        public void AddAll(E[] a)
        {
            foreach (var e in a)
            {
                Add(e);
            }
        }
        //8
        public void Clear()
        {
            m.Clear();
        }
        //9
        public bool Contains(object o)
        {
            return m.ContainsKey((E)o);
        }
        //10
        public bool ContainsAll(E[] a)
        {
            foreach (var e in a)
            {
                if (!Contains(e)) return false;
            }
            return true;
        }
        //11
        public bool IsEmpty()
        {
            return m.Size() == 0;
        }
        //12
        public bool Remove(object o)
        {
            return m.Remove((E)o) != null;
        }
        //13
        public void RemoveAll(E[] a)
        {
            foreach (var e in a)
            {
                Remove(e);
            }
        }
        //14
        public void RetainAll(E[] a)
        {
            var newSet = new MyTreeSet<E>();
            foreach (var e in a)
            {
                if (Contains(e))
                {
                    newSet.Add(e);
                }
            }
            m = newSet.m;
        }
        //15
        public int Size()
        {
            return m.Size();
        }
        //16
        public E[] ToArray()
        {
            return m.KeySet().ToArray();
        }
        //17
        public E[] ToArray(E[] a)
        {
            if (a == null || a.Length < Size())
            {
                a = new E[Size()];
            }
            return ToArrayHelper(a);
        }
        private E[] ToArrayHelper(E[] a)
        {
            int i = 0;
            foreach (var key in m.KeySet())
            {
                a[i++] = key;
            }
            return a;
        }
        //18
        public E First()
        {
            if (IsEmpty()) throw new InvalidOperationException("Множество пусто.");
            return m.FirstKey();
        }
        //19
        public E Last()
        {
            if (IsEmpty()) throw new InvalidOperationException("Множество пусто.");
            return m.LastKey();
        }

        // Подмножества
        //20
        public MyTreeSet<E> SubSet(E fromElement, E toElement)
        {
            MyTreeSet<E> subset = new MyTreeSet<E>();
            foreach (var element in m.KeySet())
            {
                if (Compare(element, fromElement) >= 0 && Compare(element, toElement) < 0)
                {
                    subset.Add(element);
                }
            }
            return subset;
        }
        //21
        public MyTreeSet<E> HeadSet(E toElement)
        {
            MyTreeSet<E> headSet = new MyTreeSet<E>();
            foreach (var element in m.KeySet())
            {
                if (Compare(element, toElement) < 0)
                {
                    headSet.Add(element);
                }
            }
            return headSet;
        }
        //22
        public MyTreeSet<E> TailSet(E fromElement)
        {
            MyTreeSet<E> tailSet = new MyTreeSet<E>();
            foreach (var element in m.KeySet())
            {
                if (Compare(element, fromElement) >= 0)
                {
                    tailSet.Add(element);
                }
            }
            return tailSet;
        }
        //23
        public E Ceiling(E obj)
        {
            foreach (var element in m.KeySet())
            {
                if (Compare(element, obj) >= 0)
                {
                    return element;
                }
            }
            return default(E);
        }
        //24
        public E Floor(E obj)
        {
            E result = default;
            foreach (var element in m.KeySet())
            {
                if (Compare(element, obj) <= 0)
                {
                    result = element;
                }
            }
            return result;
        }
        //25
        public E Higher(E obj)
        {
            foreach (var element in m.KeySet())
            {
                if (Compare(element, obj) > 0)
                {
                    return element;
                }
            }
            return default(E);
        }
        //26
        public E Lower(E obj)
        {
            E result = default;
            foreach (var element in m.KeySet())
            {
                if (Compare(element, obj) < 0)
                {
                    result = element;
                }
            }
            return result;
        }
        //27
        public MyTreeSet<E> HeadSet(E upperBound, bool incl)
        {
            MyTreeSet<E> headSet = new MyTreeSet<E>();
            foreach (var element in m.KeySet())
            {
                if (Compare(element, upperBound) < 0 || (incl && Compare(element, upperBound) == 0))
                {
                    headSet.Add(element);
                }
            }
            return headSet;
        }
        //28
        public MyTreeSet<E> SubSet(E lowerBound, bool lowIncl, E upperBound, bool highIncl)
        {
            MyTreeSet<E> subSet = new MyTreeSet<E>();
            foreach (var element in m.KeySet())
            {
                if (Compare(element, lowerBound) > 0 || (lowIncl && Compare(element, lowerBound) == 0))
                {
                    if (Compare(element, upperBound) < 0 || (highIncl && Compare(element, upperBound) == 0))
                    {
                        subSet.Add(element);
                    }
                }
            }
            return subSet;
        }
        //29
        public MyTreeSet<E> TailSet(E fromElement, bool inclusive)
        {
            MyTreeSet<E> tailSet = new MyTreeSet<E>();
            foreach (var element in m.KeySet())
            {
                if (Compare(element, fromElement) > 0 || (inclusive && Compare(element, fromElement) == 0))
                {
                    tailSet.Add(element);
                }
            }
            return tailSet;
        }
        //30
        public E PollLast()
        {
            if (IsEmpty()) return default(E);
            E lastElement = Last();
            Remove(lastElement);
            return lastElement;
        }
        //31
        public E PollFirst()
        {
            if (IsEmpty()) return default(E);
            E firstElement = First();
            Remove(firstElement);
            return firstElement;
        }
        //32
        public IEnumerator<E> DescendingIterator()
        {
            List<E> keys = new List<E>(m.KeySet());
            keys.Sort((x, y) => Comparer<E>.Default.Compare(y, x));
            foreach (var key in keys)
            {
                yield return key;
            }
        }
        public IEnumerator<E> GetEnumerator()
        {
            foreach (var key in m.KeySet())
            {
                yield return key;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        /*public MyEnumerator GetEnumerator()
        {
            return new MyEnumerator(this);
        }
        public class MyEnumerator
        {
            int nIndex;
            MyTreeSet<E> set;
            public MyEnumerator(MyTreeSet<E> coll)
            {
                set = coll;
                nIndex = -1;
            }

            public bool MoveNext()
            {
                nIndex++;
                return (nIndex < set.Size());
            }

            public E Current()  // => set.items[nIndex];
            {
                E[] e = set.ToArray();
                return e[nIndex];
            }
        }*/
        //33
        public MyTreeSet<E> DescendingSet()
        {
            MyTreeSet<E> descendingSet = new MyTreeSet<E>();
            using (var enumerator = DescendingIterator())
            {
                while (enumerator.MoveNext())
                {
                    descendingSet.Add(enumerator.Current);
                }
            }
            return descendingSet;
        }

        //Comparator
        private int Compare(E x, E y)
        {
            return Comparer<E>.Default.Compare(x, y);
        }
        public MyIterator1<E> Iterator()
        {
            return new MyItr1<E>(this);
        }

        public class MyItr1<T> : MyIterator1<T>
        {
            private MyTreeSet<T> list;
            private int cursor = -1;

            public MyItr1(MyTreeSet<T> list)
            {
                this.list = list;
            }

            public bool HasNext()
            {
                return cursor + 1 < list.Size();
            }

            public T Next()
            {
                if (!HasNext())
                    throw new InvalidOperationException("Нет следующего элемента.");

                cursor++;
                return list.First();
            }

            public void Remove()
            {
                list.Remove(list.First());
                cursor--;
            }
        }
    }
}
