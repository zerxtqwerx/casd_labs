using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.ComponentModel;

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
        public static Dictionary<int, List<long>> StartTest(int size, List<GroupDelegate> sortAlgorithms, List<TestDataDelegate> testData, int modulus = 1000)
        {
            Dictionary<int, List<long>> dictionary = new Dictionary<int, List<long>>();

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
                dictionary.Add(i, timeList);
                i++;
                timeList.Clear();
            }
            return dictionary;
        }

        public int[][] Testing(int groupNumber, int groupData)
        {
            int[][] matrix = new int[0][];
            GroupDelegate groupDelegate = null;
            TestDataDelegate testData = null;
            int size = 0;

            if (groupNumber == 1)
            {
                size = 10000;
                matrix = new int[4][];
                long[] ints = new long[4];
                if (groupData == 1)
                {
                    for (int i = 10; i != size; i *= 10)
                    {
                        Dictionary<int, List<long>> dict = new Dictionary<int, List<long>>();
                        dict = StartTest(size, firstGroup, firstTestData);

                        for (int j = 0; j != ints.Length; j++)
                        {
                            for (int k = 0; k != dict.Count; k++)
                                ints[j] += dict[j][k];
                            //ints[j] /= 1;
                        }
                    }
                }
                else if (groupData == 2)
                {
                    for (int i = 10; i != size; i *= 10)
                    {
                        Dictionary<int, List<long>> dict = new Dictionary<int, List<long>>();
                        dict = StartTest(size, firstGroup, secondTestData);

                        for (int j = 0; j != ints.Length; j++)
                        {
                            for (int k = 0; k != dict.Count; k++)
                                ints[j] += dict[j][k];
                            //ints[j] /= 1;
                        }
                    }
                }
                else if (groupData == 3)
                {
                    for (int i = 10; i != size; i *= 10)
                    {
                        Dictionary<int, List<long>> dict = new Dictionary<int, List<long>>();
                        dict = StartTest(size, firstGroup, thirdTestData);

                        for (int j = 0; j != ints.Length; j++)
                        {
                            for (int k = 0; k != dict.Count; k++)
                                ints[j] += dict[j][k];
                            //ints[j] /= 1;
                        }
                    }
                }
                else if (groupData == 4)
                {
                    for (int i = 10; i != size; i *= 10)
                    {
                        Dictionary<int, List<long>> dict = new Dictionary<int, List<long>>();
                        dict = StartTest(size, firstGroup, secondTestData);

                        for (int j = 0; j != ints.Length; j++)
                        {
                            for (int k = 0; k != dict.Count; k++)
                                ints[j] += dict[j][k];
                            ints[j] /= 4;
                        }
                    }
                }
            }
            else if (groupNumber == 2)
            {
                size = 100000;
                matrix = new int[3][];
                long[] ints = new long[3];
                if (groupData == 1)
                {
                    for (int i = 10; i != size; i *= 10)
                    {
                        Dictionary<int, List<long>> dict = new Dictionary<int, List<long>>();
                        dict = StartTest(size, secondGroup, firstTestData);

                        for (int j = 0; j != ints.Length; j++)
                        {
                            for (int k = 0; k != dict.Count; k++)
                                ints[j] += dict[j][k];
                            //ints[j] /= 1;
                        }
                    }
                }
                else if (groupData == 2)
                {
                    for (int i = 10; i != size; i *= 10)
                    {
                        Dictionary<int, List<long>> dict = new Dictionary<int, List<long>>();
                        dict = StartTest(size, secondGroup, secondTestData);

                        for (int j = 0; j != ints.Length; j++)
                        {
                            for (int k = 0; k != dict.Count; k++)
                                ints[j] += dict[j][k];
                            //ints[j] /= 1;
                        }
                    }
                }
                else if (groupData == 3)
                {
                    for (int i = 10; i != size; i *= 10)
                    {
                        Dictionary<int, List<long>> dict = new Dictionary<int, List<long>>();
                        dict = StartTest(size, secondGroup, thirdTestData);

                        for (int j = 0; j != ints.Length; j++)
                        {
                            for (int k = 0; k != dict.Count; k++)
                                ints[j] += dict[j][k];
                            //ints[j] /= 1;
                        }
                    }
                }
                else if (groupData == 4)
                {
                    for (int i = 10; i != size; i *= 10)
                    {
                        Dictionary<int, List<long>> dict = new Dictionary<int, List<long>>();
                        dict = StartTest(size, secondGroup, secondTestData);

                        for (int j = 0; j != ints.Length; j++)
                        {
                            for (int k = 0; k != dict.Count; k++)
                                ints[j] += dict[j][k];
                            ints[j] /= 4;
                        }
                    }
                }
            }
            else if (groupNumber == 3)
            {
                size = 1000000;
                matrix = new int[7][];
                long[] ints = new long[7];
                if (groupData == 1)
                {
                    for (int i = 10; i != size; i *= 10)
                    {
                        Dictionary<int, List<long>> dict = new Dictionary<int, List<long>>();
                        dict = StartTest(size, secondGroup, firstTestData);

                        for (int j = 0; j != ints.Length; j++)
                        {
                            for (int k = 0; k != dict.Count; k++)
                                ints[j] += dict[j][k];
                            //ints[j] /= 1;
                        }
                    }
                }
                else if (groupData == 2)
                {
                    for (int i = 10; i != size; i *= 10)
                    {
                        Dictionary<int, List<long>> dict = new Dictionary<int, List<long>>();
                        dict = StartTest(size, secondGroup, secondTestData);

                        for (int j = 0; j != ints.Length; j++)
                        {
                            for (int k = 0; k != dict.Count; k++)
                                ints[j] += dict[j][k];
                            //ints[j] /= 1;
                        }
                    }
                }
                else if (groupData == 3)
                {
                    for (int i = 10; i != size; i *= 10)
                    {
                        Dictionary<int, List<long>> dict = new Dictionary<int, List<long>>();
                        dict = StartTest(size, secondGroup, thirdTestData);

                        for (int j = 0; j != ints.Length; j++)
                        {
                            for (int k = 0; k != dict.Count; k++)
                                ints[j] += dict[j][k];
                            //ints[j] /= 1;
                        }
                    }
                }
                else if (groupData == 4)
                {
                    for (int i = 10; i != size; i *= 10)
                    {
                        Dictionary<int, List<long>> dict = new Dictionary<int, List<long>>();
                        dict = StartTest(size, secondGroup, secondTestData);

                        for (int j = 0; j != ints.Length; j++)
                        {
                            for (int k = 0; k != dict.Count; k++)
                                ints[j] += dict[j][k];
                            ints[j] /= 4;
                        }
                    }
                }
            }
            return matrix;
        }
    }
}
