namespace SMPK_Algs.Algorithms
{
    internal partial class Sort
    {
        public static int[] ShellSort(int[] array) // O(N * log N) ... O(N * N)
        {
            int gap = array.Length / 2;
            while (gap >= 1)
            {
                for (int right = 0; right < array.Length; right++)
                {
                    for (int c = right - gap; c >= 0; c -= gap)
                    {
                        if (array[c] > array[c + gap])
                        {
                            int tmp = array[c];
                            array[c] = array[c + gap];
                            array[c + gap] = tmp;
                        }
                    }
                }
                gap = gap / 2;
            }
            return array;
        }
    }
}