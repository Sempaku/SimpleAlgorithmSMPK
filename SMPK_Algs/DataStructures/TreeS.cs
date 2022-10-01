namespace SMPK_Algs.DataStructures
{
    public class Node
    {
        public int value;
        public Node leftChild;
        public Node rightChild;

        public Node(int value)
        {
            this.value = value;
        }

        public Node(int value, Node leftChild, Node rightChild)
        {
            this.value = value;
            this.leftChild = leftChild;
            this.rightChild = rightChild;
        }
    }

    public class BinaryTreeS
    {
        private Node rootNode;

        public BinaryTreeS()
        {
            rootNode = null;
        }

        public Node FindNode(int value)
        {
            Node currentNode = rootNode;
            while (currentNode.value != value)
            {
                if (value < currentNode.value)
                    currentNode = currentNode.leftChild;
                else
                    currentNode = currentNode.rightChild;

                if (currentNode is null)
                    return null;
            }

            return currentNode;
        }

        public void InsertNode(int value)
        {
            Node newNode = new Node(value);
            if (rootNode is null) rootNode = newNode;
            else
            {
                Node currentNode = rootNode;
                Node parentNode;
                while (true)
                {
                    parentNode = currentNode;
                    if (value == currentNode.value)
                        return;
                    else if (value < currentNode.value)
                    {
                        currentNode = currentNode.leftChild;
                        if (currentNode is null)
                        {
                            parentNode.leftChild = newNode;
                            return;
                        }
                    }
                    else
                    {
                        currentNode = currentNode.rightChild;
                        if (currentNode is null)
                        {
                            parentNode.rightChild = newNode;
                            return;
                        }
                    }
                }
            }
        }

        public bool DeleteNode(int value)
        {
            Node currentNode = rootNode;
            Node parentNode = rootNode;
            bool isLeftChild = true;
            while (currentNode.value != value)
            {
                parentNode = currentNode;
                if (value < currentNode.value)
                {
                    isLeftChild = true;
                    currentNode = currentNode.leftChild;
                }
                else
                {
                    isLeftChild = false;
                    currentNode = currentNode.rightChild;
                }
                if (currentNode is null)
                    return false;
            }

            if (currentNode.leftChild == null && currentNode.rightChild == null)
            {
                if (currentNode == rootNode)
                    rootNode = null;
                else if (isLeftChild)
                    parentNode.leftChild = null;
                else
                    parentNode.rightChild = null;
            }
            else if (currentNode.rightChild == null)
            {
                if (currentNode == rootNode)
                    rootNode = currentNode.leftChild;
                else if (isLeftChild)
                    parentNode.leftChild = currentNode.leftChild;
                else
                    parentNode.rightChild = currentNode.leftChild;
            }
            else
            {
                Node heir = receiveHeir(currentNode);
                if (currentNode == rootNode)
                    rootNode = heir;
                else if (isLeftChild)
                    parentNode.leftChild = heir;
                else
                    parentNode.rightChild = heir;
            }
            return true;
        }

        private Node receiveHeir(Node node)
        {
            Node parentNode = node;
            Node heirNode = node;
            Node currentNode = node.rightChild;
            while (currentNode != null)
            {
                parentNode = heirNode;
                heirNode = currentNode;
                currentNode = currentNode.leftChild;
            }

            if (heirNode != node.rightChild)
            {
                parentNode.leftChild = heirNode.rightChild;
                heirNode.rightChild = node.rightChild;
            }
            return heirNode;
        }
    }
}