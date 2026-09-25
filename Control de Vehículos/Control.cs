using System;
using System.Collections.Generic;
using System.Numerics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;

namespace Control_de_Vehículos
{
    internal class Control
    {

        public List<Vehiculo> VehiculosRegistrados = [];
        public void RegistrarVehiculo()
        {
            // logica para registrar vehiculos

            Console.Write("Placa: ");
            string Placa = Console.ReadLine();
            Console.Write("Dueño: ");
            string Dueño = Console.ReadLine();
            Console.Write("Marca: ");
            string Marca = Console.ReadLine();
            Console.Write("Modelo: ");
            int Modelo = int.Parse(Console.ReadLine());
            Console.WriteLine("\n");

            bool exists = false;

            foreach (Vehiculo vehiculo in VehiculosRegistrados)
            {
                if (vehiculo.Placa == Placa)
                {
                    exists = true;
                    
                }
            }

            if (exists == true)
            {
                Console.WriteLine("Este Vehiculo ya está Registrado.\n");
            }
            else
            {
                if (VehiculosRegistrados.Count < 30)
                {
                    Console.WriteLine("Vehiculo Registrado.\n");
                    Vehiculo vehiculo = new Vehiculo(Placa, Dueño, Marca, Modelo);
                    VehiculosRegistrados.Add(vehiculo);
                    GuardarVehiculos();
                }
                else
                {
                    Console.WriteLine("No Se Puede Registrar Mas Vehiculos.\n");
                }
            }
        }

        public void BuscarVehiculo(string PlacaBuscar)
        {
            // Logica para buscar un vehiculo por placa
            bool encontrado = false;
            foreach (Vehiculo vehiculo in VehiculosRegistrados)
            {
                if (PlacaBuscar == vehiculo.Placa)
                {
                    encontrado = true; 
                    Console.WriteLine($"Vehiculo encontrado:");
                    Console.WriteLine($"Placa: {vehiculo.Placa}");
                    Console.WriteLine($"Dueño: {vehiculo.Dueño}");
                    Console.WriteLine($"Marca: {vehiculo.Marca}");
                    Console.WriteLine($"Modelo: {vehiculo.Modelo}\n");
                }
            }
            if (!encontrado)
            {
                Console.WriteLine("Vehiculo no encontrado!\n");
            }
        }

        public void MostrarVehiculosRegistrados()
        {
            // Logica para mostrar todos los vehiculos registrados
            int v = 1;


            Console.WriteLine("Vehiculos Registrados:\n");
            foreach (Vehiculo vehiculo in VehiculosRegistrados)
            {
                Console.WriteLine($"Vehiculo {v++}:");
                Console.WriteLine($"Placa: {vehiculo.Placa}");
                Console.WriteLine($"Dueño: {vehiculo.Dueño}");
                Console.WriteLine($"Marca: {vehiculo.Marca}");
                Console.WriteLine($"Modelo: {vehiculo.Modelo}\n");
            }
        }

        private Vehiculo vehiculoeliminar;
        public void EliminarVehiculoPlaca(string PlacaEliminar)
        {
            // Logica para eliminar un vehiculo por placa
            bool encontrado = false;
            foreach (Vehiculo vehiculo in VehiculosRegistrados)
            {
                if (vehiculo.Placa == PlacaEliminar)
                {
                    encontrado = true;
                    Console.WriteLine($"\nVehiculo a Eliminar:");
                    Console.WriteLine($"Placa: {vehiculo.Placa}");
                    Console.WriteLine($"Dueño: {vehiculo.Dueño}");
                    Console.WriteLine($"Marca: {vehiculo.Marca}");
                    Console.WriteLine($"Modelo: {vehiculo.Modelo}");
                    vehiculoeliminar = vehiculo;
                }
            }
            if (!encontrado)
            {
                Console.WriteLine("Vehiculo no encontrado!\n");
            }

            VehiculosRegistrados.Remove(vehiculoeliminar);
            GuardarVehiculos();
            Console.WriteLine("\nVehiculo eliminado.\n");
        }

        public void CantidadVehiculos()
        {
            // Logica para mostrar la cantidad de Vehiculos Registrados.
            Console.WriteLine("¡Cantidad de Vehiculos Registrados!");
            Console.WriteLine($"{VehiculosRegistrados.Count} Vehiculos Registrados.\n");
        }

        public void GuardarVehiculos()
        {

            // Logica para guardar los vehiculos registrados en el archivo vehiculos.txt
            List<string> lineas = [];
            foreach (Vehiculo vehiculo in VehiculosRegistrados)
            {
                string linea1 = $"{vehiculo.Placa} | {vehiculo.Dueño} | {vehiculo.Marca} | {vehiculo.Modelo}";
                lineas.Add(linea1);
            }
            string rutaArchivo = "Vehiculos/vehiculos.txt";
            File.WriteAllText(
                    rutaArchivo,
                    string.Join("\n", lineas));
        }

        public void CargarVehiculos()
        {
            // Logica para cargar los vehiculos registrados desde el archivo vehiculos.txt
            string rutaArchivo = "Vehiculos/vehiculos.txt";
            if (File.Exists(rutaArchivo))
            {
                string[] lineas = File.ReadAllLines(rutaArchivo);
                foreach (string linea in lineas)
                {
                    string[] datos = linea.Split('|');
                    string Placa = datos[0].Trim();
                    string Dueño = datos[1].Trim();
                    string Marca = datos[2].Trim();
                    int Modelo = int.Parse(datos[3].Trim());
                    Vehiculo vehiculo = new Vehiculo(Placa, Dueño, Marca, Modelo);
                    VehiculosRegistrados.Add(vehiculo);
                }
            }
        }
    }
}
