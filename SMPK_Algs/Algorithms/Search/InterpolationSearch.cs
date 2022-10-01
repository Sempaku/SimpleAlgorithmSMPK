namespace SMPK_Algs.Algorithms
{
    internal partial class Search
    {
        public static int InterpolationSearch(int[] array, int number) // O(log N)
        {
            Array.Sort(array);

            int indexA = 0;
            int indexB = array.Length - 1;

            while (number > array[indexA] && number < array[indexB])
            {
                if (indexA == indexB)
                    break;

                int Index = indexA + (((indexB - indexA) / (array[indexB] - array[indexA])) * (number - array[indexA]));

                if (array[Index] == number)
                    return Index;

                if (array[Index] < number)
                    indexA = Index + 1;
                else
                    indexB = Index - 1;
            }
            if (array[indexA] == number)
                return indexA;
            if (array[indexB] == number)
                return indexB;

            return -1;
        }
    }
}