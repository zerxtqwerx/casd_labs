using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Test
    {
        MyArrayList<int> arrayList;
        MyLinkedList<int> linkedList;

        public Test()
        {
            arrayList = new MyArrayList<int>();
            linkedList = new MyLinkedList<int>();
        }

        public long[] TestAddArray()
        {
            long[] time = new long[4];
            Stopwatch sw = new Stopwatch();
            int index = 0;

            for (int n = 100000; n < 100000001; n *= 10)
            {
                for (int a = 0; a != 20; a++)
                {
                    sw.Start();
                    for (int i = 0; i != n; i++)
                    {
                        arrayList.Add(1);
                    }
                    sw.Stop();
                    arrayList.Clear();
                    time[index] = sw.ElapsedMilliseconds;
                }
                time[index] /= 20;
                index++;
            }
            return time;
        }
        public long[] TestAddLinked()
        {
            long[] time = new long[4];
            Stopwatch sw = new Stopwatch();
            int index = 0;

            for (int n = 100000; n < 100000001; n *= 10)
            {
                for (int a = 0; a != 20; a++)
                {
                    sw.Start();
                    for (int i = 0; i != n; i++)
                    {
                        linkedList.Add(1);
                    }
                    sw.Stop();
                    linkedList.Clear();
                    time[index] = sw.ElapsedMilliseconds;
                }
                time[index] /= 20;
                index++;
            }
            return time;
        }

        public long[] TestGetArray()
        {
            long[] time = new long[4];
            Stopwatch sw = new Stopwatch();
            int index = 0;

            for (int n = 100000; n < 100000001; n *= 10)
            {
                for (int a = 0; a != 20; a++)
                {
                    sw.Start();
                    for (int i = 0; i != n; i++)
                    {
                        arrayList.Get(i);
                    }
                    sw.Stop();
                    time[index] = sw.ElapsedMilliseconds;
                }
                time[index] /= 20;
                index++;
            }
            return time;
        }
        public long[] TestGetLinked()
        {
            long[] time = new long[4];
            Stopwatch sw = new Stopwatch();
            int index = 0;

            for (int n = 100000; n < 100000001; n *= 10)
            {
                for (int a = 0; a != 20; a++)
                {
                    sw.Start();
                    for (int i = 0; i != n; i++)
                    {
                        linkedList.Add(i);
                    }
                    sw.Stop();
                    time[index] = sw.ElapsedMilliseconds;
                }
                time[index] /= 20;
                index++;
            }
            return time;
        }
        public long[] TestSetArray()
        {
            long[] time = new long[4];
            Stopwatch sw = new Stopwatch();
            int index = 0;

            for (int n = 100000; n < 100000001; n *= 10)
            {
                for (int a = 0; a != 20; a++)
                {
                    sw.Start();
                    for (int i = 0; i != n; i++)
                    {
                        arrayList.Set(i, 2);
                    }
                    sw.Stop();
                    time[index] = sw.ElapsedMilliseconds;
                }
                time[index] /= 20;
                index++;
            }
            return time;
        }
        public long[] TestSetLinked()
        {
            long[] time = new long[4];
            Stopwatch sw = new Stopwatch();
            int index = 0;

            for (int n = 100000; n < 100000001; n *= 10)
            {
                for (int a = 0; a != 20; a++)
                {
                    sw.Start();
                    for (int i = 0; i != n; i++)
                    {
                        linkedList.Set(i, 2);
                    }
                    sw.Stop();
                    time[index] = sw.ElapsedMilliseconds;
                }
                time[index] /= 20;
                index++;
            }
            return time;
        }
        public long[] TestAddValueArray()
        {
            long[] time = new long[4];
            Stopwatch sw = new Stopwatch();
            int index = 0;
            arrayList.Clear();

            for (int n = 100000; n < 100000001; n *= 10)
            {
                for (int a = 0; a != 20; a++)
                {
                    sw.Start();
                    for (int i = 0; i != n; i++)
                    {
                        arrayList.Add(i, 3);
                    }
                    sw.Stop();
                    arrayList.Clear();
                    time[index] = sw.ElapsedMilliseconds;
                }
                time[index] /= 20;
                index++;
            }
            return time;
        }
        public long[] TestAddValueLinked()
        {
            long[] time = new long[4];
            Stopwatch sw = new Stopwatch();
            int index = 0;
            linkedList.Clear();

            for (int n = 100000; n < 100000001; n *= 10)
            {
                for (int a = 0; a != 20; a++)
                {
                    sw.Start();
                    for (int i = 0; i != n; i++)
                    {
                        linkedList.Add(i, 3);
                    }
                    sw.Stop();
                    linkedList.Clear();
                    time[index] = sw.ElapsedMilliseconds;
                }
                time[index] /= 20;
                index++;
            }
            return time;
        }

        public long[] TestRemoveArray()
        {
            long[] time = new long[4];
            Stopwatch sw = new Stopwatch();
            int index = 0;

            for (int n = 100000; n < 100000001; n *= 10)
            {
                for (int a = 0; a != 20; a++)
                {
                    sw.Start();
                    for (int i = 0; i != n; i++)
                    {
                        arrayList.Remove(i);
                    }
                    sw.Stop();
                    time[index] = sw.ElapsedMilliseconds;
                }
                time[index] /= 20;
                index++;
            }
            return time;
        }
        public long[] TestRemoveLinked()
        {
            long[] time = new long[4];
            Stopwatch sw = new Stopwatch();
            int index = 0;

            for (int n = 100000; n < 100000001; n *= 10)
            {
                for (int a = 0; a != 20; a++)
                {
                    sw.Start();
                    for (int i = 0; i != n; i++)
                    {
                        linkedList.Remove(i);
                    }
                    sw.Stop();
                    time[index] = sw.ElapsedMilliseconds;
                }
                time[index] /= 20;
                index++;
            }
            return time;
        }
    }
}
