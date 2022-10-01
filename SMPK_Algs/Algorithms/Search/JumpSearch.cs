namespace SMPK_Algs.Algorithms
{
    internal partial class Search
    {
        public static int JumpSearch(int[] array, int number) // O(√n)
        {
            Array.Sort(array);

            int jumpStep = Convert.ToInt32(Math.Sqrt(array.Length));
            int prevStep = 0;

            while (array[Math.Min(jumpStep, array.Length) - 1] < number)
            {
                prevStep = jumpStep;
                jumpStep += Convert.ToInt32(Math.Sqrt(array.Length));
                if (prevStep >= array.Length)
                    return -1;
            }

            while (array[prevStep] < number)
            {
                prevStep++;
                if (prevStep == Math.Min(jumpStep, array.Length))
                    return -1;
            }

            if (array[prevStep] == number)
                return prevStep;

            return -1;
        }
    }
}