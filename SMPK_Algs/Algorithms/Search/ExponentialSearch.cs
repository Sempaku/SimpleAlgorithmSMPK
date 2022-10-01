namespace SMPK_Algs.Algorithms
{
    internal partial class Search
    {
        public static int ExponentialSearch(int[] array, int number) // O(log N)
        {
            if (array[0] == number)
                return 0;
            if (array[array.Length - 1] == number)
                return array.Length - 1;

            int range = 1;

            while (range < array.Length && array[range] <= number)
                range *= 2;

            return Array.BinarySearch(array, range / 2, Math.Min(range, array.Length - 1), number);
        }
    }
}