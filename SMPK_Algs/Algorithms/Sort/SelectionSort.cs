namespace SMPK_Algs.Algorithms
{
    internal partial class Sort
    {
        public static int[] SelectionSort(int[] array) // O(N * N)
        {
            for (int left = 0; left < array.Length; left++)
            {
                int minIndex = left;
                for (int i = left; i < array.Length; i++)
                    if (array[i] < array[minIndex])
                        minIndex = i;

                int tmp = array[left];
                array[left] = array[minIndex];
                array[minIndex] = tmp;
            }
            return array;
        }
    }
}