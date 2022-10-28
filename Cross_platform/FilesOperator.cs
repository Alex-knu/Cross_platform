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
            catch (FormatException)
            {
                Console.WriteLine("Exception: incorrect data in file");
            }

            return null;
        }
        
        public static int[,]?  ReadMatrixData(string path)
        {
            try
            {
                int i = 0;
                string[] lines = File.ReadAllLines(path);

                if (lines.Length == 0 || lines.Length == 1)
                {
                    return null;
                }

                int[,] result = new int[lines.Length, 2];
                
                foreach (var row in lines)
                {
                    int j = 0;
                    foreach (var col in row.Trim().Split(' '))
                    {
                        result[i, j] = int.Parse(col.Trim());
                        j++;
                    }
                    i++;
                }
                
                return result;
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
            catch (FormatException)
            {
                Console.WriteLine("Exception: incorrect data in file");
            }

            return null;
        }
        
        public static void WriteData(string? path, string data)
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
