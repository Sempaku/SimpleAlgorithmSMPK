namespace SMPK_Algs.DataStructures
{
    public class HeapS
    {
        private Node[] heapArray;
        private int MAX_SIZE;
        private int SIZE;

        public HeapS(int maxSize)
        {
            this.MAX_SIZE = maxSize;
            this.SIZE = 0;

            heapArray = new Node[this.MAX_SIZE];
        }

        public bool Insert(int value)
        {
            if (SIZE == MAX_SIZE)
                return false;

            Node newNode = new Node(value);
            heapArray[SIZE] = newNode;
            TrickleUp(SIZE++);
            return true;
        }

        public Node Remove()
        {
            Node root = heapArray[0];
            heapArray[0] = heapArray[--SIZE];
            TrickleDown(0);
            return root;
        }

        private void TrickleUp(int index)
        {
            int parent = (index - 1) / 2;
            Node bottom = heapArray[index];
            while (index > 0 && heapArray[parent].value < bottom.value)
            {
                heapArray[index] = heapArray[parent];
                index = parent;
                parent = (parent - 1) / 2;
            }
            heapArray[index] = bottom;
        }

        private void TrickleDown(int index)
        {
            int largeChild;
            Node top = heapArray[index];
            while (index < SIZE / 2)
            {
                int leftChild = 2 * index + 1;
                int rightChild = leftChild + 1;
                if (rightChild < SIZE && heapArray[leftChild].value < heapArray[rightChild].value)
                    largeChild = rightChild;
                else
                    largeChild = leftChild;

                if (top.value >= heapArray[largeChild].value)
                    break;

                heapArray[index] = heapArray[largeChild];
                index = largeChild;
            }
            heapArray[index] = top;
        }
    }
}