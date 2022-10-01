namespace SMPK_Algs.DataStructures
{
    public class StackS
    {
        private int maxSize;
        private long[] stackArray;
        private int top;

        public StackS(int maxSize)
        {
            this.maxSize = maxSize;
            this.stackArray = new long[maxSize];
            top = -1;
        }

        public void Push(long element)
        {
            if (isFull())
                throw new Exception("Stack is full!");
            else
                stackArray[++top] = element;
        }

        public long Pop()
        {
            if (isEmpty())
                throw new Exception("Stack is empty!");
            else
                return stackArray[top--];
        }

        public long Peek()
        {
            if (isEmpty())
                throw new Exception("Stack is empty!");
            else
                return stackArray[top];
        }

        public bool isFull() => top == maxSize - 1;

        public bool isEmpty() => top < 0;
    }
}