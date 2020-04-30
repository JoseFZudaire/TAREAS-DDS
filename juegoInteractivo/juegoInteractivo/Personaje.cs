using System;
using System.Collections.Generic;
using System.Text;
//using System.Runtime.dll; 

namespace juegoInteractivo
{
    abstract class Personaje 
    { 
        protected string nombre { get; set; }
        protected float peso { get; set; }
        protected float altura { get; set; }
        protected String[] habilidades { get; set; }
        protected int inteligencia { get; set; }



        public Personaje() { }
        public Personaje (string nombre, float peso, float altura, int inteligencia, String[] habilidades)
        {
           this.nombre = nombre;
           this.peso = peso;
           this.altura = altura;
           this.inteligencia = inteligencia;
           this.habilidades = habilidades;           
        }

        public void setNombre(string unNombre) { nombre = unNombre; }
        public string getNombre() { return nombre; }

        public abstract Personaje copiar();
       

    }
}
