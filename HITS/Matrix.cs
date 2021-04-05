using System;

namespace HITS
{
    public class Matrix
    {
        public int sizeX { get => data.GetLength(1);} //столбцы
        public int sizeY { get => data.GetLength(0);} //строки

        public double[,] data { get; set; }

        /*private Matrix(){}*/

        public Matrix(int size_y, int size_x)
        {
            data = new double[size_y, size_x];
        }
        public Matrix(int n)
        {
            data = new double[n, n];
        }
        public Matrix(double[,] _data)
        {
            data = _data;
        }

        public Matrix T()
        {
            var ret = new Matrix(sizeY, sizeX);
            for (int i = 0; i < ret.sizeX; i++)
            {
                for (int j = 0; j < ret.sizeY; j++)
                {
                    ret.data[i, j] = data[j, i];
                }
            }

            return ret;
        }
        public static Matrix operator *(Matrix a, Matrix b)
        {
            if (a.sizeX != b.sizeY)
                throw new Exception("Wrong dimensions sizes");
            var ret = new Matrix(a.sizeY,b.sizeX);
            for (int i = 0; i < ret.sizeY; i++)
            {
                for (int j = 0; j < ret.sizeX; j++)
                {
                    ret.data[i, j] = 0;
                    for (int k = 0; k < a.sizeX; k++)
                    {
                        ret.data[i, j] += a.data[i, k] * b.data[k, j];
                    }
                }
            }

            return ret;
        }

        public static Matrix operator +(Matrix a, Matrix b)
        {
            if (a.sizeX != b.sizeX || a.sizeY != b.sizeY)
                throw new Exception("Wrong dimensions sizes");
            var ret = new Matrix(a.sizeY, b.sizeX);
            for (int i = 0; i < ret.sizeY; i++)
            {
                for (int j = 0; j < ret.sizeX; j++)
                {
                    ret.data[i, j] = a.data[i,j] + b.data[i,j];
                }
            }

            return ret;
        }
        public static Matrix operator -(Matrix a, Matrix b)
        {
            if (a.sizeX != b.sizeX || a.sizeY != b.sizeY)
                throw new Exception("Wrong dimensions sizes");
            var ret = new Matrix(a.sizeX, b.sizeY);
            for (int i = 0; i < ret.sizeY; i++)
            {
                for (int j = 0; j < ret.sizeX; j++)
                {
                    ret.data[i, j] = a.data[i,j] - b.data[i,j];
                }
            }

            return ret;
        }
        
        public static Matrix operator *(double a, Matrix b)
        {
            var ret = new Matrix(b.sizeY, b.sizeX);
            for (int i = 0; i < ret.sizeX; i++)
            {
                for (int j = 0; j < ret.sizeY; j++)
                {
                    ret.data[j, i] = b.data[j,i]*a;
                }
            }

            return ret;
        }
        public static Matrix operator *(Matrix a, double b)
        {
            var ret = new Matrix(a.sizeY, a.sizeX);
            for (int i = 0; i < ret.sizeY; i++)
            {
                for (int j = 0; j < ret.sizeX; j++)
                {
                    ret.data[i, j] = a.data[i,j]*b;
                }
            }

            return ret;
        }
        
        public override string ToString()
        {
            var return_string = "";
            for (int i = 0; i < data.GetLength(0); i++)
            {
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    return_string += $"{data[i,j]}   ";
                }
                return_string += "\r\n";
            }

            return return_string;
        }
    }
}