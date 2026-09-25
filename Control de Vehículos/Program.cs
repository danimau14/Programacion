namespace Control_de_Vehículos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Directory.CreateDirectory("Vehiculos");

            Console.WriteLine("Bienvenido al Registro de Vehiculos.");
            Console.WriteLine("========================================\n");
            Console.WriteLine("Este programa permite registrar, buscar, mostrar, eliminar y mostrar la cantidad de vehiculos que están registrados.\n");
            Console.WriteLine("Para comenzar, seleccione una opción del menú a continuación:\n");
            Ejecutar();
        }

        static void MostrarMenu()
        {
            Console.WriteLine("\n========================================");
            Console.WriteLine("                 Menú");
            Console.WriteLine("========================================");
            Console.WriteLine("1. Registrar un vehiculo");
            Console.WriteLine("2. Buscar un vehiculo");
            Console.WriteLine("3. Mostrar todos los vehiculos");
            Console.WriteLine("4. Eliminar un vehiculo");
            Console.WriteLine("5. Cantidad de Vehiculos REgistrados.");
            Console.WriteLine("6. Salir\n");
            Console.Write("Seleccione una opción: ");
        }
        static void Ejecutar()
        {
            Control control = new Control();
            control.CargarVehiculos();
            bool salir = false;
            while (!salir)
            {
                MostrarMenu();
                int opcion = int.Parse(Console.ReadLine());
                Console.WriteLine("\n");
                switch (opcion)
                {
                    case 1:
                        control.RegistrarVehiculo();
                        break;
                    case 2:
                        Console.Write("Ingrese la placa del vehiculo a buscar: ");
                        string PlacaBuscar = Console.ReadLine();
                        control.BuscarVehiculo(PlacaBuscar);
                        break;
                    case 3:
                        control.MostrarVehiculosRegistrados();
                        break;
                    case 4:
                        Console.Write("Ingrese la placa del vehiculo a eliminar: ");
                        string PlacaEliminar = Console.ReadLine();
                        control.EliminarVehiculoPlaca(PlacaEliminar);
                        break;
                    case 5:
                        control.CantidadVehiculos();
                        break;
                    case 6:
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
