namespace ORozdobudko
{
    public static class Lab_2
    {
        public static Int64 Algoritm(int items)
        {
            Int64 x, y, z;
            Int64[,] matrix = new Int64[3, 10];

            matrix[0, 9] = 2;

            while (items > 10)
            {
                items = items - 1;
                x = (matrix[0, 0] + matrix[1, 0] + matrix[2, 0]) % 1000000;
                y = matrix[0, 9];
                z = matrix[1, 9];

                for (int j = 0; j < 9; j++)
                {
                    for (int k = 0; k <= 2; k++)
                    {
                        matrix[k, j] = matrix[k, j + 1];
                    }
                }

                matrix[0, 9] = x;
                matrix[1, 9] = y;
                matrix[2, 9] = z;
            }

            return (matrix[0, items - 1] + matrix[1, items - 1] + matrix[2, items - 1]) % 1000000;
        }
    }
}