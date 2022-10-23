using System.Numerics;
using Cross_platform.Labs;
using ORozdobudko;

namespace Cross_platform
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            int? data;
            Console.WriteLine("Input path for input data file");
            string? inputPath = Console.ReadLine();
            Console.WriteLine("Input path for output data file");
            string? outputPath = Console.ReadLine();

            if (inputPath == null || outputPath == null)
            {
                Console.WriteLine("Exception: emty path to input/output file");
                return;
            }

            data = FilesOperator.ReadData(inputPath);

            if (!data.HasValue)
            {
                return;
            }

            if (data <= 0)
            {
                Console.WriteLine("Number must be more than zero");
                return;
            }

            FilesOperator.WriteData(outputPath, ORozdobudko.Lab_1.Algoritm(data.Value).ToString());
            */
            
            int[,] data = new int[4, 2]{{1, 3}, {1, 4}, {4, 3}, {5, 2}};
            int[] color = new int[5];
            List<int>[] graph = new List<int>[5];
            
            for (int i = 0; i < 5; i++)
            {
                graph[i] = new List<int>();
            }
            
            for (int i = 0; i < 4; i++)
            {
                graph[data[i, 0] - 1].Add(data[i, 1] - 1);
            }

            Lab_3 task = new Lab_3();
            
            task.Algoritm(5, graph, color);
            
            Console.WriteLine(task.Cycle);
        }
    }
}