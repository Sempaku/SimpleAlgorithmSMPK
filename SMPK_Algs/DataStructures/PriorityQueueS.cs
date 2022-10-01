namespace SMPK_Algs.DataStructures
{
    public class PriorityQueueS
    {
        protected int maxSize;
        private long[] values;
        private int count;

        public PriorityQueueS(int maxSize)
        {
            this.maxSize = maxSize;
            values = new long[this.maxSize];
            count = 0;
        }

        public void Insert(long element)
        {
            if (isFull())
                throw new Exception("Queue is full");
            int j;
            if (isEmpty())
                values[count++] = element;
            else
            {
                for (j = count - 1; j >= 0; j--)
                    if (element > values[j])
                        values[j + 1] = values[j];
                    else
                        break;

                values[j + 1] = element;
                count++;
            }
        }

        public long Peek()
        {
            if (isEmpty())
                throw new Exception("Priority queue is empty");
            else
                return values[count - 1];
        }

        public long Remove()
        {
            if (isEmpty())
                throw new Exception("Priority queue is empty");
            else
                return values[--count];
        }

        public bool isEmpty() => count == 0;

        public bool isFull() => count == maxSize;

        public int Size() => count;
    }
}