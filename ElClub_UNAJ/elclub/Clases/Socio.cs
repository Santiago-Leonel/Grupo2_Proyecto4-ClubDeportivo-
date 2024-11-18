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
	public class Socio : Ninio
	{
		private double descuento;
		
		public Socio(string nom_, string ape_, int edad, int dni, string depo_, int cat_, int descuento): base(nom_, ape_, edad, dni, depo_, cat_)
		{
			this.descuento = descuento;
		}
		
		public override void MostrarDatos()
		{
			Console.WriteLine("Socio/a|	[DNI: {0}] Nombre: {1} {2}", dni, apellido, nombre);
		}
		
		public override void DatosAmpliados()
		{
			Console.WriteLine("DATOS DEL SOCIO");
			Console.WriteLine("Nombre y apellido: {0} {1}", nombre, apellido);
			Console.WriteLine("DNI: {0}", dni);
			Console.WriteLine("Deporte: {0}", deporte);
			Console.WriteLine("Categoría: {0}", cat_);
			Console.WriteLine("---------------\n");
		}
		
		public double Descuento
		{
			get { return descuento; }
		}
	}
}

