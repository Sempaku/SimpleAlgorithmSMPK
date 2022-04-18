using SMPK_ALGORITHMS.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMPK_ALGORITHMS
{
    namespace Algorithm
    {
        public static class Search
        {
            public static int LinearSearch(int[] array, int number) // O(N)
            {
                for(int i = 0; i < array.Length; i++)
                {
                    if (number == array[i])
                        return i;
                }
                return -1;
            }

            public static int BinarySearch(int[] array, int number) // O(log N)
            {
                Array.Sort(array);
                int left = 0;
                int right = array.Length-1;
                while (left <= right)
                {
                    int mid = (left + right) / 2;
                    if (array[mid] == number)                     
                        return mid;
                    else 
                    {
                        if (number > array[mid])
                            left = mid;
                        else
                            right = mid;
                    }                    
                }
                return -1;
            }

            public static int JumpSearch(int[] array, int number) // O(√n) 
            {
                Array.Sort(array);

                int jumpStep = Convert.ToInt32(Math.Sqrt(array.Length));
                int prevStep = 0;

                while (array[Math.Min(jumpStep,array.Length) - 1] < number)
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

            public static int InterpolationSearch(int[] array, int number) // O(log N)
            {
                Array.Sort(array);

                int indexA = 0;
                int indexB = array.Length - 1;

                while(number > array[indexA] && number < array[indexB])
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

            public static int ExpSearch(int[] array, int number) // O(log N)
            {
                if (array[0] == number)
                    return 0;
                if (array[array.Length - 1] == number)
                    return array.Length - 1;

                int range = 1;

                while (range < array.Length && array[range] <= number)
                    range *= 2;

                return Array.BinarySearch(array, range / 2, Math.Min(range, array.Length - 1), number);
                
            }
        }

        public static class Sort
        {
            public static int[] BubbleSort(int[] array) // O(N * N)
            {
                for(int o = array.Length - 1; o >= 1; o--)
                {
                    for(int i = 0; i < o; i++)
                    {
                        if (array[i] > array[i + 1])
                        {
                            int tmp = array[i];
                            array[i] = array[i + 1];
                            array[i + 1] = tmp;
                        }
                    }
                }
                return array;
            }

            public static int[] SelectionSort(int[] array) // O(N * N)
            {
                for (int left = 0; left < array.Length; left++)
                {
                    int minIndex = left;
                    for(int i = left; i < array.Length; i++)
                        if (array[i] < array[minIndex])
                            minIndex = i;

                    int tmp = array[left];
                    array[left] = array[minIndex];
                    array[minIndex] = tmp;
                }
                return array;
            }

            public static int[] InsertionSort(int[] array) // O(N * N)
            {
                for(int left = 0; left< array.Length; left++)
                {
                    int value = array[left];
                    int i = left - 1;
                    for(; i >= 0; i--)
                    {
                        if (value < array[i])
                            array[i + 1] = array[i];                        
                        else
                            break;
                    }
                    array[i + 1] = value;
                }                
                return array;
            }

            #region MergeSort
            public static int[] MergeSort(int[] array) // O (N * log N)
            {
                if (array.Length == 1)
                    return array;

                int[] a = new int[array.Length/2];
                int[] b = new int[array.Length/2];
                Array.Copy(array, 0, a,0, array.Length / 2);
                Array.Copy(array, array.Length/2, b, 0, array.Length / 2);

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
            #endregion

            public static int[] GnomeSort(int[] array) // O(N * N)
            {
                int i = 1, j = 2;
                while(i < array.Length)
                {
                    if (array[i-1] < array[i])
                    {
                        i = j;
                        j++;
                    }
                    else
                    {
                        int tmp = array[i];
                        array[i] = array[i - 1];
                        array[i - 1] = tmp;
                        i--;
                        if( i == 0)
                        {
                            i = j;
                            j++;
                        }
                    }
                }
                return array;
               
            }

            public static int[] ShellSort(int[] array) // O(N * log N) ... O(N * N) 
            {
                int gap = array.Length / 2;
                while(gap >= 1)
                {
                    for( int right = 0; right < array.Length; right++)
                    {
                        for (int c = right - gap; c >= 0; c -= gap)
                        {
                            if (array[c] > array[c + gap])
                            {
                                int tmp = array[c];
                                array[c] = array[c + gap];
                                array[c + gap] = tmp;
                            }
                        }
                    }
                    gap = gap / 2;
                }
                return array;
            }

            public static int[] CountSort(int[] array) // O(N + K)
            {
                int maxValue = -1;
                foreach(int number in array)
                    if(number > maxValue)
                        maxValue = number;

                int[] numCounts = new int[maxValue + 1];
                foreach (int num in array)
                    numCounts[num]++;

                int[] sortedArray = new int[array.Length];
                int currentSortedIndex = 0;

                for(int n = 0; n < numCounts.Length; n++)
                {
                    int count = numCounts[n];
                    for (int k = 0; k < count; k++)
                        sortedArray[currentSortedIndex++] = n;
                }
                return sortedArray;
            }
        }
    }

    namespace Structures
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
                
                for(int i = index; i < memory.Length-1; i++)
                    memory[i] = memory[i + 1];

                countElements--;
                return true;
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < countElements; i ++)
                    sb.Append(memory[i] + " ");

                return sb.ToString().Trim(); 
            }
        }

        public class LinkListS
        {
            private Link first;

            public LinkListS() => this.first = null;
            
            public bool isEmpty() => first == null;
            
            public void InsertFirst(Link link)
            {
                link.next = first;
                first = link;
            }

            public void InsertAfterKey(Link newLink, int key)
            {
                Link link = first;
                while (link != null)
                {
                    if (link.key == key)
                    {
                        newLink.next = link.next;
                        link.next = newLink;
                    }
                    else
                    {
                        link = link.next;
                    }
                }
                if (link == null)
                {
                    newLink.next = first;
                    first = newLink;
                }
            }

            public Link FindByKey(int key)
            {
                Link link = first;
                while(key != null)
                {
                    if (link.key == key)
                        return link;
                    else
                        link = link.next;
                }
                return null;
            }

            public Link DeleteFirst()
            {
                if (first != null)
                {
                    Link link = first;
                    first = first.next;
                    return link;
                }
                else
                    return null;
            }

            public Link DeleteByKey(int key)
            {
                Link prevLink = null;
                Link currentLink = first;
                while(currentLink != null)
                {
                    if (currentLink != null)
                        if (currentLink == first)
                            first = currentLink.next;
                        else
                            prevLink.next = currentLink.next;
                    else
                    {
                        prevLink = currentLink;
                        currentLink = currentLink.next;
                    }

                }
                return null;
            }

            public override string ToString()
            {
                string display = "";
                Link link = first;
                while(link != null)
                {
                    display += link.ToString() + " ";
                    link = link.next;
                }
                return display.Trim();
            }



            public class Link
            {
                public int key;
                public double value;
                public Link next;

                public Link(int key, double value)
                {
                    this.key = key;
                    this.value = value;
                    this.next = null;
                }

                public override string ToString()
                {
                    return $"{key}={value};";
                }
            }
        }

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
                else { 
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

    namespace Graph
    {
        public class GraphS
        {
            protected int MAX_SIZE = 10;
            private Vertex[] vertexList;
            private int?[][] matrix_adjacency;
            private int sizeCurrent;

            public GraphS()
            {
                vertexList = new Vertex[MAX_SIZE];
                matrix_adjacency = new int?[MAX_SIZE][];
                for (int a = 0; a < MAX_SIZE; a++)
                    for(int aa=0; aa <= MAX_SIZE; aa++)
                        matrix_adjacency[a] = new int?[aa];
                sizeCurrent = 0;
                for (int j = 0; j < MAX_SIZE; j++)
                    for (int k = 0; k < MAX_SIZE; k++)
                        matrix_adjacency[j][k] = 0;
            }

            public void AddVertex(string name) => vertexList[sizeCurrent++] = new Vertex(name);

            public void AddRib(int start, int end)
            {
                matrix_adjacency[start][end] = 1;
                matrix_adjacency[end][start] = 1;
            }


            class Vertex
            {
                public string name;
                public bool isVisited;

                public Vertex(string name)
                {
                    this.name = name;
                    isVisited = false;
                }
            }

            public override string ToString()
            {
                var s = "";
                //int i = 0;
                foreach (var vertex in vertexList)
                {
                    s += $"{vertex?.name} ; ";
                    
                }
                    
                    
                return s;
            }

            public void BFS()
            {
                QueueS queues = new QueueS(MAX_SIZE);
                vertexList[0].isVisited = true;
                queues.Insert(0);
                int vertex2;
                while (!queues.isEmpty())
                {
                    int vertex1 = (int)queues.Remove();
                    while ((vertex2 = GetAdjacency(vertex1)) != -1)
                    {
                        vertexList[vertex2].isVisited = true;
                        queues.Insert(vertex2);
                    }
                }
                for (int j = 0; j < sizeCurrent; j++)
                    vertexList[j].isVisited = false;

            }

            public int GetAdjacency(int vertex)
            {
                for(int j = 0; j < sizeCurrent; j++)
                    if (matrix_adjacency[vertex][j] == 1 && vertexList[j].isVisited == false)
                        return j;
                return -1;
            }

            public void DFS()
            {
                StackS stacks = new StackS(MAX_SIZE);
                vertexList[0].isVisited = true;
                stacks.Push(0);
                while (!stacks.isEmpty())
                {
                    int v = -1;
                    for(int j = 0; j < sizeCurrent; j ++)
                        if (matrix_adjacency[stacks.Peek()][j] == 1 && vertexList[j].isVisited == false)
                        {
                            v = j;
                            break;
                        }
                    
                    if (v == -1)
                        stacks.Pop();
                    else
                    {
                        vertexList[v].isVisited = true;
                        stacks.Push(v);
                    }
                }
                for (int j = 0; j < sizeCurrent; j++)
                    vertexList[j].isVisited = false;                
            }
        }



        
        
    }

    namespace Tree
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
                while(currentNode.value != value)
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
                while(currentNode.value != value)
                {
                    parentNode = currentNode;
                    if(value < currentNode.value)
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
                while( currentNode != null)
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
                while(index > 0 && heapArray[parent].value < bottom.value)
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
                while(index < SIZE / 2)
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


}
