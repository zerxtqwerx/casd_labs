using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Drawing;
using System.Net.Sockets;
using System.Reflection;
using TestData;
using ConsoleApp1;

namespace Test
{
    internal class Test<T>
    {
        private static T[][] array1 = null;
        private static T[][] array2 = null;
        private static T[][] array3 = null;
        private static T[][] array4 = null;

        //sorting algorithms delegates
        public delegate void GroupDelegate(T[] array, Comparison<T> comparer);

        List<GroupDelegate> firstGroup = new List<GroupDelegate>
        {
            Sort.SortingAlgorithms<T>.BubbleSort,      //1.1
            Sort.SortingAlgorithms<T>.InsertionSort,   //1.2
            Sort.SortingAlgorithms<T>.SelectionSort,   //1.3
            Sort.SortingAlgorithms<T>.ShakerSort,      //1.4
            Sort.SortingAlgorithms<T>.GnomeSort,       //1.5
        };

        List<GroupDelegate> secondGroup = new List<GroupDelegate>
        {
            Sort.SortingAlgorithms < T >.BitonicSort,     //2.1
            Sort.SortingAlgorithms < T >.ShellSort,       //2.2
            Sort.SortingAlgorithms < T >.TreeSort,        //2.3
        };
        List<GroupDelegate> thirdGroup = new List<GroupDelegate>
        {
            Sort.SortingAlgorithms < T >.CombSort,        //3.1
            Sort.SortingAlgorithms < T >.HeapSort,        //3.2
            Sort.SortingAlgorithms < T >.QuickSort,       //3.3
            Sort.SortingAlgorithms < T >.MergeSort,       //3.4
            Sort.SortingAlgorithms < T >.CountingSort,    //3.5
            Sort.SortingAlgorithms < T >.BucketSort,      //3.6
            Sort.SortingAlgorithms < T >.RadiaxSort,      //3.7
        };

        //test data delegates
        public delegate T[] TestDataDelegate(int size, T min, T max, Comparison<T> comparer);

        List<TestDataDelegate> firstTestData = new List<TestDataDelegate>
        {
            TestData.Arrays<T>.RandNum,
        };

        List<TestDataDelegate> secondTestData = new List<TestDataDelegate>
        {
            TestData.Arrays<T>.SortArrays,
        };

        List<TestDataDelegate> thirdTestData = new List<TestDataDelegate>
        {
            TestData.Arrays<T>.PermutationArray
        };
        List<TestDataDelegate> fourthTestData = new List<TestDataDelegate>
        {
            TestData.Arrays<T>.ForwardSortArray,
        };
        List<TestDataDelegate> fifthTestData = new List<TestDataDelegate> 
        {
            TestData.Arrays<T>.ReverseSortArray
        };
        List<TestDataDelegate> sixthTestData = new List<TestDataDelegate> 
        {
            TestData.Arrays<T>.ReplaceElementsArray
        };
        List<TestDataDelegate> seventhTestData = new List<TestDataDelegate>
        {
            TestData.Arrays<T>.RepeatElArray
        };


        List<GroupDelegate> groupDelegate = null;
        List<TestDataDelegate> testDataDelegate = null;
        int groupNumber = 0;
        int testNumber = 0;
        int divisor = 1;
        int size = 10000;

