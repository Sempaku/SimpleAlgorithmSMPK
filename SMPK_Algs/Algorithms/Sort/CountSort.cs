namespace SMPK_Algs.Algorithms
{
    internal partial class Sort
    {
        public static int[] CountSort(int[] array) // O(N + K)
        {
            int maxValue = -1;
            foreach (int number in array)
                if (number > maxValue)
                    maxValue = number;

            int[] numCounts = new int[maxValue + 1];
            foreach (int num in array)
                numCounts[num]++;

            int[] sortedArray = new int[array.Length];
            int currentSortedIndex = 0;

            for (int n = 0; n < numCounts.Length; n++)
            {
                int count = numCounts[n];
                for (int k = 0; k < count; k++)
                    sortedArray[currentSortedIndex++] = n;
            }
            return sortedArray;
        }
    }
}