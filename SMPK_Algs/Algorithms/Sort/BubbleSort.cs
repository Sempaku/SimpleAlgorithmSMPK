namespace SMPK_Algs.Algorithms
{
    internal partial class Sort
    {
        public static int[] BubbleSort(int[] array) // O(N * N)
        {
            for (int o = array.Length - 1; o >= 1; o--)
            {
                for (int i = 0; i < o; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        int tmp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = tmp;
                    }
                }
            }
            return array;
        }
    }
}