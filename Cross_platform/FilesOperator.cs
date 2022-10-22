namespace Cross_platform
{
    public static class FilesOperator
    {
        public static int? ReadData(string path)
        {
            try
            {
                string[] lines = File.ReadAllLines(path);
                return Int32.Parse(lines[0]);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Exception: incorrect data in file");
            }

            return null;
        }

        public static void WriteData(string path, string data)
        {
            try
            {
                StreamWriter sw = new StreamWriter(path);
                sw.WriteLine(data);
                sw.Close();

                Console.WriteLine("See result on '{0}': ", path);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
        }
    }
}
