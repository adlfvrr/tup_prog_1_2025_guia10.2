using ej2.Models;
namespace ej2
{
    internal class Program
    {
        static private Servicio servicio = new Servicio();
        private static int MostrarPantallaSolicitarOpcionMenu()
        {
            Console.Clear();
            Console.WriteLine("Ingrese las siguientes opciones:\n1- Registrar un alumno\n2- Mostrar alumno con mayor y menor nota\n3- Mostrar el listado de alumnos ordenados por numero de libreta\n4- Mostrar promedio general y el listado que superaron el promedio\n5- Buscar alumno por numero de libreta\n(otro)- Salir");
            int op = Convert.ToInt32(Console.ReadLine());
            return op;
        }
        private static void MostrarPantallaSolicitarAlumno()
        {
            Console.Write("Ingrese nombre del alumno: ");
            string nombre = Console.ReadLine();
            Console.Write($"Ingrese numero de libreta de {nombre}: ");
            int libreta = Convert.ToInt32(Console.ReadLine());
            Console.Write($"Ingrese nota de {nombre}: ");
            double nota = Convert.ToDouble(Console.ReadLine());
            bool registro = servicio.RegistrarAlumno(libreta, nombre, nota);
            if (registro == true)
            {
                Console.WriteLine($"{nombre}, datos registrados correctamente");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Capacidad superada");
                Console.ReadKey();
            }
        }
        private static void MostrarPantallaMostrarAlumnoMayorYMenorNota()
        {
            if (servicio.Cantidad > 0)
            {
                int indiceMayor = servicio.CalcularAlumnoMayorNota();
                int indiceMenor = servicio.CalcularAlumnoMenorNota();
                Console.WriteLine($"El alumno con mayor nota es {servicio.Nombres[indiceMayor]}, con una nota de {servicio.Notas[indiceMayor]}\nEl alumno con menor nota es {servicio.Nombres[indiceMenor]}, con una nota de {servicio.Notas[indiceMenor]}");
                Console.ReadKey();            
            }
            else
            {
                Console.WriteLine("No se ingresaron alumnos");
                Console.ReadKey();
            }
        }
        private static void MostrarPantallaListadoOrdenadosPorLibreta()
        {
           servicio.OrdenarAlumnosPorLibreta();
        }
        private static void MostrarPantallaPromedioYListadoSuperaronPromedio()
        {
            double prom = servicio.CalcularPromedio();
            Console.WriteLine($"El promedio de las notas es de {prom:f2}");
            int[] listaAlumnosSuperioresAlPromedio = servicio.ListarAlumnosSuperaronElPromedio(out int cantidadMayores);
            Console.WriteLine("Los alumnos mayores al promedio son:");
            for(int i = 0; i < cantidadMayores; i++)
            {
                Console.WriteLine($"{servicio.Nombres[i]} ({servicio.Notas[i]})");
            }
            Console.ReadKey();
        }
        private static void MostrarPantallaDatosAlumno()
        {
            Console.Write("Ingrese numero de libreta del alumno: ");
            int numero = Convert.ToInt32(Console.ReadLine());
            int indice = servicio.BuscarPorLibreta(numero);
            if(indice != -1)
            {
                Console.WriteLine($"Nombre: {servicio.Nombres[indice]}, Nota: {servicio.Notas[indice]}");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Alumno no encontrado");
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
                    case 1: MostrarPantallaSolicitarAlumno();break;
                    case 2: MostrarPantallaMostrarAlumnoMayorYMenorNota();break;
                    case 3: MostrarPantallaListadoOrdenadosPorLibreta();break;
                    case 4: MostrarPantallaPromedioYListadoSuperaronPromedio(); break;
                    case 5: MostrarPantallaDatosAlumno();break;
                    default: menu = false;break;
                }
            }
        }
    }
}
