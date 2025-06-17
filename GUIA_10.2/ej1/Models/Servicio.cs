using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ej1.Models
{
    internal class Servicio
    {
        private int[] Lista;
        public int contador;
        public Servicio()
        {
            Lista = new int[50];
            contador = 0;
        }
        public void RegistrarValor(int valor)
        {
            Lista[contador] = valor;
            contador++;
        }
        public double CalcularPromedio()
        {
            int ac = 0;
            for (int i = 0; i < contador; i++)
            {
                ac += Lista[i];
            }
            double prom = 1.0 * (ac / (double)contador);
            return prom;
        }
        public double CalcularMaximo()
        {
            double maximo = Lista[0];
            for (int i = 1; i < contador; i++)
            {
                if (Lista[i] > maximo)
                {
                    maximo = Lista[i];
                }
            }
            return maximo;
        }
        public double CalcularMinimo()
        {
            double minimo = Lista[0];
            for (int i = 1; i < contador; i++)
            {
                if (Lista[i] < minimo)
                {
                    minimo = Lista[i];
                }
            }
            return minimo;
        }
        private void Intercambiar(int i, int j)
        {
            int aux = Lista[i];
            Lista[i] = Lista[j];
            Lista[j] = aux;
        }
        public void OrdenarLista()
        {
            for (int i = 0; i < contador; i++)
            {
                for (int j = i + 1; j < contador; j++)
                {
                    if (Lista[i] < Lista[j])
                    {
                        Intercambiar(i, j);
                    }
                }
            }
            for (int i = 0; i < contador; i++)
            {
                Console.Write($"{i}:{Lista[i]}, ");
            }
        }
        public int BuscarValor(int buscado)
        {
            int indice = -1;
            int cont = 0;
            while (indice < 0 && cont < contador)
            {
                if (Lista[cont] == buscado)
                {
                    indice = cont;
                }
                else
                {
                    cont++;
                }
            }
            return indice;
        }
        public int[] ListaSuperioresAlPromedio(out int contadorSuperiores)
        {
            contadorSuperiores = 0;
            int[] ListaSuperioresAlPromedio = new int[contador];
            double prom = CalcularPromedio();
            for (int i = 0; i < contador; i++)
            {
                if (Lista[i] >= prom)
                {
                    ListaSuperioresAlPromedio[contadorSuperiores] = Lista[i];
                    contadorSuperiores++;
                }
            }
            return ListaSuperioresAlPromedio;
        }
    }
}
