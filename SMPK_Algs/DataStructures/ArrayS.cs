using System.Text;

namespace SMPK_Algs.DataStructures
{
    public class ArrayS
    {
        protected long[] memory;
        protected int countElements;

        public ArrayS(int maxSize)
        {
            memory = new long[maxSize];
            countElements = 0;
        }

        public int GetSize() => memory.Length;

        public int GetActualSize() => countElements;

        public int GetIndex(long searchKey)
        {
            for (int i = 0; i < memory.Length; i++)
                if (searchKey == memory[i])
                    return i;
            return -1;
        }

        public bool Insert(long value)
        {
            if (countElements != memory.Length)
            {
                memory[countElements] = value;
                countElements++;
                return true;
            }
            return false;
        }

        public bool Delete(long value)
        {
            int index = GetIndex(value);
            if (index == -1)
                return false;

            for (int i = index; i < memory.Length - 1; i++)
                memory[i] = memory[i + 1];

            countElements--;
            return true;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < countElements; i++)
                sb.Append(memory[i] + " ");

            return sb.ToString().Trim();
        }
    }
}