using System.Numerics;
using McMaster.Extensions.CommandLineUtils;
using ORozdobudko;

namespace Cross_platform
{
    class Program
    {
        public static int Main(string[] args)
        {
            int i;
            int? data;
            int[,]? dataMatrix;
            
            var app = new CommandLineApplication
            {
                Name = "PR 4",
                Description = "A fake version of the node package manager",
            };

            app.HelpOption(inherited: true);
            
            app.Command("labs", configCmd =>
            {
                configCmd.OnExecute(() =>
                {
                    Console.WriteLine("Specify a subcommand");
                    return 1;
                });
                
                configCmd.Command("lab1", setCmd =>
                {
                    setCmd.Description = "Set config value";
                    var input = setCmd.Option("--input", "input file path", CommandOptionType.SingleValue);
                    var output = setCmd.Option("--output", "output file path", CommandOptionType.SingleValue);
                    
                    setCmd.OnExecute(() =>
                    {
                        int? n = Helper.ReadSimpleIntData(input.Value(), output.Value());
                        if (!n.HasValue)
                        {
                            return;
                        }

                        FilesOperator.WriteData(output.Value(), ORozdobudko.Lab_1.Algoritm(n.Value).ToString());
                    });
                });
                
                configCmd.Command("lab2", setCmd =>
                {
                    setCmd.Description = "Set config value";
                    var input = setCmd.Option("--input", "input file path", CommandOptionType.SingleValue);
                    var output = setCmd.Option("--output", "output file path", CommandOptionType.SingleValue);
                    
                    setCmd.OnExecute(() =>
                    {
                        int? n = Helper.ReadSimpleIntData(input.Value(), output.Value());
                        if (!n.HasValue)
                        {
                            return;
                        }

                        FilesOperator.WriteData(output.Value(), ORozdobudko.Lab_2.Algoritm(n.Value).ToString());
                    });
                });
                
                configCmd.Command("lab3", setCmd =>
                {
                    setCmd.Description = "Set config value";
                    var input = setCmd.Option("--input", "input file path", CommandOptionType.SingleValue);
                    var output = setCmd.Option("--output", "output file path", CommandOptionType.SingleValue);
                    
                    setCmd.OnExecute(() =>
                    {
                        if (input.Value() == String.Empty || output.Value()  == String.Empty)
                        {
                            Console.WriteLine("Exception: empty path to input/output file");
                            return;
                        }
                        
                        dataMatrix = FilesOperator.ReadMatrixData(input.Value());
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
                    
                        FilesOperator.WriteData(output.Value(), lab.Cycle == 0 ? "YES" : "NO");
                    });
                });
            });
            
            app.OnExecute(() =>
            {
                Console.WriteLine("Specify a subcommand");
                app.ShowHelp();
                return 1;
            });

            return app.Execute(args);
            /*
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
            */
        }
    }
}