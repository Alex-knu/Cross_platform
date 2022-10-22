using Cross_platform.Labs;
using ORozdobudko;

namespace Cross_platform
{
    class Program
    {
        static void Main(string[] args)
        {
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
        }
    }
}