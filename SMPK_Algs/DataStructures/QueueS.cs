namespace SMPK_Algs.DataStructures
{
    public class QueueS
    {
        private int head;
        private int tail;
        private long[] member;
        private int maxSize;
        private int count;

        public QueueS(int maxSize)
        {
            this.maxSize = maxSize;
            head = 0;
            tail = -1;
            count = 0;
            member = new long[this.maxSize];
        }

        public void Insert(long element)
        {
            if (isFull())
                throw new Exception("Queue is full!");
            if (tail == maxSize - 1)
                tail = -1;

            member[++tail] = element;
            count++;
        }

        public long Peek()
        {
            if (isEmpty())
                throw new Exception("Queue is empty");
            else
                return member[head];
        }

        public long Remove()
        {
            if (isEmpty())
                throw new Exception("Queue is empty");
            long temp = member[head++];
            if (head == maxSize)
                head = 0;
            count--;
            return temp;
        }

        public bool isEmpty() => count == 0;

        public bool isFull() => count == maxSize;

        public int Size() => count;
    }
}