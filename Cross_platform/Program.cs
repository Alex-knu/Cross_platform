namespace Cross_platform
{

    class Program
    {
        static int Algoritm(int items)
        {
            return items * (items + 2) * (2 * items + 1) / 8;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(Algoritm(4));
        }
    }
}