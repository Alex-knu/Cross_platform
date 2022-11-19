namespace Cross_platform
{
    public static class Helper
    {
        public static int? ReadSimpleIntData(string? inputPath)
        {
            inputPath = PathCombiner(inputPath, @"input.txt");


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

        public static string PathCombiner(string? path, string fileName)
        {
            if (path == null || path == String.Empty)
            {
                return Path.GetFullPath(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), fileName));
            }
            else if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("LAB_PATH")))
            {
                return Path.Combine(Environment.GetEnvironmentVariable("LAB_PATH"), fileName);
            }
            else
            {
                return Path.GetFullPath(Path.Combine(path, fileName));
            }
        }
    }
}