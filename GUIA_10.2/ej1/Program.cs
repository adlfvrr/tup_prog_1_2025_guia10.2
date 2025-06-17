using ej1.Models;
namespace ej1
{
    internal class Program
    {
        static private Servicio servicio = new Servicio();
        private static int MostrarPantallaSolicitarOpcionMenu()
        {
            Console.Clear();
            Console.WriteLine("Ingrese las siguientes opciones:\n1- Procesar un solo numero\n2- Procesar varios numeros\n3- Mostrar máximo y mínimo\n4- Mostrar promedio\n5- Mostrar cantidad de números ingresados\n6- Ordenar y mostrar listado\n7- Verificar si existe un valor (Buscar valor)\n8- Mostrar listado que superaron el promedio\n(otro)- Salir.");
            int op = Convert.ToInt32(Console.ReadLine());
            return op;
        }
        private static void MostrarPantallaSolicitarNumero()
        {
            Console.Write("Ingrese un numero: ");
            int n = Convert.ToInt32(Console.ReadLine());
            servicio.RegistrarValor(n);
        }
        private static void MostrarPantallaSolicitarVariosNumeros()
        {
            Console.Write("Ingresar cantidad de numeros a procesar: ");
            int cantidad = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < cantidad; i++)
            {
                Console.Write("Ingrese un numero: ");
                int n = Convert.ToInt32(Console.ReadLine());
                servicio.RegistrarValor(n);
            } 
        }
        private static void MostrarPantallaMaximoYMinimo()
        {
           if (servicio.contador > 0)
            {
                 double minimo = servicio.CalcularMinimo();
                 double maximo = servicio.CalcularMaximo();
                 Console.WriteLine($"El numero máximo ingresado es {maximo}\nEl numero mínimo ingresado es {minimo}");
                 Console.ReadKey();
            }
            else
            {
                    Console.WriteLine("No se ingresaron numeros");
            }
        }
        private static void MostrarPantallaCalcularYMostrarPromedio()
        {
            double prom;
            if (servicio.contador > 0)
            {
                prom = servicio.CalcularPromedio();
                Console.WriteLine($"El promedio de los numeros del arreglo es {prom:f2}");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("No se ingresaron numeros.");
                Console.ReadKey();
            }
        }
        private static void MostrarPantallaCantidad()
        {
            Console.WriteLine($"La cantidad de numeros ingresados es de {servicio.contador}");
            Console.ReadKey();
        }
        private static void MostrarPantallaOrdenarListadoYMostrar()
        {
            if (servicio.contador > 0)
            {
                servicio.OrdenarLista();
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("No se ingresaron numeros");
                Console.ReadKey();
            }
        }
        private static void MostrarPantallaBuscarNumero()
        {
            Console.Write("Ingrese numero a buscar: ");
            int n = Convert.ToInt32(Console.ReadLine());
            int indice = servicio.BuscarValor(n);
            if (indice != -1)
            {
                Console.WriteLine($"El valor {n} se encuentra en el índice {indice}");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Valor no encontrado");
                Console.ReadKey();
            }
        }
        static void Main(string[] args)
        {
            bool menu = true;
            while (menu)
            {
                int op = MostrarPantallaSolicitarOpcionMenu();
                switch (op)
                {
                        case 1:MostrarPantallaSolicitarNumero(); break;
                        case 2:MostrarPantallaSolicitarVariosNumeros(); break;
                        case 3: MostrarPantallaMaximoYMinimo(); break;
                        case 4: MostrarPantallaCalcularYMostrarPromedio(); break;
                        case 5: MostrarPantallaCantidad(); break;
                        case 6: MostrarPantallaOrdenarListadoYMostrar(); break;
                        case 7: MostrarPantallaBuscarNumero(); break;
                        case 8: 
                             int[] arregloSuperioresAlPromedio = servicio.ListaSuperioresAlPromedio(out int contadorSuperiores);
                        for (int i = 0; i < contadorSuperiores; i++)
                        {
                            Console.Write($"{i}:{arregloSuperioresAlPromedio[i]}, ");
                        }
                            Console.ReadKey();
                        break;
                        default: menu = false; break;
                }
            }
        }
    }
}
