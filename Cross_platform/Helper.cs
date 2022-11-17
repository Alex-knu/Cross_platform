namespace Cross_platform
{
    public static class Helper
    {
        public static int? ReadSimpleIntData(string? inputPath, string? outputPath)
        {
            if (inputPath == null || outputPath == null || inputPath == String.Empty || outputPath == String.Empty)
            {
                Console.WriteLine("Exception: empty path to input/output file");
                return null;
            }
            
            int? data = FilesOperator.ReadData(inputPath);

            if (!data.HasValue)
            {
                return null;
            }

            if (data <= 0)
            {
                Console.WriteLine("Number must be more than zero");
                return null;
            }

            return data;
        }
    }
}