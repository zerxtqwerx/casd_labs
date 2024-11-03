using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sort
{
    public class SortingAlgorithms<T>
    {

        public static void BubbleSort<T>(T[] array, Comparison<T> comparer)
        {
            T temp;
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (comparer(array[i], array[i - 1]) > 0)
                    {
                        temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
        }

        public static void ShakerSort(T[] array, Comparison<T> comparer)
        {
            bool swapped = true;
            int start = 0;
            int end = array.Length;

            while (swapped == true)
            {
                swapped = false;
                for (int i = start; i < end - 1; ++i)
                {
                    if (comparer(array[i], array[i + 1]) > 0)
                    {
                        T temp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = temp;
                        swapped = true;
                    }
                }
                if (swapped == false)
                    break;
                swapped = false;
                end = end - 1;
                for (int i = end - 1; i >= start; i--)
                {
                    if (comparer(array[i], array[i + 1]) > 0)
                    {
                        T temp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = temp;
                        swapped = true;
                    }
                }
                start = start + 1;
            }
        }

        public static void CombSort(T[] array, Comparison<T> comparer)
        {
            int length = array.Length;
            int gap = length;
            bool swapped = true;

            while (gap != 1 || swapped == true)
            {
                gap = GetNextGap(gap);
                swapped = false;
                for (int i = 0; i < length - gap; i++)
                {
                    if (comparer(array[i], array[i + gap]) > 0)
                    {
                        T temp = array[i];
                        array[i] = array[i + gap];
                        array[i + gap] = temp;

                        swapped = true;
                    }
                }
            }
        }

        static int GetNextGap(int gap)
        {
            gap = (gap * 10) / 13;
            if (gap < 1)
            {
                return 1;
            }
            return gap;
        }

        public static void InsertionSort(T[] array, Comparison<T> comparer)
        {
            int n = array.Length;
            for (int i = 1; i < n; ++i)
            {
                T key = array[i];
                int j = i - 1;
                while (j >= 0 && comparer(array[j], key) > 0)
                {
                    array[j + 1] = array[j];
                    j = j - 1;
                }
                array[j + 1] = key;
            }
        }

        public static void ShellSort(T[] array, Comparison<T> comparer)
        {
            int i, j, inc;
            T temp;
            inc = 3;
            while (inc > 0)
            {
                for (i = 0; i < array.Length; i++)
                {
                    j = i;
                    temp = array[i];
                    while ((j >= inc) && comparer(array[j - inc], temp) > 0)
                    {
                        array[j] = array[j - inc];
                        j = j - inc;
                    }
                    array[j] = temp;
                }
                if (inc / 2 != 0)
                    inc = inc / 2;
                else if (inc == 1)
                    inc = 0;
                else
                    inc = 1;
            }
        }

        class Node<T>
        {
            public T Data;
            public Node Left;
            public Node Right;

            public Node(T data)
            {
                Data = data;
                Left = null;
                Right = null;
            }
        }

        class BinarySearchTree
        {
            public Node<T> Root;

            public BinarySearchTree()
            {
                Root = null;
            }

            public void Insert(T data, Comparison<T> comparer)
            {
                Root = InsertRec(Root, data, comparer);
            }

            private Node<T> InsertRec(Node<T> root, T data, Comparison<T> comparer)
            {
                if (root == null)
                {
                    root = new Node<T>(data);
                    return root;
                }

                if (comparer(data,root.Data) < 0)
                    root.Left = InsertRec(root.Left, data);
                else
                    root.Right = InsertRec(root.Right, data);

                return root;
            }

            public void InOrderTraversal(Node<T> root, List<T> result)
            {
                if (root != null)
                {
                    InOrderTraversal(root.Left, result);
                    result.Add(root.Data);
                    InOrderTraversal(root.Right, result);
                }
            }
        }

        public static void TreeSort(T[] array, Comparison<T> comparer)
        {
            BinarySearchTree bst = new BinarySearchTree();
            foreach (T value in array)
            {
                bst.Insert(value, comparer);
            }
            List<T> sortedList = new List<T>();
            bst.InOrderTraversal(bst.Root, sortedList);
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = sortedList[i];
            }
        }

        public static void GnomeSort(T[] array, Comparison<T> comparer)
        {
            if (array.Length <= 1)
            {
                return;
            }

            int index = 0;

            while (index < array.Length)
            {
                if (index == 0)
                {
                    index++;
                }
                else if (comparer(array[index], array[index - 1]) >= 0)
                {
                    index++;
                }
                else
                {
                    T temp = array[index];
                    array[index] = array[index - 1];
                    array[index - 1] = temp;
                    index--;
                }
            }
        }

        public static void SelectionSort(T[] array, Comparison<T> comparer)
        {
            int n = array.Length;
            for (int i = 0; i < n - 1; i++)
            {
                int min_idx = i;
                for (int j = i + 1; j < n; j++)
                    if (comparer(array[j], array[min_idx]) < 0)
                        min_idx = j;
                T temp = array[min_idx];
                array[min_idx] = array[i];
                array[i] = temp;
            }
        }

        public static void HeapSort(T[] array, Comparison<T> comparer)
        {
            int N = array.Length;
            for (int i = N / 2 - 1; i >= 0; i--)
                Heapify(array, N, i, comparer);
            for (int i = N - 1; i > 0; i--)
            {
                T temp = array[0];
                array[0] = array[i];
                array[i] = temp;
                Heapify(array, i, 0, comparer);
            }
        }

        static void Heapify(T[] array, int N, int i, Comparison<T> comparer)
        {
            int largest = i;
            int l = 2 * i + 1;
            int r = 2 * i + 2;
            if (l < N && (comparer(array[l], array[largest]) > 0))
                largest = l;
            if (r < N && comparer(array[r], array[largest]) > 0)
                largest = r;
            if (largest != i)
            {
                T swap = array[i];
                array[i] = array[largest];
                array[largest] = swap;
                Heapify(array, N, largest, comparer);
            }
        }

        public static void QuickSort(T[] array, int left, int right, Comparison<T> comparer)
        {
            if (left < right)
            {
                int pivotIndex = Partition(array, left, right, comparer);
                QuickSort(array, left, pivotIndex - 1, comparer);
                QuickSort(array, pivotIndex + 1, right, comparer);
            }
        }

        public static void QuickSort(T[] array, Comparison<T> comparer)
        {
            QuickSort(array, 0, array.Length - 1, comparer);
        }

        static int Partition(T[] array, int left, int right, Comparison<T> comparer)
        {
            T pivot = array[right];
            int i = left - 1;

            for (int j = left; j < right; j++)
            {
                if (comparer(array[j],pivot) <= 0)
                {
                    i++;
                    T temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }
            }

            T temp1 = array[i + 1];
            array[i + 1] = array[right];
            array[right] = temp1;

            return i + 1;
        }

        static void Merge(T[] array, int l, int m, int r, Comparison<T> comparer)
        {
            int n1 = m - l + 1;
            int n2 = r - m;
            T[] L = new T[n1];
            T[] R = new T[n2];
            int i, j;
            for (i = 0; i < n1; ++i)
                L[i] = array[l + i];
            for (j = 0; j < n2; ++j)
                R[j] = array[m + 1 + j];
            i = 0;
            j = 0;
            int k = l;
            while (i < n1 && j < n2)
            {
                if (comparer(L[i], R[j]) <= 0)
                {
                    array[k] = L[i];
                    i++;
                }
                else
                {
                    array[k] = R[j];
                    j++;
                }
                k++;
            }
            while (i < n1)
            {
                array[k] = L[i];
                i++;
                k++;
            }
            while (j < n2)
            {
                array[k] = R[j];
                j++;
                k++;
            }
        }

        public static void MergeSort(T[] array, int l, int r, Comparison<T> comparer)
        {
            if (l < r)
            {
                int m = l + (r - l) / 2;
                MergeSort(array, l, m, comparer);
                MergeSort(array, m + 1, r, comparer);
                Merge(array, l, m, r, comparer);
            }
        }

        public static void MergeSort(T[] array, Comparison<T> comparer)
        {
            MergeSort(array, 0, array.Length - 1, comparer);
        }

        public static void CountingSort(T[] array, Comparison<T> comparer)
        {
            if (array.Length == 0) return;

            T FindMaxValue(T[] arr)
            {
                if (arr.Length == 0)
                {
                    throw new ArgumentException("Array is empty.");
                }

                T maxValue = arr[0];
                for (int i = 1; i < arr.Length; i++)
                {
                    if (comparer(arr[i], maxValue) > 0)
                    {
                        maxValue = arr[i];
                    }
                }

                return maxValue;
            }

            T k;
            try
            {
                k = FindMaxValue(array);
            }
            catch
            {
                return;
            }

            var count = new int[Convert.ToInt32(k) + 1];
            for (var i = 0; i < array.Length; i++)
            {
                count[Convert.ToInt32(array[i])]++;

            }

            var index = 0;
            for (var i = 0; i < count.Length; i++)
            {
                for (var j = 0; j < count[i]; j++)
                {
                    array[index] = i;
                    index++;
                }
            }
        }

        public static void BucketSort(T[] array, int bucketCount, Comparison<T> comparer)
        {
            if (array.Length <= 1)
            {
                return;
            }

            var buckets = new List<T>[bucketCount];
            for (int i = 0; i < bucketCount; i++)
                buckets[i] = new List<T>();

            var min = double.MaxValue;
            var max = -double.MaxValue;

            for (int i = 0; i < array.Length; i++)
            {
                min = Math.Min(min, Convert.ToSByte(array[i]));
                max = Math.Max(max, Convert.ToSByte(array[i]));
            }

            for (int i = 0; i < array.Length; i++)
            {
                int idx;
                if (max == min)
                {
                    idx = 0;
                }
                else
                {
                    idx = Math.Min(bucketCount - 1, (int)(bucketCount * (Convert.ToDouble(array[i]) - min) / (max - min)));
                }
                buckets[idx].Add(array[i]);
            }

            var index = 0;
            for (var i = 0; i < bucketCount; i++)
            {
                buckets[i].Sort();

                for (var j = 0; j < buckets[i].Count; j++)
                {
                    array[index++] = buckets[i][j];
                }
            }
        }

        public static void BucketSort(T[] array, Comparison<T> comparer)
        {
            BucketSort(array, array.Length + 1, comparer);
        }
        public static void RadiaxSort(T[] arr, Comparison<T> comparer)
        {
            int i, j;
            T[] tmp = new T[arr.Length];
            for (T shift = (T)(object)31; comparer(shift,(T)(object)-1 ) > 0; shift--)
            {
                j = 0;
                for (i = 0; i < arr.Length; ++i)
                {
                    bool move = (arr[i] << shift) >= 0;
                    if (comparer(shift, (T)(object)0) == 0 ? !move : move)
                        arr[i - j] = arr[i];
                    else
                        tmp[j++] = arr[i];
                }
                Array.Copy(tmp, 0, arr, arr.Length - j, j);
            }
        }

        static void BitSeqSort(T[] arr, int left, int right, bool inv, Comparison<T> comparer)
        {
            if (right - left <= 1) return;
            int mid = left + (right - left) / 2;

            for (int i = left, j = mid; i < mid && j < right; i++, j++)
            {
                if (inv ^ (comparer(arr[i], arr[j]) > 0))
                {
                    Swap(ref arr[i], ref arr[j]);
                }
            }

            BitSeqSort(arr, left, mid, inv, comparer);
            BitSeqSort(arr, mid, right, inv, comparer);
        }

        static void MakeBitonic(T[] arr, int left, int right, Comparison<T> comparer)
        {
            if (right - left <= 1) return;
            int mid = left + (right - left) / 2;

            MakeBitonic(arr, left, mid, comparer);
            BitSeqSort(arr, left, mid, false, comparer);
            MakeBitonic(arr, mid, right, comparer);
            BitSeqSort(arr, mid, right, true, comparer);
        }

        public static void BitonicSort(T[] arr, Comparison<T> comparer)
        {
            if (arr.Length == 0) return;
            int n = 1;
            T inf = arr.Max() + (T)(object)1;
            int length = arr.Length;

            while (n < length) n *= 2;

            T[] temp = new T[n];
            Array.Copy(arr, temp, length);

            for (int i = length; i < n; i++)
            {
                temp[i] = inf;
            }

            MakeBitonic(temp, 0, n, comparer);
            BitSeqSort(temp, 0, n, false, comparer);

            Array.Copy(temp, arr, length);
        }

        static void Swap(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }
    }
}