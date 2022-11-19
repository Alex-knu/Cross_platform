using McMaster.Extensions.CommandLineUtils;

namespace Cross_platform
{
    class Program
    {
        public static int Main(string[] args)
        {
            int i;
            int? data;
            int[,]? dataMatrix;
            string inputPath;
            string outputPath;


            var app = new CommandLineApplication
            {
                Name = "PR 4",
                Description = "Console app for Lab4",
            };

            app.Command("version", verCmd =>
            {
                verCmd.OnExecute(() =>
                {
                    Console.WriteLine("Author: Rozdobudko Oleksandr IPZ-41");
                    Console.WriteLine("Version: 1.0.0");
                    return 1;
                });
            });

            app.HelpOption(inherited: true);

            app.Command("set-path", configCmd =>
            {
                var path = configCmd.Option("-p|--path", "input file path", CommandOptionType.SingleValue);
                configCmd.OnExecute(() =>
                {
                    if (!path.HasValue())
                    {
                        Console.WriteLine("Specify the path value");
                        configCmd.ShowHelp();
                    }
                    Environment.SetEnvironmentVariable("LAB_PATH", path.Value());
                });
            });

            app.Command("run", configCmd =>
            {
                configCmd.OnExecute(() =>
                {
                    Console.WriteLine("Specify a subcommand");
                    return 1;
                });

                configCmd.Command("lab1", setCmd =>
                {
                    setCmd.Description = "Set config value";
                    var input = setCmd.Option("-I|--input", "input file path", CommandOptionType.SingleValue);
                    var output = setCmd.Option("-o|--output", "output file path", CommandOptionType.SingleValue);

                    setCmd.OnExecute(() =>
                    {
                        data = Helper.ReadSimpleIntData(input.Value());
                        if (!data.HasValue)
                        {
                            return;
                        }

                        outputPath = Helper.PathCombiner(output.Value(), @"output.txt");

                        FilesOperator.WriteData(outputPath, ORozdobudko.Lab_1.Algoritm(data.Value).ToString());
                    });
                });

                configCmd.Command("lab2", setCmd =>
                {
                    setCmd.Description = "Set config value";
                    var input = setCmd.Option("-I|--input", "input file path", CommandOptionType.SingleValue);
                    var output = setCmd.Option("-o|--output", "output file path", CommandOptionType.SingleValue);

                    setCmd.OnExecute(() =>
                    {
                        data = Helper.ReadSimpleIntData(input.Value());
                        if (!data.HasValue)
                        {
                            return;
                        }

                        outputPath = Helper.PathCombiner(output.Value(), @"output.txt");

                        FilesOperator.WriteData(outputPath, ORozdobudko.Lab_2.Algoritm(data.Value).ToString());
                    });
                });

                configCmd.Command("lab3", setCmd =>
                {
                    setCmd.Description = "Set config value";
                    var input = setCmd.Option("-I|--input", "input file path", CommandOptionType.SingleValue);
                    var output = setCmd.Option("-o|--output", "output file path", CommandOptionType.SingleValue);

                    setCmd.OnExecute(() =>
                    {
                        inputPath = Helper.PathCombiner(input.Value(), @"input.txt");
                        outputPath = Helper.PathCombiner(output.Value(), @"output.txt");

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

        }
    }
}