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
using static Test.Test;
using System.Reflection;
using TestData;
using ConsoleApp1;

namespace Test
{
    internal class Test
    {
        private static int[][] array1 = null;
        private static int[][] array2 = null;
        private static int[][] array3 = null;
        private static int[][] array4 = null;

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
        public delegate int[] TestDataDelegate(ref int size, int modulus = 1000);

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

        List<GroupDelegate> groupDelegate = null;
        List<TestDataDelegate> testDataDelegate = null;
        int groupNumber = 0;
        int testNumber = 0;
        int divisor = 1;
        int size = 10000;

        public void InitialTest(int groupNumber_, int testNumber_)
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
                default:
                    testDataDelegate = new List<TestDataDelegate>(firstTestData);
                    divisor = 4;
                    break;
            }
            
            GenerateArrays();
        }

        //генерирует тестовые массивы. инициализирует массив массивов для каждого типа подготовленных данных. количество массивов = наибольшей степени 10 в size (значение логарифма)
        public void GenerateArrays()
        {
            if (testDataDelegate.Count == 1)
            {
                array1 = new int[(int)Math.Log(size, 10)][];
                int c = 0;
                for (int i = 10; i < size + 1; i *= 10)
                {
                    array1[c] = new int[i];
                    array1[c] = testDataDelegate[0](ref i);
                    c++;
                }

                
            }
            else if (testDataDelegate.Count == 4)
            {
                array1 = new int[(int)Math.Log(size, 10)][];
                array2 = new int[(int)Math.Log(size, 10)][];
                array3 = new int[(int)Math.Log(size, 10)][];
                array4 = new int[(int)Math.Log(size, 10)][];
                int c = 0;
                for (int i = 10; i < size + 1; i *= 10)
                {
                    array1[c] = new int[i];
                    array2[c] = new int[i];
                    array3[c] = new int[i];
                    array4[c] = new int[i];

                    array1[c] = testDataDelegate[0](ref i);
                    array2[c] = testDataDelegate[1](ref i);
                    array3[c] = testDataDelegate[2](ref i);
                    array4[c] = testDataDelegate[3](ref i);

                    c++;
                }            
            }
        }
        public void StartTest()//out double[] x, out double[][] y)
        {
            double[] x = new double[array1.Length];
            double[][] y = new double[groupDelegate.Count][];

            if (groupDelegate != null)
            {

                if (testDataDelegate.Count == 1)
                {
                    for (int sortInd = 0; sortInd != groupDelegate.Count; sortInd++)
                    {
                        y[sortInd] = new double[array1.Length];
                        for (int i = 0; i < array1.Length; i++)
                        {
                            {
                                x[i] = array1[i].Length;
                                double time = 0;
                                Parallel.For(0, 20, j =>
                                {
                                    Stopwatch stopwatch = new Stopwatch();
                                    stopwatch.Start();

                                    groupDelegate[sortInd](array1[i]);

                                    stopwatch.Stop();
                                    time += stopwatch.ElapsedMilliseconds;
                                });
                                time /= 20;
                                y[sortInd][i] = time;
                            }
                        }
                    }
                    ConsoleApp1.Graph graph = new ConsoleApp1.Graph(groupNumber, testNumber, size);
                    graph.DrawGraph(x, y);
                    graph.ShowDialog();
                }
                else if (testDataDelegate.Count == 4)
                {

                }
            }
            //graph.ShowDialog();
        }
    }
}

        /*// производит тест на выбранной группе сортировок по выбранным тестовым данным
        public static void StartTest(int size, List<GroupDelegate> sortAlgorithms, List<TestDataDelegate> testData,
            out Dictionary<int, List<long>> dictionary, int modulus = 1000)
        {
            //создаем словарь, массив и индекс
            dictionary = new Dictionary<int, List<long>>();
            List<long> timeList = new List<long>();
            int i = 0;

            //для каждой сортировки из группы создаем массив, засекаем время и проводим каждую сортировку из группы сортировку
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
                //проверяем, есть ли ключ(номер сортировки) в словаре. если нет - добавляем ключ и лист
                List<long> list = new List<long>();
                

                //копируем время в словарь по индексу сортировки

                foreach (long time in timeList)
                {
                    long t = time;
                    if (dictionary.ContainsKey(i))
                    {
                        // Если ключа нет, создаем новый список и добавляем его в словарь
                        List<long> l = new List<long>();
                        dictionary.Add(i, l);
                        // Добавляем значение в существующий или только что созданный список
                        dictionary[i].Add(t);
                    }
                }
                //очищаем массив времени и увеличиваем индекс(номер сортировки)
                i++;
                timeList.Clear();
            }
        }

        //в функцию подают 2 числа: 1- номер группы сортировки и 2 - номер тестовых данных. 
        public double[][] Testing(int groupNumber, int groupData)
        {
            
            List<GroupDelegate> groupDelegate = null;
            List<TestDataDelegate> testDataDelegate = null;
            //результат - матрица, строки - номера сортировок, столбцы - группа тестовых данных.
            //первые n элементов в столбцах = делителям divisor - результаты сортировки на массивах размером 10 тестовых данных. каждые последующие n сортировок
            //в столбце - следующая степень 10 в размере массива.
            double[][] result = new double[0][];
            int divisor = 1;
            int size;

            //инициализируем группу делегатов, группу сортировок, делитель (сколько массивов сортирует каждая сортировка) и границу размеров массивов
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
            for(int i = 0; i < result.Length; i++)
                result[i] = new double[divisor];

            //создаем словарь
            Dictionary<int, List<long>> dict = new Dictionary<int, List<long>>();
            //для каждого ключа (номер сортировки, строкиа в матрице) инициализируем столбцы (количество различных тестов в группе тестовых данных. 1,2,3 - 1 тестовый массив. 4 - 4 тестовых массива)
            foreach (int keys in dict.Keys)
            {
                for (int j = 0; j < divisor; j++)
                    result[keys] = new double[divisor];
            }
            int a = 0;
            //тестируем на массивах рамером от 10 до границы 
            for (int s = 0; s < size + 1; s *= 10)
            {

                //проводим 20 тестов для каждого размера массива
                Parallel.For(0, 20, i =>
                {
                    StartTest(s, groupDelegate, testDataDelegate, out dict);
                });

                foreach (int keys in dict.Keys)
                {         
                    int b = a;
                    //для каждого ключа (номера сортировки) добавляем значение времени. после выполнения цикла в каждой ячейке будет сумма 20 сортировок по соответсвующему времени и номеру массива в группе тестовых данных
                    foreach (long value in dict[keys])
                    {
                        result[keys][b] += value;
                        b++;
                        if (b == divisor)
                            b = 0;
                    }
                }
            }
            a += divisor;
            
            //делим каждый элемент на 20 - количество произведенных тестов для каждой сортировки и массива из группы тестовых данных
            for (int i = 0; i < result.Length; i++)
            {
                for (int j = 0; j < result[i].Length; j++)
                {
                    result[i][j] /= 20;
                }
            }
            return result;
        }
    }*/
    