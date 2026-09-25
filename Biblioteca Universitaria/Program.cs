using System;
using System.IO;

namespace Biblioteca_Universitaria
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Directory.CreateDirectory("Biblioteca");

            Console.WriteLine("Bienvenido a la Bibliote Universitaria");
            Console.WriteLine("========================================\n");
            Console.WriteLine("Este programa permite registrar, buscar, mostrar y eliminar libros de la biblioteca universitaria.\n");
            Console.WriteLine("Para comenzar, seleccione una opción del menú a continuación:\n");
            Ejecutar();
        }
        static void MostrarMenu()
        {
            Console.WriteLine("========================================");
            Console.WriteLine("                 Menú");
            Console.WriteLine("========================================");
            Console.WriteLine("1. Registrar un libro");
            Console.WriteLine("2. Buscar un libro");
            Console.WriteLine("3. Mostrar todos los libros");
            Console.WriteLine("4. Eliminar un libro");
            Console.WriteLine("5. Salir\n");
            Console.Write("Seleccione una opción: ");
        }

        static void Ejecutar()
        {
            Biblioteca biblioteca = new Biblioteca();
            biblioteca.CargarLibros();
            bool salir = false;
            while (!salir)
            {
                MostrarMenu();
                int opcion = int.Parse(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        biblioteca.RegistrarLibro();
                        break;
                    case 2:
                        Console.Write("\nIngrese el código del libro a buscar: ");
                        int codigoBuscar = int.Parse(Console.ReadLine());
                        biblioteca.BuscarLibro(codigoBuscar);
                        break;
                    case 3:
                        biblioteca.MostrarLibros();
                        break;
                    case 4:
                        Console.Write("\nIngrese el código del libro a eliminar: ");
                        int codigoEliminar = int.Parse(Console.ReadLine());
                        biblioteca.Eliminarlibro(codigoEliminar);
                        break;
                    case 5:
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Intente nuevamente.");
                        break;
                }
            }
        }
    }
}
