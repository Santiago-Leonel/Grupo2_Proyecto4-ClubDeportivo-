/*
 * Creado por SharpDevelop.
 * Usuario: Usuario
 * Fecha: 2/11/2024
 * Hora: 16:22
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;

namespace elclub.Clases
{
    public class Persona
    {
        protected string nombre, apellido;
        protected int edad, dni;

        public Persona(string nom_, string ape_, int edad, int num_documento)
        {
        	nombre = nom_;
        	apellido = ape_;
        	this.edad = edad;
        	dni = num_documento;
        }
        
        public virtual void MostrarDatos(){}
        
        public virtual void DatosAmpliados(){}
        
        public string Nombre
        {
            get { return nombre; }
        }
        
        public string Apellido
        {
            get { return apellido; }
        }
        
        public int Edad
        {
            get { return edad; }
        }
        
        public int Dni
        {
            get { return dni; }
        }
    }
}
