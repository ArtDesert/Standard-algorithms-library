using StandardAlgorithmsLibrary.ExtensionClasses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StandardAlgorithmsLibrary
{
    public class Sorter
    {
        /// <summary>
        /// Сортировка пузырьком.
        /// worst: O(n²)
        /// average: O(n²)
        /// best: O(n)
        /// memory: O(1)
        /// </summary>
        /// <param name="arr"></param>
        public static void BubbleSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n - i - 1; ++j)
                {
                    if (arr[j] > arr[j + 1]) (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
                }
            }
        }

        /// <summary>
        /// Сортировка пузырьком с проверкой условия отсортированности.
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static int BubbleSortWithCondition(int[] arr)
        {
            int countOfIterations = 0;
            int n = arr.Length;
            for (int i = 0; i < n; ++i)
            {
                ++countOfIterations;
                bool hadSwaps = false;
                for (int j = 0; j < n - 1; ++j)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
                        hadSwaps = true;
                    }
                }
                if (!hadSwaps) break;
            }
            return countOfIterations;
        }

        /// <summary>
        /// Сортировка вставками.
        /// worst: O(n²)
        /// average: O(n²)
        /// best: O(n)
        /// memory: O(1)
        /// </summary>
        /// <param name="arr"></param>
        public static void InsertionSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < i; ++j)
                {
                    if (arr[i] < arr[j]) (arr[i], arr[j]) = (arr[j], arr[i]);
                }
            }
        }

        /// <summary>
        /// Сортировка выбором.
        /// worst: O(n²)
        /// average: O(n²)
        /// best: O(n²)
        /// memory: O(1)
        /// </summary>
        /// <param name="arr"></param>
        public static void SelectionSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n; ++i)
            {
                int min = i;
                for (int j = i + 1; j < n; ++j)
                {
                    if (arr[j] < arr[min]) min = j;
                }
                (arr[i], arr[min]) = (arr[min], arr[i]);
            }
        }

        /// <summary>
        /// Сортировка подсчётом.
        /// </summary>
        /// <param name="arr"></param>
        public static void CountingSort(int[] arr)
        {
            int max = arr.Max();
            int[] temp = new int[max + 1];
            foreach (var num in arr)
            {
                ++temp[num];
            }

            int k = 0;
            for (int i = 0; i < max + 1; ++i)
            {
                for (int j = 0; j < temp[i]; ++j)
                {
                    arr[k++] = i;
                }
            }
        }

        /// <summary>
        /// Сортировка слиянием.
        /// </summary>
        /// <param name="arr"></param>
        public static void MergeSort(int[] arr)
        {
            MergeSort(arr, 0, arr.Length - 1);
        }

        private static void MergeSort(int[] arr, int l, int r)
        {
            if (l < r)
            {
                var m = (l + r) / 2;
                MergeSort(arr, l, m);
                MergeSort(arr, m + 1, r);
                Merge(arr, l, m, r);
            }
        }

        private static void Merge(int[] arr, int l, int m, int r)
        {
            int la = m - l + 1, lb = r - m, n = la + lb;
            var temp = new int[n];
            int pa = l, pb = m + 1;
            for (int i = 0; i < n; ++i)
            {
                if (pa == m + 1)
                {
                    Array.Copy(arr, pb, temp, i, r - pb + 1);
                    break;
                }
                if (pb == r + 1)
                {
                    Array.Copy(arr, pa, temp, i, m - pa + 1);
                    break;
                }
                else
                {
                    if (arr[pa] < arr[pb])
                    {
                        temp[i] = arr[pa++];
                    }
                    else
                    {
                        temp[i] = arr[pb++];
                    }
                }
            }
            Array.Copy(temp, 0, arr, l, n);
        }

        /// <summary>
        /// Сортировка Шелла.
        /// </summary>
        /// <param name="arr"></param>
        public static void ShellSort(int[] arr)
        {

        }

        /// <summary>
        /// Сортировка кучей.
        /// </summary>
        /// <param name="arr"></param>
        public static void HeapSort(int[] arr)
        {

        }

        /// <summary>
        /// Сортировка деревом.
        /// </summary>
        /// <param name="arr"></param>
        public static void TreeSort(int[] arr)
        {

        }

        /// <summary>
        /// Быстрая сортировка с выбором случайного элемента в качестве опорного.
        /// </summary>
        /// <param name="arr"></param>
        public static void QuickSort(int[] arr)
        {
            var random = new Random();
            QuickSort(arr, 0, arr.Length - 1, random);
        }

        private static void QuickSort(int[] arr, int l, int r, Random random)
        {
            if (r <= l)
                return;
            int q = arr[random.Next(l, r + 1)];
            int i = l;
            int j = r;
            while (i <= j)
            {
                while (arr[i] < q)
                {
                    ++i;
                }
                while (arr[j] > q)
                {
                    --j;
                }
                if (i <= j)
                {
                    (arr[i], arr[j]) = (arr[j], arr[i]);
                    ++i;
                    --j;
                }
            }
            QuickSort(arr, l, j, random);
            QuickSort(arr, i, r, random);
        }

        /// <summary>
        /// Быстрая сортировка с выбором медианы в качестве опорного элемента.
        /// </summary>
        /// <param name="arr"></param>
        public static void QuickSortWithPartitionByMedian(int[] arr)
        {
            var random = new Random();
            QuickSortWithPartitionByMedian(arr, 0, arr.Length - 1, random);
        }

        private static void QuickSortWithPartitionByMedian(int[] arr, int l, int r, Random random)
        {
            if (r <= l)
                return;
            int q = GetMedianOfArray(arr, l, r);
            int i = l;
            int j = r;
            while (i <= j)
            {
                while (arr[i] < q)
                {
                    ++i;
                }
                while (arr[j] > q)
                {
                    --j;
                }
                if (i <= j)
                {
                    (arr[i], arr[j]) = (arr[j], arr[i]);
                    ++i;
                    --j;
                }
            }
            QuickSort(arr, l, j, random);
            QuickSort(arr, i, r, random);
        }

        private static int GetMedianOfArray(int[] arr, int l, int r)
        {
            int n = r - l + 1;
            int index;
            if (n % 2 == 0) index = n / 2 - 1;
            else index = n / 2;
            return GetAscValueByIndex(arr, l, r, index, new Random());
        }

        private static int GetAscValueByIndex(int[] arr, int l, int r, int k, Random random)
        {
            var (left, right) = Partition(arr, l, r, random);
            if (left <= k && k <= right) return arr[k];
            else if (k < left)
            {
                return GetAscValueByIndex(arr, l, left - 1, k, random);
            }
            else
            {
                return GetAscValueByIndex(arr, right + 1, r, k, random);
            }
        }

        /// <summary>
        /// Разделяет массив на три подмассива: меньший, равный и больший, относительно выбранного случайным образом опорного элемента.
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="l">Левая граница отрезка, на котором происходит разделение.</param>
        /// <param name="r">Правая граница отрезка, на котором происходит разделение.</param>
        /// <param name="random"></param>
        /// <returns>Пара индексов: Item1 - индекс правой границы меньшего подмассива, Item2 - индекс левой границы большего подмассива.</returns>
        private static (int, int) Partition(int[] arr, int l, int r, Random random)
        {
            int partitionIndex = random.Next(l, r + 1);
            int pivot = arr[partitionIndex];
            var leftList = new List<int>();
            var rightList = new List<int>();
            int i = l;
            int j = r;
            while (i <= j)
            {
                while (arr[i] <= pivot)
                {
                    if (arr[i] == pivot)
                    {
                        if (i != partitionIndex)
                        {
                            if (i < partitionIndex)
                                leftList.Add(i);
                            else rightList.Add(i);
                        }
                        if (i == partitionIndex || i == j)
                        {
                            break;
                        }
                    }
                    ++i;
                }
                if (i == j) break;
                while (arr[j] >= pivot)
                {
                    if (arr[j] == pivot)
                    {
                        if (j != partitionIndex)
                        {
                            if (j < partitionIndex)
                                leftList.Add(j);
                            else rightList.Add(j);
                        }
                        if (j == partitionIndex || i == j)
                        {
                            break;
                        }
                    }
                    --j;
                }
                if (i < j)
                {
                    if (i == partitionIndex) partitionIndex = j;
                    else if (j == partitionIndex) partitionIndex = i;
                    (arr[i], arr[j]) = (arr[j], arr[i]);
                }
            }
            int left = partitionIndex, right = partitionIndex;
            int leftCount = 0, rightCount = 0;
            foreach (var index in leftList.OrderByDescending(x => x))
            {
                if (arr[partitionIndex - leftCount - 1] != pivot)
                {
                    (arr[index], arr[partitionIndex - leftCount - 1]) = (arr[partitionIndex - leftCount - 1], arr[index]);
                }
                ++leftCount;
                --left;
            }
            foreach (var index in rightList.OrderBy(x => x))
            {
                if (arr[partitionIndex + rightCount + 1] != pivot)
                {
                    (arr[index], arr[partitionIndex + rightCount + 1]) = (arr[partitionIndex + rightCount + 1], arr[index]);
                }
                ++rightCount;
                ++right;
            }
            return (left, right);
        }
    }
}
