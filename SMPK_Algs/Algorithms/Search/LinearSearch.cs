namespace SMPK_Algs.Algorithms
{
    internal partial class Search
    {
        public static int LinearSearch(int[] array, int number) // O(N)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (number == array[i])
                    return i;
            }
            return -1;
        }
    }
}