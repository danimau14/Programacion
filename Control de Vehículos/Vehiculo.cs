using System;
using System.Collections.Generic;
using System.Text;

namespace Control_de_Vehículos
{
    public class Vehiculo
    {
        public string Dueño { get; set; }
        public string Placa { get; set; }
        public string Marca { get; set; }
        public int Modelo { get; set; }
        //public string? Placa { get; internal set; }

        public Vehiculo(string Placa, string Dueño, string Marca, int Modelo)
        {
            // Constructor para inicializar los datos del vehiculo

            this.Placa = Placa;
            this.Dueño = Dueño;
            this.Marca = Marca;
            this.Modelo = Modelo;
        }
    }
}