        public void InitialTest(int groupNumber_, int testNumber_, T min, T max, Comparison< T> comparer)
        {
            groupNumber = groupNumber_ + 1;
            testNumber = testNumber_ + 1;
            
            //инициализируем группу делегатов, группу сортировок, делитель (сколько массивов сортирует каждая сортировка) и границу размеров массивов
            switch (groupNumber)
            {
                case 1:
                    groupDelegate = new List<GroupDelegate>(firstGroup);                   
                    size = 10000;
                    break;
                case 2:
                    groupDelegate = new List<GroupDelegate>(secondGroup);
                    size = 100000;
                    break;
                case 3:
                    groupDelegate = new List<GroupDelegate>(thirdGroup);
                    size = 1000000;
                    break;
                default:
                    groupDelegate = new List<GroupDelegate>(firstGroup);
                    size = 10000;
                    break;
            }
            switch (testNumber)
            {
                case 1:
                    testDataDelegate = new List<TestDataDelegate>(firstTestData);
                    break;
                case 2:
                    testDataDelegate = new List<TestDataDelegate>(secondTestData);
                    break;
                case 3:
                    testDataDelegate = new List<TestDataDelegate>(thirdTestData);
                    break;
                case 4:
                    testDataDelegate = new List<TestDataDelegate>(fourthTestData);
                    break;
                case 5:
                    testDataDelegate = new List<TestDataDelegate>(fifthTestData);
                    break;
                case 6:
                    testDataDelegate = new List<TestDataDelegate>(sixthTestData);
                    break;
                case 7:
                    testDataDelegate = new List<TestDataDelegate>(seventhTestData);
                    break;
                default:
                    testDataDelegate = new List<TestDataDelegate>(firstTestData);
                    divisor = 4;
                    break;
            }
            
            GenerateArrays(min, max, comparer);
        }

        //генерирует тестовые массивы. инициализирует массив массивов для каждого типа подготовленных данных. количество массивов = наибольшей степени 10 в size (значение логарифма)
        public void GenerateArrays(T min, T max, Comparison<T> comparer)
        {
            if (testDataDelegate.Count == 1)
            {
                array1 = new T[(int)Math.Log(size, 10)][];
                //Console.WriteLine(Math.Log(size, 10));
                int c = 0;
                for (int i = 10; i < size + 1; i *= 10)
                {
                    array1[c] = new T[i];
                    array1[c] = testDataDelegate[0](i, min, max, comparer);
                    c++;
                }

                
            }
            else if (testDataDelegate.Count == 4)
            {
                array1 = new T[(int)Math.Log(size, 10)][];
                array2 = new T[(int)Math.Log(size, 10)][];
                array3 = new T[(int)Math.Log(size, 10)][];
                array4 = new T[(int)Math.Log(size, 10)][];
                int c = 0;

                for (int i = 10; i < size + 1; i *= 10)
                {
                    array1[c] = new T[i];
                    array2[c] = new T[i];
                    array3[c] = new T[i];
                    array4[c] = new T[i];

                    array1[c] = testDataDelegate[0](i, min, max, comparer);
                    array2[c] = testDataDelegate[1](i, min, max, comparer);
                    array3[c] = testDataDelegate[2](i, min, max, comparer);
                    array4[c] = testDataDelegate[3](i, min, max, comparer);

                    c++;
                }            
            }
        }
        public void StartTest(Comparison<T> comparer)//out double[] x, out double[][] y)
        {
            double[] x = new double[array1.Length];
            long[][] y = new long[groupDelegate.Count][];

            if (groupDelegate != null)
            {

                if (testDataDelegate.Count == 1)
                {
                    for (int sortInd = 0; sortInd != groupDelegate.Count; sortInd++)
                    {
                        y[sortInd] = new long[array1.Length];
                        for (int i = 0; i < array1.Length; i++)
                        {
                            {
                                x[i] = array1[i].Length;
                                long time = 0;
                                Parallel.For(0, 20, j =>
                                {
                                    Stopwatch stopwatch = new Stopwatch();
                                    stopwatch.Start();

                                    groupDelegate[sortInd](array1[i], comparer);

                                    stopwatch.Stop();
                                    time += stopwatch.ElapsedMilliseconds;
                                });
                                time /= 20;
                                y[sortInd][i] = time;
                            }
                        }
                    }
                    ConsoleApp1.Graph graph = new ConsoleApp1.Graph(groupNumber, testNumber, size, x, y);
                    graph.ShowDialog();
                }
                else if (testDataDelegate.Count == 4)
                {

                }
            }
        }
    }
}
