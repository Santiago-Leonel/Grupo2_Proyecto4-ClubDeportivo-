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
	public class Ninio : Persona
	{
		protected DateTime ultimoMesPago;
		protected string deporte;
		protected int cat_;

		public Ninio(string nombre, string apellido, int edad, int dni, string deporte, int categoria): base(nombre, apellido, edad, dni)
		{
			this.deporte = deporte;
			this.cat_ = categoria;
		}
		
		public override void MostrarDatos()
		{
			Console.WriteLine("Niño/a |	[DNI: {0}] Nombre: {1} {2}", dni, apellido, nombre);
		}
		
		public override void DatosAmpliados()
		{
			Console.WriteLine("DATOS DEL/LA NIÑO/A");
			Console.WriteLine("Nombre y apellido: {0} {1}", nombre, apellido);
			Console.WriteLine("DNI: {0}", dni);
			Console.WriteLine("Deporte: {0}", deporte);
			Console.WriteLine("Categoría: {0}", cat_);
			Console.WriteLine("---------------\n");
		}
		
		public string Deporte
		{
			get { return deporte; }
		}

		public DateTime UltimoMesPago
		{
			set { ultimoMesPago = value; }
			get { return ultimoMesPago; }
		}

		public int Cat_
		{
			get { return cat_; }
		}
	}
}