using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestData
{
    public class Arrays
    {
        //массив со случайными числами
        public static int[] RandNum(ref int size, int modulus = 1000)
        {
            int[] array = new int[size];
            Random rand = new Random();

            for (int i = 0; i < size; i++)
                array[i] = rand.Next(0, modulus);

            return array;
        }
        //массив с отсортированными подмассивами случайной длины
        public static int[] SortArrays(ref int size, int modulus = 1000)
        {
            Random rand = new Random();
            int[] arrays = new int[size];

            int i = 0;
            int restSize = size - i;
            while (i < size)
            {
                int subArraySize = rand.Next(0, restSize);
                int[] array = RandNum(ref subArraySize);
                Array.Sort(array);
                for (int j = i; j < array.Length; j++)
                {
                    arrays[i] = array[j];
                    i++;
                }
                restSize -= subArraySize;
            }
            return arrays;
        }

        //массивы с перестановками двух случайных чисел
        public static int[] PermutationArray(ref int size, int modulus = 1000)
        {
            Random rand = new Random();
            int[] array = RandNum(ref size);
            Array.Sort(array);

            int permutationCount = rand.Next(1, array.Length / 2);
            for (int i = 0; i < permutationCount; i++)
            {
                int a = rand.Next(0, size - 1);
                int b = rand.Next(0, size - 1);

                int temp = array[a];
                array[a] = array[b];
                array[b] = array[temp];
            }
            return array;
        }

        //массив, отсортированный в прямом порядке
        public static int[] ForwardSortArray(ref int size, int modulus = 1000)
        {
            Random rand = new Random();
            int[] array = RandNum(ref size);
            Array.Sort(array);
            return array;
        }

        //массив, отсортированный в обратном порядке
        public static int[] ReverseSortArray(ref int size, int modulus = 1000)
        {
            int[] array = ForwardSortArray(ref size);
            Array.Reverse(array);
            return array;
        }

        //массив со случайно переставленными элементами
        public static int[] ReplaceElementsArray(ref int size, int modulus = 1000)
        {
            Random rand = new Random();
            int[] array = RandNum(ref size);
            Array.Sort(array);

            int replaceCount = rand.Next(1, array.Length / 2);
            for (int i = 0; i < replaceCount; i++)
            {
                int a = rand.Next(0, size - 1);
                int b = rand.Next(0, modulus);

                array[a] = b;
            }
            return array;
        }

        //массив с случайным количеством повторений одного случайного элемента
        public static int[] RepeatElArray(ref int size, int modulus = 1000)
        {
            Random rand = new Random();
            int[] array = new int[size];
            int element = rand.Next(0, modulus);
            int frequency = rand.Next(0, 100);
            int count = frequency / 100 * size;
            for (int i = 0; i < count; i++)
            {
                array[i] = element;
            }
            int restSize = size - count;
            int[] array2 = RandNum(ref restSize);

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

