using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.ComponentModel;
using System.Data.SqlTypes;

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
                dictionary.Add(i, list);
                foreach (long time in timeList)
                    dictionary[i].Add(time);
                i++;
                timeList.Clear();
            }
        }


        //в функцию подают 2 числа: 1- номер группы сортировки и 2 - номер тестовых данных. 
        public double[] Testing(int groupNumber, int groupData)
        {
            double[] result = new double[0];
            if (groupNumber == 1)
                result = new double[5];
            else if (groupNumber == 2)
                result = new double[3];
            else if (groupNumber == 3)
                result = new double[7];

            for (int count = 0; count < 20; count++)
            {
                int[][] matrix = new int[0][];
                GroupDelegate groupDelegate = null;
                TestDataDelegate testData = null;
                int size = 0;
                long[] ints = new long[0];

                if (groupNumber == 1)
                {
                    size = 10000;
                    matrix = new int[4][];
                    ints = new long[5];
                    if (groupData == 1)
                    {
                        for (int i = 10; i != size; i *= 10)
                        {
                            Dictionary<int, List<long>> dict = new Dictionary<int, List<long>>();
                            StartTest(size, firstGroup, firstTestData, out dict);

                            for (int j = 0; j != ints.Length; j++)
                            {
                                foreach (long k in dict.Keys)
                                    ints[j] += k;
                                //ints[j] /= 1;
                            }
                        }
                    }
                    else if (groupData == 2)
                    {
                        for (int i = 10; i != size; i *= 10)
                        {
                            Dictionary<int, List<long>> dict = new Dictionary<int, List<long>>();
                            StartTest(size, firstGroup, secondTestData, out dict);

                            for (int j = 0; j != ints.Length; j++)
                            {
                                foreach (long k in dict.Keys)
                                    ints[j] += k;
                                //ints[j] /= 1;
                            }
                        }
                    }
                    else if (groupData == 3)
                    {
                        for (int i = 10; i != size; i *= 10)
                        {
                            Dictionary<int, List<long>> dict = new Dictionary<int, List<long>>();
                            StartTest(size, firstGroup, thirdTestData, out dict);

                            for (int j = 0; j != ints.Length; j++)
                            {
                                foreach (long k in dict.Keys)
                                    ints[j] += k;
                                //ints[j] /= 1;
                            }
                        }
                    }
                    else if (groupData == 4)
                    {
                        for (int i = 10; i != size; i *= 10)
                        {
                            Dictionary<int, List<long>> dict = new Dictionary<int, List<long>>();
                            StartTest(size, firstGroup, fourthTestData, out dict);

                            for (int j = 0; j != ints.Length; j++)
                            {
                                foreach (long k in dict.Keys)
                                    ints[j] += k;
                                ints[j] /= 4;
                            }
                        }
                    }
                }
                else if (groupNumber == 2)
                {
                    size = 100000;
                    matrix = new int[3][];
                    ints = new long[3];
                    if (groupData == 1)
                    {
                        for (int i = 10; i != size; i *= 10)
                        {
                            Dictionary<int, List<long>> dict = new Dictionary<int, List<long>>();
                            StartTest(size, secondGroup, firstTestData, out dict);

                            for (int j = 0; j != ints.Length; j++)
                            {
                                foreach (long k in dict.Keys)
                                    ints[j] += k;
                                //ints[j] /= 1;
                            }
                        }
                    }
                    else if (groupData == 2)
                    {
                        for (int i = 10; i != size; i *= 10)
                        {
                            Dictionary<int, List<long>> dict = new Dictionary<int, List<long>>();
                            StartTest(size, secondGroup, secondTestData, out dict);
                            for (int j = 0; j != ints.Length; j++)
                            {
                                foreach (long k in dict.Keys)
                                    ints[j] += k;
                                //ints[j] /= 1;
                            }
                        }
                    }
                    else if (groupData == 3)
                    {
                        for (int i = 10; i != size; i *= 10)
                        {
                            Dictionary<int, List<long>> dict = new Dictionary<int, List<long>>();
                            StartTest(size, secondGroup, thirdTestData, out dict);

                            for (int j = 0; j != ints.Length; j++)
                            {
                                foreach (long k in dict.Keys)
                                    ints[j] += k;
                                //ints[j] /= 1;
                            }
                        }
                    }
                    else if (groupData == 4)
                    {
                        for (int i = 10; i != size; i *= 10)
                        {
                            Dictionary<int, List<long>> dict = new Dictionary<int, List<long>>();
                            StartTest(size, secondGroup, fourthTestData, out dict);

                            for (int j = 0; j != ints.Length; j++)
                            {
                                foreach (long k in dict.Keys)
                                    ints[j] += k;
                                ints[j] /= 4;
                            }
                        }
                    }
                }
                else if (groupNumber == 3)
                {
                    size = 1000000;
                    matrix = new int[7][];
                    ints = new long[7];
                    if (groupData == 1)
                    {
                        for (int i = 10; i != size; i *= 10)
                        {
                            Dictionary<int, List<long>> dict = new Dictionary<int, List<long>>();
                            StartTest(size, thirdGroup, firstTestData, out dict);

                            for (int j = 0; j != ints.Length; j++)
                            {
                                foreach (long k in dict.Keys)
                                    ints[j] += k;
                                //ints[j] /= 1;
                            }
                        }
                    }
                    else if (groupData == 2)
                    {
                        for (int i = 10; i != size; i *= 10)
                        {
                            Dictionary<int, List<long>> dict = new Dictionary<int, List<long>>();
                            StartTest(size, thirdGroup, secondTestData, out dict);

                            for (int j = 0; j != ints.Length; j++)
                            {
                                foreach (long k in dict.Keys)
                                    ints[j] += k;
                                //ints[j] /= 1;
                            }
                        }
                    }
                    else if (groupData == 3)
                    {
                        for (int i = 10; i != size; i *= 10)
                        {
                            Dictionary<int, List<long>> dict = new Dictionary<int, List<long>>();
                            StartTest(size, thirdGroup, thirdTestData, out dict);

                            for (int j = 0; j != ints.Length; j++)
                            {
                                foreach (long k in dict.Keys)
                                    ints[j] += k;
                                //ints[j] /= 1;
                            }
                        }
                    }
                    else if (groupData == 4)
                    {
                        for (int i = 10; i != size; i *= 10)
                        {
                            Dictionary<int, List<long>> dict = new Dictionary<int, List<long>>();
                            StartTest(size, thirdGroup, fourthTestData, out dict);

                            for (int j = 0; j != ints.Length; j++)
                            {
                                foreach (long k in dict.Keys)
                                    ints[j] += k;
                                ints[j] /= 4;
                            }
                        }
                    }
                }
                
                for(int c = 0; c < result.Length; c++)
                {
                    result[c] = ints[c];
                }
            }
            for (int c = 0; c < result.Length; c++)
            {
                result[c] /= 20;
            }
            return result;
        }
    }
}
