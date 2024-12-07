using System.Diagnostics;

namespace ConsoleApp1
{
    internal class Test
    {
        MyHashMap<int, int> hashMap;
        MyTreeMap<int, int> treeMap;
        int minSize = 10;
        int maxSize = 1000 + 1;

        public Test()
        {
            hashMap = new MyHashMap<int, int>();
            treeMap = new MyTreeMap<int, int>();
        }
        //get, put, remove
        public double[] TestPutHashMap()
        {
            double[] time = new double[3];
            Stopwatch sw = new Stopwatch();
            int index = 0;

            for (int n = minSize; n < maxSize; n *= 10)
            {
                for (int a = 0; a != 20; a++)
                {
                    sw.Start();
                    for (int i = 0; i != n; i++)
                    {
                        hashMap.Put(i, i);
                    }
                    sw.Stop();
                    if (a != 19)
                        hashMap.Clear();
                    time[index] = sw.ElapsedMilliseconds;
                }
                time[index] /= 20;
                index++;
            }
            return time;
        }
        public double[] TestPutTreeMap()
        {
            double[] time = new double[3];
            Stopwatch sw = new Stopwatch();
            int index = 0;

            for (int n = minSize; n < maxSize; n *= 10)
            {
                for (int a = 0; a != 20; a++)
                {
                    sw.Start();
                    for (int i = 0; i != n; i++)
                    {
                        treeMap.Put(i, i);
                    }
                    sw.Stop();
                    if(a != 19)
                        treeMap.Clear();
                    time[index] = sw.ElapsedMilliseconds;
                }
                time[index] /= 20;
                index++;
            }
            return time;
        }

        public double[] TestGetHashMap()
        {
            double[] time = new double[3];
            Stopwatch sw = new Stopwatch();
            int index = 0;

            for (int n = minSize; n < maxSize; n *= 10)
            {
                for (int a = 0; a != 20; a++)
                {
                    sw.Start();
                    for (int i = 0; i != n; i++)
                    {
                        hashMap.Get(i);
                    }
                    sw.Stop();
                    time[index] = sw.ElapsedMilliseconds;
                }
                time[index] /= 20;
                index++;
            }
            return time;
        }
        public double[] TestGetTreeMap()
        {
            double[] time = new double[3];
            Stopwatch sw = new Stopwatch();
            int index = 0;

            for (int n = minSize; n < maxSize; n *= 10)
            {
                for (int a = 0; a != 20; a++)
                {
                    sw.Start();
                    for (int i = 0; i != n; i++)
                    {
                        treeMap.Get(i);
                    }
                    sw.Stop();
                    time[index] = sw.ElapsedMilliseconds;
                }
                time[index] /= 20;
                index++;
            }
            return time;
        }

        public double[] TestRemoveHashMap()
        {
            double[] time = new double[3];
            Stopwatch sw = new Stopwatch();
            int index = 0;

            for (int n = minSize; n < maxSize; n *= 10)
            {
                for (int a = 0; a != 20; a++)
                {
                    sw.Start();
                    for (int i = 0; i != n; i++)
                    {
                        hashMap.Remove(i);
                    }
                    sw.Stop();
                    time[index] = sw.ElapsedMilliseconds;
                }
                time[index] /= 20;
                index++;
            }
            return time;
        }
        public double[] TestRemoveTreeMap()
        {
            double[] time = new double[3];
            Stopwatch sw = new Stopwatch();
            int index = 0;

            for (int n = minSize; n < maxSize; n *= 10)
            {
                for (int a = 0; a != 20; a++)
                {
                    
                    sw.Start();
                    for (int i = 0; i != n; i++)
                    {
                        treeMap.Remove(i);
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
