using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Biblioteca_Universitaria
{
    internal class Biblioteca
    {
        public List<Libros> librosRegistrados = [];

        public void RegistrarLibro()
        {
            // Lógica para registrar un libro en la biblioteca
            // Puedes almacenar los libros en una lista o base de datos según tus necesidades

            Console.Write("\nIngrese el código del libro: ");
            int codigo = int.Parse(Console.ReadLine());
            Console.Write("Ingrese el nombre del libro: ");
            string nombre = Console.ReadLine();
            Console.Write("Ingrese el autor del libro: ");
            string autor = Console.ReadLine();
            Console.Write("Ingrese el año de publicación del libro: ");
            int año_publicacion = int.Parse(Console.ReadLine());

            Libros libro = new Libros(codigo, nombre, autor, año_publicacion);
            // Agregar el libro a la lista de libros registrados}
            if (librosRegistrados.Count < 20)
            {
                librosRegistrados.Add(libro);
                GuardarLibros();
                Console.WriteLine("Libro registrado exitosamente.\n");
            }
            else
            {
                Console.WriteLine("No se pueden registrar más libros.\n");
            }
        }

        public void BuscarLibro(int codigo)
        {
            Console.WriteLine();
            // Logica para buscar un libro por su codigo
            bool encontrado = false;
            foreach (Libros libro in librosRegistrados)
            {
                if (libro.codigo == codigo)
                {
                    encontrado = true;
                    Console.WriteLine($"\nLibro encontrado:");
                    Console.WriteLine($"Codigo: {libro.codigo}");
                    Console.WriteLine($"Nombre: {libro.nombre}");
                    Console.WriteLine($"Autor: {libro.autor}");
                    Console.WriteLine($"Año de Publicacion: {libro.año_publicacion}\n");
                }
            }
            if (!encontrado)
            {
                Console.WriteLine("Libro no encontrado.\n");
            }
        }

        public void MostrarLibros()
        {
            // Logica para mostrar todos los libros registrados
            Console.WriteLine("\nLibros registrados en la Bibliote Universitaria:");
            int contador = 1;
            foreach (Libros libro in librosRegistrados)
            {
                Console.WriteLine($"\nLibro {contador++}:");
                Console.WriteLine($"Codigo: {libro.codigo}");
                Console.WriteLine($"Nombre: {libro.nombre}");
                Console.WriteLine($"Autor: {libro.autor}");
                Console.WriteLine($"Año de Publicacion: {libro.año_publicacion}");
            }
            Console.WriteLine();
        }

        public void Eliminarlibro(int codigo)
        {
            Console.WriteLine();
            //Logica para eliminar un libro de la biblioteca
            bool encontrado = false;
            foreach (Libros libro in librosRegistrados)
            {
                if (libro.codigo == codigo)
                {
                    encontrado = true;
                    librosRegistrados.Remove(libro);
                    GuardarLibros();
                    Console.WriteLine("Libro eliminado exitosamente.\n");
                    return;
                }
            }
            if (!encontrado)
            {
                Console.WriteLine("Libro no encontrado.\n");
            }
        }

        public void GuardarLibros()
        {
            List<string> lineas = [];
            foreach (Libros libro in librosRegistrados)
            {
                // Logica para guardar los libros en el archivo Libros.txt
                string linea1 = $"{libro.codigo} | {libro.nombre} | {libro.autor} | {libro.año_publicacion}";
                lineas.Add(linea1);
            }
            string rutaArchivo = "Biblioteca/Libros.txt";
            File.WriteAllText(
                    rutaArchivo,
                    string.Join("\n", lineas));
        }

        public void CargarLibros()
        {
            // Logica para cargar los libros desde el archivo Libros.txt
            string rutaArchivo = "Biblioteca/Libros.txt";
            if (File.Exists(rutaArchivo))
            {
                string[] lineas = File.ReadAllLines(rutaArchivo);
                foreach (string linea in lineas)
                {
                    string[] datos = linea.Split('|');
                    int codigo = int.Parse(datos[0].Trim());
                    string nombre = datos[1].Trim();
                    string autor = datos[2].Trim();
                    int año_publicacion = int.Parse(datos[3].Trim());
                    Libros libro = new Libros(codigo, nombre, autor, año_publicacion);
                    librosRegistrados.Add(libro);
                }
            }
        }
    }
}
