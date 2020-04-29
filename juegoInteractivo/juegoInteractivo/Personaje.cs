using System;
using System.Collections.Generic;
using System.Text;
//using System.Runtime.dll; 

namespace juegoInteractivo
{
     class Personaje 
    {
        public float altura;
        //private string habilidades { get; set; }
       // private List<String> habilidades;
        private int inteligencia;
        private string nombre;
        private float peso; 
        
       public Personaje (float unaAltura, int unaInteligencia, string unNombre, float unPeso)
        {
            altura = unaAltura;
           // habilidades.AddRange(unasHabilidades);
            inteligencia = unaInteligencia;
            nombre = unNombre;
            peso = unPeso;
        }

        public void setNombre(string unNombre) { nombre = unNombre; }
        public string getNombre() { return nombre; }

        public Personaje copiar()
        {
            Personaje unPersonaje = (Personaje) this.MemberwiseClone(); //Copio el personaje, me lo devuelve con los mismos atributos
            //unPersonaje.habilidades = (String)habilidades.Clone();
            //unPersonaje.nombre = (String)nombre.Clone();
            return unPersonaje;
        }

        

    }
}
