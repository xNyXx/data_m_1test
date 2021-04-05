using System;

namespace HITS
{
    public class excersize_4
    {
        public static void Run(int n)
        {
            Matrix M = new Matrix(new double[,]
                {{0.33,0.33,0,0.25,0},{0.33,0,0,0.25,0},{0.33,0.33,1,0,0.5},{0,0,0,0.25,0},{0,0.33,0,0.25,0.5}});
            /*Matrix v = new Matrix(new double[,] {{1/}})*/
            
            var v = new Matrix(new double[,]{{0.2},{0.2},{0.2},{0.2},{0.2}});
            Matrix e = new Matrix(new double[,] {{1}, {1}, {1}, {1}, {1}});
            var beta = 0.85;
            Console.WriteLine($"---M----");
            Console.WriteLine(M.ToString());
            Console.WriteLine($"---v0----");
            Console.WriteLine(v.ToString());
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"---v{i+1}----");
                var v_ = beta * (M * v) + ((1 - beta) / 5) * e;
                v = v_;
                double sum = 0;
                for (int j = 0; j < v.sizeY; j++)
                {
                    sum += v.data[j, 0];
                }
                Console.WriteLine(v + $"\r\n" + sum);
            }
        }
    }
}