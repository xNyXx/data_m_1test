using System;

namespace HITS
{
    public static class excersize_1
    {
        public static void Run(int n)
        {
            var matrix = new Matrix(new double[,] {{1, 1, 1}, {1, 0, 1}, {0, 1, 1}});
            
            Console.WriteLine("L : \r\n" + "\r\n"+matrix.ToString());
            
            Console.WriteLine("L_t : \r\n" + "\r\n"+matrix.T().ToString());

            /*var hits = new Hits(){L = matrix, lamda = 0.33, mu = 0.25, h = new Matrix({data = new double[,]{{1,1,1}}})};*/
            var hits = new Hits(matrix, new Matrix(new double[,] {{1}, {1}, {1}}), 0.33, 0.25);
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine((i+1) + "---iter--- \r\n");
                hits.Move();
            }
        }
    }
} 