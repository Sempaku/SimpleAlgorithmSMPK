namespace SMPK_Algs.Algorithms
{
    internal partial class Search
    {
        public static int BinarySearch(int[] array, int number) // O(log N)
        {
            Array.Sort(array);
            int left = 0;
            int right = array.Length - 1;
            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (array[mid] == number)
                    return mid;
                else
                {
                    if (number > array[mid])
                        left = mid;
                    else
                        right = mid;
                }
            }
            return -1;
        }
    }
}