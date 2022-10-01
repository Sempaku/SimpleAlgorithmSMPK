namespace SMPK_Algs.DataStructures
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
                for (int aa = 0; aa <= MAX_SIZE; aa++)
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

        private class Vertex
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
            for (int j = 0; j < sizeCurrent; j++)
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
                for (int j = 0; j < sizeCurrent; j++)
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