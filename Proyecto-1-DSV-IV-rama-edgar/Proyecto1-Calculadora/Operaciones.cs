using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_1_Calculadora
{
    internal class Operaciones
    {
        int A, B, C;

        public double Restar(string ladoA, string ladoB)
        {
            double A = double.Parse(ladoA);
            double B = double.Parse(ladoB);
            double C = A - B;
            return C;
        }

        public double Sumar(string ladoA, string ladoB)
        {
            double A = double.Parse(ladoA);
            double B = double.Parse(ladoB);
            double C = A + B;
            return C;
        }

        public double Multiplicar(string ladoA, string ladoB)
        {
            double A = double.Parse(ladoA);
            double B = double.Parse(ladoB);
            double C = A * B;
            return C;
        }

        public double Dividir(string ladoA, string ladoB)
        {
            double A = double.Parse(ladoA);
            double B = double.Parse(ladoB);
            double C = A / B;
            return C;
        }
        public double NumeroNegativo(string ladoA)
        {
            double A = double.Parse(ladoA);
            double C = A * -1;
            return C;
        }

        public double AgregarDecimal(string ladoA)
        {
            string A = ladoA;
            string C = A + ".";
            double resultado = double.Parse(C);
            return resultado;
        }

        public double cuadrado(string ladoA)
        {
            double A = double.Parse(ladoA);
            double C = A * A;
            return C;
        }

        public double RaizCuadrada(string ladoA)
        {
            double A = double.Parse(ladoA);
            double C = Math.Sqrt(A);
            return C;
        }
    }
}
