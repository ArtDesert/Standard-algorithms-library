using System;

namespace StandardAlgorithmsLibrary
{
    internal class RandomGenerator
    {
        public static int[] GenerateRandomPermutation(int n)
        {
            int[] arr = new int[n];
            for (int i = 0; i < n; ++i)
            {
                arr[i] = i + 1;
            }
            var random = new Random();
            for (int i = arr.Length - 1; i >= 1; i--)
            {
                int j = random.Next(i + 1);
                (arr[i], arr[j]) = (arr[j], arr[i]);
            }
            return arr;
        }
    }
}
