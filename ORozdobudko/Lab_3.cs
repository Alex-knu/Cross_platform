namespace ORozdobudko
{
    public class Lab_3
    {
        public int Cycle { get; set; }

        bool CheckCyslic(int number, int cycle, List<int>[] graph, int[] color)
        {
            color[number] = 1;

            for (int i = 0; i < graph[number].Count; ++i)
            {
                int element = graph[number][i];
                if (color[element] == 0)
                {
                    if (CheckCyslic(element, cycle, graph, color))
                    {
                        return true;
                    }
                }
                else if (color[element] == 1)
                {
                    Cycle = element;
                    return true;
                }
            }

            color[number] = 2;

            return false;
        }

        int[,]? ReadMatrixData(string data)
        {
            try
            {
                int i = 0;
                string[] lines = data.Split('\n');

                int[,] matrix = new int[lines.Length, 2];

                foreach (var row in lines)
                {
                    int j = 0;
                    foreach (var col in row.Trim().Split(' '))
                    {
                        matrix[i, j] = int.Parse(col.Trim());
                        j++;
                    }
                    i++;
                }

                return matrix;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }

            return null;
        }

        public void Algoritm(int n, List<int>[] graph, int[] color)
        {
            for (int i = 0; i < n; i++)
            {
                if (CheckCyslic(i, Cycle, graph, color))
                {
                    break;
                }
            }
        }

        public void Algoritm(string data)
        {
            int i = 0;
            int[,]? matrix = ReadMatrixData(data);

            if (matrix != null)
            {
                int nodes = matrix[0, 0];
                int pairs = matrix[0, 1];
                int[] color = new int[nodes];
                List<int>[] graph = new List<int>[nodes];

                for (i = 0; i < nodes; i++)
                {
                    graph[i] = new List<int>();
                }

                for (i = 1; i <= pairs; i++)
                {
                    graph[matrix[i, 0] - 1].Add(matrix[i, 1] - 1);
                }

                Algoritm(nodes, graph, color);
            }
            else
            {
                Cycle = -1;
            }
        }
    }
}