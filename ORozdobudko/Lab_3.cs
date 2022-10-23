using System.Numerics;

namespace ORozdobudko
{
    public class Lab_3
    {
        public static bool Result { get; set; }
        public int Cycle { get; set; }

        bool CheckCyslic(int number, int cycle, List<int>[] graph, int []color)
        {
            color[number] = 1;
            
            for (int i = 0; i < graph[number].Count; ++i)
            {
                int to = graph[number][i];
                if (color[to] == 0)
                {
                    if (CheckCyslic(to, cycle, graph, color))
                    {
                        return true;
                    }
                }
                else if (color[to] == 1)
                {
                    Cycle = to;
                    return true;
                }
            }

            color[number] = 2;
            
            return false;
        }

        public void Algoritm(int n, List<int>[] graph, int []color)
        {
            for (int i = 0; i < n; i++)
            {
                if (CheckCyslic(i, Cycle, graph, color))
                {
                    break;
                }
            }
        }
    }
}