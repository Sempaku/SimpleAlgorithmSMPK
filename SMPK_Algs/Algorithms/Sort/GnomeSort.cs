namespace SMPK_Algs.Algorithms
{
    internal partial class Sort
    {
        public static int[] GnomeSort(int[] array) // O(N * N)
        {
            int i = 1, j = 2;
            while (i < array.Length)
            {
                if (array[i - 1] < array[i])
                {
                    i = j;
                    j++;
                }
                else
                {
                    int tmp = array[i];
                    array[i] = array[i - 1];
                    array[i - 1] = tmp;
                    i--;
                    if (i == 0)
                    {
                        i = j;
                        j++;
                    }
                }
            }
            return array;
        }
    }
}