using System;

namespace TestData
{
    public class Arrays<T>
    {
        private static T GenerateRandom(T min, T max, Comparison<T> comparer)
        {
            Random rand = new Random();
            T n;
            do
            {
                n = (T)(object)rand.Next();
            }
            while (comparer(n, max) > 0 || comparer(n, min) < 0);
            return n;
        }

        //массив со случайными числами
        public static T[] RandNum(int size, T min, T max, Comparison<T> comparer)
        {
            T[] array = new T[size];
            Random rand = new Random();

            for (int i = 0; i < size; i++)
                array[i] = GenerateRandom(min, max, comparer);

            return array;
        }
        //массив с отсортированными подмассивами случайной длины
        public static T[] SortArrays(int size, T min, T max, Comparison<T> comparer)
        {
            Random rand = new Random();
            T[] arrays = new T[size];

            int i = 0;
            int restSize = size - i;
            while (i < size)
            {
                int subArraySize = rand.Next(0, restSize);
                T[] array = RandNum(subArraySize, min, max, comparer);
                Array.Sort(array);
                for (int j = 0; j < array.Length; j++)
                {
                    arrays[i] = array[j];
                    i++;
                }
                restSize -= subArraySize;
            }
            return arrays;
        }

        //массивы с перестановками двух случайных чисел
        public static T[] PermutationArray(int size, T min, T max, Comparison<T> comparer)
        {
            Random rand = new Random();
            T[] array = RandNum(size, min, max, comparer);
            Array.Sort(array);

            int permutationCount = rand.Next(1, array.Length / 2);
            for (int i = 0; i < permutationCount; i++)
            {
                int a = rand.Next(0, size - 1);
                int b = rand.Next(0, size - 1);

                T temp = array[a];
                array[a] = array[b];
                array[b] = temp;
            }
            return array;
        }

        //массив, отсортированный в прямом порядке
        public static T[] ForwardSortArray(int size, T min, T max, Comparison<T> comparer)
        {
            Random rand = new Random();
            T[] array = RandNum(size, min, max, comparer);
            Array.Sort(array);
            return array;
        }

        //массив, отсортированный в обратном порядке
        public static T[] ReverseSortArray(int size, T min, T max, Comparison<T> comparer)
        { 
            T[] array = ForwardSortArray(size, min, max, comparer);
            Array.Reverse(array);
            return array;
        }

        //массив со случайно переставленными элементами
        public static T[] ReplaceElementsArray(int size, T min, T max, Comparison<T> comparer)
        { 
            Random rand = new Random();
            T[] array = RandNum(size, min, max, comparer);
            Array.Sort(array);

            int replaceCount = rand.Next(1, array.Length / 2);
            for (int i = 0; i < replaceCount; i++)
            {
                int a = rand.Next(0, size - 1);

                int b = rand.Next(0, size - 1);

                T temp = array[a];
                array[a] = array[b];
                array[b] = temp;
            }
            return array;
        }

        //массив с случайным количеством повторений одного случайного элемента
        public static T[] RepeatElArray(int size, T min, T max, Comparison<T> comparer)
        {
            Random rand = new Random();
            T[] array = new T[size];
            T element = GenerateRandom(min, max, comparer);
            int frequency = rand.Next(0, 100);
            int count = frequency / 100 * size;
            for (int i = 0; i < count; i++)
            {
                array[i] = element;
            }
            int restSize = size - count;
            T[] array2 = RandNum(restSize, min, max, comparer);

            int j = 0;
            for (int i = count; i < size; i++)
            {
                array[i] = array2[j];
                j++;
            }
            return array;
        }
    }
}

