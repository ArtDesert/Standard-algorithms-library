using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandardAlgorithmsLibrary.ExtensionClasses
{
    public static class ArrayExtensions
    {
        public static string ToStringExtensions(this int[] arr)
        {
            var builder = new StringBuilder();
            foreach (var item in arr)
            {
                builder.Append(string.Format("{0} ", item));
            }
            return builder.ToString();
        }
        public static int Median(this int[] arr)
        {
            return GetMedianOfArray(arr, 0, arr.Length - 1);
        }

        /// <summary>
        /// Возвращает медиану массива.
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        private static int GetMedianOfArray(int[] arr, int l, int r)
        {
            int n = r - l + 1;
            int index;
            if (n % 2 == 0) index = n / 2 - 1;
            else index = n / 2;
            return GetAscValueByIndex(arr, l, r, index, new Random());
        }

        /// <summary>
        /// Возвращает k-ый элемент в отсортированном по возрастанию массиве.
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <param name="k"></param>
        /// <param name="random"></param>
        /// <returns></returns>
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
