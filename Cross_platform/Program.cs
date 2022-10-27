using System.Numerics;
using ORozdobudko;

namespace Cross_platform
{
    class Program
    {
        static void Main(string[] args)
        {
            int i;
            int? data;
            int[,]? dataMatrix;
            
            Console.WriteLine("Input path for input data file");
            string? inputPath = Console.ReadLine();
            Console.WriteLine("Input path for output data file");
            string? outputPath = Console.ReadLine();
            Console.WriteLine("Input task number");
            string? task = Console.ReadLine();
            
            if (inputPath == null || outputPath == null || inputPath == String.Empty || outputPath == String.Empty)
            {
                Console.WriteLine("Exception: empty path to input/output file");
                return;
            }

            if (Int32.TryParse(task, out int result))
            {
                if (result == 1 || result == 2)
                {
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

                    if (result == 1)
                    {
                        FilesOperator.WriteData(outputPath, ORozdobudko.Lab_1.Algoritm(data.Value).ToString());
                    }
                    else
                    {
                        FilesOperator.WriteData(outputPath, ORozdobudko.Lab_2.Algoritm(data.Value).ToString());
                    }
                }
                else if (result == 3)
                {
                    dataMatrix = FilesOperator.ReadMatrixData(inputPath);
                    int nodes = dataMatrix[0, 0];
                    int pairs = dataMatrix[0, 1];
                    int[] color = new int[nodes];
                    List<int>[] graph = new List<int>[nodes];
            
                    for (i = 0; i < nodes; i++)
                    {
                        graph[i] = new List<int>();
                    }
            
                    for (i = 1; i <= pairs; i++)
                    {
                        graph[dataMatrix[i, 0] - 1].Add(dataMatrix[i, 1] - 1);
                    }

                    ORozdobudko.Lab_3 lab = new ORozdobudko.Lab_3();
            
                    lab.Algoritm(nodes, graph, color);
                    
                    FilesOperator.WriteData(outputPath, lab.Cycle == 0 ? "YES" : "NO");
                }
                else
                {
                    Console.WriteLine("Exception: wrong task number");
                }
            }
            else
            {
                Console.WriteLine("Exception: wrong task number");
            }
        }
    }
}