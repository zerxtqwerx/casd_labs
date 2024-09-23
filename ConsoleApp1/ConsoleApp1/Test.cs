using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Drawing;

namespace Test
{
    internal class Test
    {
        //sorting algorithms delegates
        public delegate void GroupDelegate(int[] array);

        List<GroupDelegate> firstGroup = new List<GroupDelegate>
        {
            Sort.SortingAlgorithms.BubbleSort,      //1.1
            Sort.SortingAlgorithms.InsertionSort,   //1.2
            Sort.SortingAlgorithms.SelectionSort,   //1.3
            Sort.SortingAlgorithms.ShakerSort,      //1.4
            Sort.SortingAlgorithms.GnomeSort,       //1.5
        };

        List<GroupDelegate> secondGroup = new List<GroupDelegate>
        {
            Sort.SortingAlgorithms.BitonicSort,     //2.1
            Sort.SortingAlgorithms.ShellSort,       //2.2
            Sort.SortingAlgorithms.TreeSort,        //2.3
        };
        List<GroupDelegate> thirdGroup = new List<GroupDelegate>
        {
            Sort.SortingAlgorithms.CombSort,        //3.1
            Sort.SortingAlgorithms.HeapSort,        //3.2
            Sort.SortingAlgorithms.QuickSort,       //3.3
            Sort.SortingAlgorithms.MergeSort,       //3.4
            Sort.SortingAlgorithms.CountingSort,    //3.5
            Sort.SortingAlgorithms.BucketSort,      //3.6
            Sort.SortingAlgorithms.RadiaxSort,      //3.7
        };

        //test data delegates
        public delegate int[] TestDataDelegate(ref int size, int modulus);

        List<TestDataDelegate> firstTestData = new List<TestDataDelegate>
        {
            TestData.Arrays.RandNum,
        };

        List<TestDataDelegate> secondTestData = new List<TestDataDelegate>
        {
            TestData.Arrays.SortArrays,
        };

        List<TestDataDelegate> thirdTestData = new List<TestDataDelegate>
        {
            TestData.Arrays.PermutationArray
        };
        List<TestDataDelegate> fourthTestData = new List<TestDataDelegate>
        {
            TestData.Arrays.ForwardSortArray,
            TestData.Arrays.ReverseSortArray,
            TestData.Arrays.ReplaceElementsArray,
            TestData.Arrays.RepeatElArray
        };

        // производит тест на выбранной группе сортировок по выбранным тестовым данным
        public static void StartTest(int size, List<GroupDelegate> sortAlgorithms, List<TestDataDelegate> testData,
            out Dictionary<int, List<long>> dictionary, int modulus = 1000)
        {
            dictionary = new Dictionary<int, List<long>>();
            List<long> timeList = new List<long>();
            int i = 0;

            foreach (GroupDelegate sort in sortAlgorithms)
            {
                foreach (TestDataDelegate data in testData)
                {
                    int[] array = data(ref size, modulus);
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();

                    sort(array);

                    stopwatch.Stop();
                    timeList.Add(stopwatch.ElapsedMilliseconds);
                }
                List<long> list = new List<long>();
                if (dictionary.ContainsKey(i))
                    dictionary[i] = list;                
                else
                    dictionary.Add(i, list);

                foreach (long time in timeList)
                    dictionary[i].Add(time);
                i++;
                timeList.Clear();
            }
        }

        //в функцию подают 2 числа: 1- номер группы сортировки и 2 - номер тестовых данных. 
        public double[][] Testing(int groupNumber, int groupData)
        {
            List<GroupDelegate> groupDelegate = null;
            List<TestDataDelegate> testDataDelegate = null;
            double[][] result = new double[0][];
            int divisor = 1;
            int size;

            switch (groupNumber)
            {
                case 1:
                    result = new double[5][];
                    groupDelegate = firstGroup;
                    size = 10000;
                    break;
                case 2:
                    result = new double[3][];
                    groupDelegate = secondGroup;
                    size = 100000;
                    break;
                case 3:
                    result = new double[7][];
                    groupDelegate = thirdGroup;
                    size = 1000000;
                    break;
                default:
                    result = new double[5][];
                    groupDelegate = firstGroup;
                    size = 10000;
                    break;
            }
            switch (groupData)
            {
                case 1:
                    testDataDelegate = firstTestData;
                    break;
                case 2:
                    testDataDelegate = secondTestData;
                    break;
                case 3:
                    testDataDelegate = thirdTestData;
                    break;
                case 4:
                    testDataDelegate = fourthTestData;
                    break;
                default:
                    testDataDelegate = firstTestData;
                    divisor = 4;
                    break;
            }

            Dictionary<int, List<long>> dict = new Dictionary<int, List<long>>();
            Parallel.For(0, 20, i =>
            {
                StartTest(size, groupDelegate, testDataDelegate, out dict);
            });
            foreach (int keys in dict.Keys)
            {
                int a = 0;
                for (int j = 0; j < divisor; j++)
                    result[keys] = new double[divisor];
                foreach (long value in dict[keys])
                {
                    result[keys][a] += value;
                    a++;
                    if (a == divisor)
                        a = 0;
                }
            }
            for (int i = 0; i < result.Length; i++)
            {
                for (int j = 0; j < result[i].Length; j++)
                {
                    result[i][j] /= 20;
                }
            }
            return result;
        }
    }
}