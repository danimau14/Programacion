using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace Biblioteca_Universitaria
{
    public class Libros
    {
        public int codigo { get; set; }
        public string nombre { get; set; }
        public string autor { get; set; }
        public int año_publicacion { get; set; }

        public Libros(int Codigo, string Nombre, string Autor, int AñoPublicacion)
        {
            // Constructor para inicializar los datos del libro
            this.codigo = Codigo;
            this.nombre = Nombre;
            this.autor = Autor;
            this.año_publicacion = AñoPublicacion;
        }
    

    }
}