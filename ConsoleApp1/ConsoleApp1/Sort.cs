using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sort
{
    public class SortingAlgorithms
    {
        public static void BubbleSort(int[] array)
        {
            int temp;
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
        }

        public static void ShakerSort(int[] array)
        {
            bool swapped = true;
            int start = 0;
            int end = array.Length;

            while (swapped == true)
            {
                swapped = false;
                for (int i = start; i < end - 1; ++i)
                {
                    if (array[i] > array[i + 1])
                    {
                        int temp = array[i];
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
                    if (array[i] > array[i + 1])
                    {
                        int temp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = temp;
                        swapped = true;
                    }
                }
                start = start + 1;
            }
        }

        public static void CombSort(int[] array)
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
                    if (array[i] > array[i + gap])
                    {
                        int temp = array[i];
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

        public static void InsertionSort(int[] array)
        {
            int n = array.Length;
            for (int i = 1; i < n; ++i)
            {
                int key = array[i];
                int j = i - 1;
                while (j >= 0 && array[j] > key)
                {
                    array[j + 1] = array[j];
                    j = j - 1;
                }
                array[j + 1] = key;
            }
        }

        public static void ShellSort(int[] array)
        {
            int i, j, inc, temp;
            inc = 3;
            while (inc > 0)
            {
                for (i = 0; i < array.Length; i++)
                {
                    j = i;
                    temp = array[i];
                    while ((j >= inc) && (array[j - inc] > temp))
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

        class Node
        {
            public int Data;
            public Node Left;
            public Node Right;

            public Node(int data)
            {
                Data = data;
                Left = null;
                Right = null;
            }
        }

        class BinarySearchTree
        {
            public Node Root;

            public BinarySearchTree()
            {
                Root = null;
            }

            public void Insert(int data)
            {
                Root = InsertRec(Root, data);
            }

            private Node InsertRec(Node root, int data)
            {
                if (root == null)
                {
                    root = new Node(data);
                    return root;
                }

                if (data < root.Data)
                    root.Left = InsertRec(root.Left, data);
                else
                    root.Right = InsertRec(root.Right, data);

                return root;
            }

            public void InOrderTraversal(Node root, List<int> result)
            {
                if (root != null)
                {
                    InOrderTraversal(root.Left, result);
                    result.Add(root.Data);
                    InOrderTraversal(root.Right, result);
                }
            }
        }

        public static void TreeSort(int[] array)
        {
            BinarySearchTree bst = new BinarySearchTree();
            foreach (int value in array)
            {
                bst.Insert(value);
            }
            List<int> sortedList = new List<int>();
            bst.InOrderTraversal(bst.Root, sortedList);
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = sortedList[i];
            }
        }

        public static void GnomeSort(int[] array)
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
                else if (array[index] >= array[index - 1])
                {
                    index++;
                }
                else
                {
                    int temp = array[index];
                    array[index] = array[index - 1];
                    array[index - 1] = temp;
                    index--;
                }
            }
        }

        public static void SelectionSort(int[] array)
        {
            int n = array.Length;
            for (int i = 0; i < n - 1; i++)
            {
                int min_idx = i;
                for (int j = i + 1; j < n; j++)
                    if (array[j] < array[min_idx])
                        min_idx = j;
                int temp = array[min_idx];
                array[min_idx] = array[i];
                array[i] = temp;
            }
        }

        public static void HeapSort(int[] array)
        {
            int N = array.Length;
            for (int i = N / 2 - 1; i >= 0; i--)
                Heapify(array, N, i);
            for (int i = N - 1; i > 0; i--)
            {
                int temp = array[0];
                array[0] = array[i];
                array[i] = temp;
                Heapify(array, i, 0);
            }
        }

        static void Heapify(int[] array, int N, int i)
        {
            int largest = i;
            int l = 2 * i + 1;
            int r = 2 * i + 2;
            if (l < N && array[l] > array[largest])
                largest = l;
            if (r < N && array[r] > array[largest])
                largest = r;
            if (largest != i)
            {
                int swap = array[i];
                array[i] = array[largest];
                array[largest] = swap;
                Heapify(array, N, largest);
            }
        }

        public static void QuickSort(Tuple<int[], int, int> param)
        {
            int[] array = param.Item1;
            int left = param.Item2;
            int right = param.Item3;
            if (left < right)
            {
                int pivotIndex = Partition(array, left, right);
                QuickSort(Tuple.Create(array, left, pivotIndex - 1));
                QuickSort(Tuple.Create(array, pivotIndex + 1, right));
            }
        }

        static int Partition(int[] array, int left, int right)
        {
            int pivot = array[right];
            int i = left - 1;

            for (int j = left; j < right; j++)
            {
                if (array[j] <= pivot)
                {
                    i++;
                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }
            }

            int temp1 = array[i + 1];
            array[i + 1] = array[right];
            array[right] = temp1;

            return i + 1;
        }

        static void Merge(int[] array, int l, int m, int r)
        {
            int n1 = m - l + 1;
            int n2 = r - m;
            int[] L = new int[n1];
            int[] R = new int[n2];
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
                if (L[i] <= R[j])
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

        public static void MergeSort(Tuple<int[], int, int> param)
        {
            int[] array = param.Item1;
            int l = param.Item2;
            int r = param.Item3;
            if (l < r)
            {
                int m = l + (r - l) / 2;
                MergeSort(Tuple.Create(array, l, m));
                MergeSort(Tuple.Create(array, m + 1, r));
                Merge(array, l, m, r);
            }
        }

        public static void CountingSort(int[] array)
        {
            if (array.Length == 0) return;

            int FindMaxValue(int[] arr)
            {
                if (arr.Length == 0)
                {
                    throw new ArgumentException("Array is empty.");
                }

                int maxValue = arr[0];
                for (int i = 1; i < arr.Length; i++)
                {
                    if (arr[i] > maxValue)
                    {
                        maxValue = arr[i];
                    }
                }

                return maxValue;
            }

            int k;
            try
            {
                k = FindMaxValue(array);
            }
            catch (ArgumentException ex)
            {
                return;
            }

            var count = new int[k + 1];
            for (var i = 0; i < array.Length; i++)
            {
                count[array[i]]++;
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

        public static void BucketSort(Tuple<int[], int> param)
        {
            int[] array = param.Item1;
            int bucketCount = param.Item2;
            if (array.Length <= 1)
            {
                return;
            }

            var buckets = new List<int>[bucketCount];
            for (int i = 0; i < bucketCount; i++)
                buckets[i] = new List<int>();

            var min = double.MaxValue;
            var max = -double.MaxValue;

            for (int i = 0; i < array.Length; i++)
            {
                min = Math.Min(min, array[i]);
                max = Math.Max(max, array[i]);
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
                    idx = Math.Min(bucketCount - 1, (int)(bucketCount * (array[i] - min) / (max - min)));
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

        public static void RadiaxSort(int[] arr)
        {
            int i, j;
            int[] tmp = new int[arr.Length];
            for (int shift = 31; shift > -1; --shift)
            {
                j = 0;
                for (i = 0; i < arr.Length; ++i)
                {
                    bool move = (arr[i] << shift) >= 0;
                    if (shift == 0 ? !move : move)
                        arr[i - j] = arr[i];
                    else
                        tmp[j++] = arr[i];
                }
                Array.Copy(tmp, 0, arr, arr.Length - j, j);
            }
        }

        static void BitSeqSort(int[] arr, int left, int right, bool inv)
        {
            if (right - left <= 1) return;
            int mid = left + (right - left) / 2;

            for (int i = left, j = mid; i < mid && j < right; i++, j++)
            {
                if (inv ^ (arr[i] > arr[j]))
                {
                    Swap(ref arr[i], ref arr[j]);
                }
            }

            BitSeqSort(arr, left, mid, inv);
            BitSeqSort(arr, mid, right, inv);
        }

        static void MakeBitonic(int[] arr, int left, int right)
        {
            if (right - left <= 1) return;
            int mid = left + (right - left) / 2;

            MakeBitonic(arr, left, mid);
            BitSeqSort(arr, left, mid, false);
            MakeBitonic(arr, mid, right);
            BitSeqSort(arr, mid, right, true);
        }

        public static void BitonicSort(int[] arr)
        {
            if (arr.Length == 0) return;
            int n = 1;
            int inf = arr.Max() + 1;
            int length = arr.Length;

            while (n < length) n *= 2;

            int[] temp = new int[n];
            Array.Copy(arr, temp, length);

            for (int i = length; i < n; i++)
            {
                temp[i] = inf;
            }

            MakeBitonic(temp, 0, n);
            BitSeqSort(temp, 0, n, false);

            Array.Copy(temp, arr, length);
        }

        static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
    }
}