using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_1
{
    class Animales
    {
        private String nombre;
        private String sexo;
        private String raza;
        private double tamano;
        private double peso;
        private int edad;
        private DateTime fecha;
        private Boolean chip;
        private Boolean ppp;
        private Boolean esterilizado;
        private String descripción;

        public Animales(string nombre, string sexo, string raza, double tamano, double peso, int edad, DateTime fecha, bool chip, bool ppp, bool esterilizado, string descripción)
        {
            this.nombre = nombre;
            this.sexo = sexo;
            this.raza = raza;
            this.tamano = tamano;
            this.peso = peso;
            this.edad = edad;
            this.fecha = fecha;
            this.chip = chip;
            this.ppp = ppp;
            this.esterilizado = esterilizado;
            this.descripción = descripción;
        }
    }
}
