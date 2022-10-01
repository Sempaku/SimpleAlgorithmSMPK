namespace SMPK_Algs.Algorithms
{
    internal partial class Sort
    {
        #region MergeSort

        public static int[] MergeSort(int[] array) // O (N * log N)
        {
            if (array.Length == 1)
                return array;

            int[] a = new int[array.Length / 2];
            int[] b = new int[array.Length / 2];
            Array.Copy(array, 0, a, 0, array.Length / 2);
            Array.Copy(array, array.Length / 2, b, 0, array.Length / 2);

            return merge(MergeSort(a), MergeSort(b));
        }

        public static int[] merge(int[] array_A, int[] array_B)
        {
            int[] result = new int[array_A.Length + array_B.Length];
            int index1 = 0, index2 = 0, indexResult = 0;

            while (index1 < array_A.Length && index2 < array_B.Length)
            {
                if (array_A[index1] < array_B[index2])
                {
                    result[indexResult] = array_A[index1];
                    index1++;
                }
                else
                {
                    result[indexResult] = array_B[index2];
                    index2++;
                }
                indexResult++;
            }
            if (index1 < array_A.Length)
                Array.Copy(array_A, index1, result, indexResult, (array_A.Length - index1));
            if (index2 < array_B.Length)
                Array.Copy(array_B, index2, result, indexResult, (array_B.Length - index2));
            return result;
        }

        #endregion MergeSort
    }
}