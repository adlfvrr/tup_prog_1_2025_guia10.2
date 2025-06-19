using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ej2.Models
{
    internal class Servicio
    {
        public string[] Nombres;
        public int[] Libretas;
        public double[] Notas;
        public int Cantidad;
        public Servicio()
        {
            Cantidad = 0;
            Nombres = new string[50];
            Notas = new double[50];
            Libretas = new int[50];
        }
        private void IntercambioCompleto(int i, int j)
        {
            int aux = Libretas[i];
            Libretas[i] = Libretas[j];
            Libretas[j] = aux;
            //
            double aux2 = Notas[i];
            Notas[i] = Notas[j];
            Notas[j] = aux2;
            //
            string aux3 = Nombres[i];
            Nombres[i] = Nombres[j];
            Nombres[j] = aux3;
        }
        public bool RegistrarAlumno(int libreta, string nombre, double nota)
        {
            bool registrar = false;
            if (Cantidad < Notas.Length)
            {
                registrar = true;
                Libretas[Cantidad] = libreta;
                Notas[Cantidad] = nota;
                Nombres[Cantidad] = nombre;
                Cantidad++;
            }
            return registrar;
        }
        public double CalcularPromedio()
        {
            double prom = 0;
            double ac = 0;
            for (int i = 0; i < Cantidad; i++)
            {
                ac += Notas[i];
            }
            prom = 1.0 * (ac / (double)Cantidad);
            return prom;
        }
        public int CalcularAlumnoMayorNota()
        {
            int indice = -1;
            int mayor = 0;
            for (int i = 0; i < Cantidad; i++)
            {
                if (Notas[i] > Notas[mayor])
                {
                    mayor = i;
                }
            }
            return mayor;
        }
        public int CalcularAlumnoMenorNota()
        {
            int indice = -1;
            int menor = 0;
            for (int i = 0; i < Cantidad; i++)
            {
                if (Notas[i] < Notas[menor])
                {
                    menor = i;
                }
            }
            return menor;
        }
        public void OrdenarAlumnosPorLibreta()
        {
            for (int i = 0; i < Cantidad; i++)
            {
                for (int j = i + 1; j < Cantidad; j++)
                {
                    if (Libretas[i] > Libretas[j])
                    {
                        IntercambioCompleto(i, j);
                    }
                }
                Console.WriteLine($"{i + 1}, Nombre:{Nombres[i]}, Numero de libreta {Libretas[i]}, Nota {Notas[i]}");
            }
            Console.ReadKey();
        }
        public int BuscarPorLibreta(int libreta)
        {
            int indice = -1;
            for (int i = 0; i < Cantidad; i++)
            {
                if (Libretas[i] == libreta)
                {
                    indice = i;
                }
            }
            return indice;
        }
        public int BuscarValor(int buscado)
        {
            int valor = -1;
            for (int i = 0; i < Cantidad; i++)
            {
                if (Libretas[i] == buscado)
                {
                    valor = Libretas[i];
                }
            }
            return valor;
        }
        public int[] ListarAlumnosSuperaronElPromedio(out int cantidadMayores)
        {
            int[] mayores = new int[Cantidad];
            cantidadMayores = 0;
            double promedio = CalcularPromedio();
            for (int i = 0; i < Cantidad; i++)
            {
                if (Notas[i] >= promedio)
                {
                    mayores[cantidadMayores] = Libretas[i];
                    cantidadMayores++;
                }
            }
            return mayores;
        }
    }
}
