using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int x, i;
            int[] v;
            Console.Write("Introduce cantidad de elementos del vector: ");
            x = Convert.ToInt32(Console.ReadLine());
            v = new int[x];
            Console.WriteLine("El tamaño de V es {0}", v.Length);
            Console.WriteLine("introduce los valores");
            for (i = 0; i < x; i++)
            {
                v[i] = Convert.ToInt32(Console.ReadLine());
            }
            for (i = 0; i < x; i++)
            {
                Console.WriteLine("Posición: {0}\tValor: {1}", i, v[i]);
            }
            Console.ReadKey();
        }
    }
}
