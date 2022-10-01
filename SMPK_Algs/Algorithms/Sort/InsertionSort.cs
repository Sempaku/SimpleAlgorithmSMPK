namespace SMPK_Algs.Algorithms
{
    internal partial class Sort
    {
        public static int[] InsertionSort(int[] array) // O(N * N)
        {
            for (int left = 0; left < array.Length; left++)
            {
                int value = array[left];
                int i = left - 1;
                for (; i >= 0; i--)
                {
                    if (value < array[i])
                        array[i + 1] = array[i];
                    else
                        break;
                }
                array[i + 1] = value;
            }
            return array;
        }
    }
}