using System;
using System.Reflection.Metadata.Ecma335;

namespace HITS
{
    public class Hits
    {
        public Matrix L { get; set; }
        public Matrix Lt { get => L.T(); }
        
        public Matrix h { get; set; }
        public Matrix a { get; set; }
        public double lamda { get; set; }
        public double mu { get; set; }

        public Hits(Matrix L, Matrix h, double lamda, double mu)
        {
            this.L = L;
            this.h = h;
            this.lamda = lamda;
            this.mu = mu;
        }

        public void Move()
        {
            Console.WriteLine("Lt*h \r\n" + (Lt * h).ToString() + "\r\n\r\n");
            a = mu * (Lt * h);
            Console.WriteLine("a \r\n" + a.ToString() + "\r\n\r\n");
            Console.WriteLine("La \r\n" + (L*a).ToString());
            h = lamda * (L * a);
            Console.WriteLine("h \r\n"+ h.ToString() + "\r\n\r\n");
            Console.WriteLine("\r\n\r\n");
        }
    }
}